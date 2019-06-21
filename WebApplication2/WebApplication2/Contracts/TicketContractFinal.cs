using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Contracts
{
    public class TicketContractFinal
    {
        public List<TicketContract> ticketContract;
        public int CustomerId { get; set; }
        public long TicketId { get; set; }
        public double TotalCost { get; set; }
    }
}
