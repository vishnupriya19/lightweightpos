using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Quantity
    {
        public int ProductId { get; set; }
        public int? QuantityInStock { get; set; }
        public int? QuantitySold { get; set; }
        public int? QuantityRemaining { get; set; }
        public int? DepletionQuantity { get; set; }
        public int MerchantId { get; set; }

        public virtual Product Product { get; set; }
    }
}
