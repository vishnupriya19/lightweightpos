using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Merchant
    {
        public Merchant()
        {
            Employee = new HashSet<Employee>();
        }

        public int MerchantId { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public virtual ICollection<Employee> Employee { get; set; }

    }
}
