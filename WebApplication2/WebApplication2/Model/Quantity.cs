using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Quantity
    {
        [Key]
        public int ProductId { get; set; }
        public int? QuantityInStock { get; set; }
        public int? QuantitySold { get; set; }
        public int? QuantityRemaining { get; set; }
        public int? DepletionQuantity { get; set; }
        [Key]
        public int MerchantId { get; set; }

        public virtual Product Product { get; set; }
    }
}
