using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Ticket
    {
        public long TicketId { get; set; }
        public int EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public double TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public int Merchantid { get; set; }
    }
}
