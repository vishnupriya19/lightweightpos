using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface ITicketRepository
    {
        List<TicketContract> DoTicketing(List<TicketContract> tickets, int merchId, int empId, int custId);
        List<Ticket> GetAllTickets(int merchId);
        List<TicketLineProduct> GetAllTicketLine(int merchId);
        string DeleteTicket(int merchId, int tickId);
    }
}
