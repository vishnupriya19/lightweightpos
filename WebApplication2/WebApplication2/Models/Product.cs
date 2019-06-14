using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Unitcost { get; set; }
        public int? CategoryId { get; set; }
        public double Sellingprice { get; set; }
        public double? Comission { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int MerchantId { get; set; }
        public string ModifiedUserName { get; set; }

        public virtual Category Category { get; set; }
        public virtual Merchant Merchant { get; set; }
        public virtual Quantity Quantity { get; set; }
    }
}
