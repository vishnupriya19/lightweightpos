using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Contracts
{
    public class ReportSalesContract
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double UnitCost { get; set; }
        public double SellingPrice { get; set; }
        public double Quantity { get; set; }
        public double TotalUnitCost { get; set; }
        public double TotalSellingPrice { get; set; }
        public double Profit { get; set; }
    }
}
