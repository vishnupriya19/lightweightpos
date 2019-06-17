using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private AppDbContext context;

        public SQLCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Customer AddCustomer(int merchId, Customer customer)
        {
            customer.MerchantId = merchId;
            context.Customer.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int merchId, int custId)
        {
            var customer = context.Customer.FirstOrDefault(c => c.CustomerId == custId && c.MerchantId == merchId);
            if (customer != null)
            {
                context.Customer.Remove(customer);
                context.SaveChanges();
            }
            return customer;
        }

        public List<Customer> GetAllCustomer(int id)
        {
            var customer = context.Customer.Where(c => c.MerchantId == id).ToList();
            return customer;
        }

        public Customer GetCustomer(int merchId, int custId)
        {
            var customer = context.Customer.FirstOrDefault(c => c.CustomerId == custId && c.MerchantId == merchId);
            return customer;
        }
    }
}
