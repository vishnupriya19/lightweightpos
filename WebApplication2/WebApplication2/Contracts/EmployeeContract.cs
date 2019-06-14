using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Contracts
{
    public class EmployeeContract
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int DesignationId { get; set; }
        public string DesignantionName { get; set; }
        public double? Salary { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
    }
}
