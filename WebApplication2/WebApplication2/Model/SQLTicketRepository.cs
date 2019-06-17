using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLTicketRepository : ITicketRepository
    {
        private AppDbContext context;

        public SQLTicketRepository(AppDbContext context)
        {
            this.context = context;
        }

        public string DeleteTicket(int merchId, int tickId)
        {
            var ticketline = context.TicketLineProduct.Where(t => t.MerchantId == merchId && t.TicketId == tickId);
            context.TicketLineProduct.RemoveRange(ticketline);
            context.SaveChanges();
            var ticket =  context.Ticket.FirstOrDefault(t => t.Merchantid == merchId && t.TicketId == tickId);
            if (ticket == null)
                return null;
            context.Ticket.Remove(ticket);
            context.SaveChanges();
            return "success";
        }

        public List<TicketContract> DoTicketing(List<TicketContract> ticket, int merchId, int empId, int custId)
        {
  
            Ticket ticketObject = new Ticket();
            ticketObject.CustomerId = custId;
            ticketObject.Merchantid = merchId;
            ticketObject.EmployeeId = empId;
            ticketObject.OrderDate = DateTime.Now;
            context.Ticket.Add(ticketObject);
            context.SaveChanges();
            double sum = 0;
            for (int i=0;i<ticket.Count;i++)
            {
                TicketLineProduct ticketLineProduct = new TicketLineProduct();
                ticketLineProduct.TicketId = ticketObject.TicketId;
                ticketLineProduct.MerchantId = merchId;
                ticketLineProduct.ProductId = ticket[i].ProductId;
                ticketLineProduct.Quantity = ticket[i].Quantity;
                var prod = context.Product.FirstOrDefault(p => p.ProductId == ticket[i].ProductId && p.MerchantId == merchId);
                if (prod == null)
                    return null;
                ticketLineProduct.Price = prod.Sellingprice;
                ticketLineProduct.Commission = prod.Comission;
                ticketLineProduct.TotalPrice = ticketLineProduct.Price * ticket[i].Quantity;
                sum = sum + ticketLineProduct.TotalPrice;
                var quant = context.Quantity.FirstOrDefault(q => q.ProductId == ticket[i].ProductId && q.MerchantId == merchId);
                if (quant == null)
                    return null;
                quant.QuantitySold = quant.QuantitySold + ticket[i].Quantity;
                quant.QuantityRemaining = quant.QuantityRemaining - ticket[i].Quantity;
                context.Quantity.Update(quant);
                context.SaveChanges();
                context.TicketLineProduct.Add(ticketLineProduct);
                context.SaveChanges();
            }
            ticketObject.TotalCost = sum;
            context.Ticket.Update(ticketObject);
            context.SaveChanges();
            return ticket;
        }

        public List<TicketLineProduct> GetAllTicketLine(int merchId)
        {
            return context.TicketLineProduct.Where(t => t.MerchantId == merchId).ToList();
        }

        public List<Ticket> GetAllTickets(int merchId)
        {
           return  context.Ticket.Where(t => t.Merchantid == merchId).ToList();
        }
    }
}
