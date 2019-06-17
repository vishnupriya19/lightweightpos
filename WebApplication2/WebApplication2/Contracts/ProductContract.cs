using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Contracts
{
    public class ProductContract
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitCost { get; set; }
        public double SellingPrice { get; set; }
        public double? Comission { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? CategoryId { get; set; }
        public int MerchantId { get; set; }
        public int? QuantityRemaining { get; set; }
    }
}
