using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime? Dateofjoining { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DesignationId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double? Salary { get; set; }
        public int MerchantId { get; set; }

        public virtual Designation Designation { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}
