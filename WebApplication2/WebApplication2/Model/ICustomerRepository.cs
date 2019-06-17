using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer(int id);
        Customer GetCustomer(int merchId, int custId);
        Customer AddCustomer(int merchId, Customer customer);
        Customer DeleteCustomer(int merchId, int custId);
    }
}
