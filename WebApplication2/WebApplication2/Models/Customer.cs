using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int? Points { get; set; }
        public int MerchantId { get; set; }

        public virtual Merchant Merchant { get; set; }
    }
}
