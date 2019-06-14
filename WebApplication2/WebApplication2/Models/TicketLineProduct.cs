using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class TicketLineProduct
    {
        public long TicketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public double? Commission { get; set; }
        public int MerchantId { get; set; }
    }
}
