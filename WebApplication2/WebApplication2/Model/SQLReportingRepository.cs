using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLReportingRepository : IReportingRepository
    {
        private AppDbContext context;

        public SQLReportingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<ReportSalesContract> ProductReporting(int merchId, string stDate, string edDate)
        {
            DateTime startDate = DateTime.ParseExact(stDate, "yyyy-MM-dd", null);
            DateTime endDate = DateTime.ParseExact(edDate, "yyyy-MM-dd", null);
            var report = context.TicketLineProduct.Include(p => p.Product).Include(t => t.Ticket).Where(t => t.MerchantId == merchId && t.Ticket.OrderDate >= startDate && t.Ticket.OrderDate <= endDate).ToList();
            var ReportData = from data in report
                             group data by new { data.ProductId, data.Product.Name, data.Product.Unitcost, data.Price } into dta
                             select dta;
            List<ReportSalesContract> reportSalesContractList = new List<ReportSalesContract>();
            foreach (var dt in ReportData)
            {
                ReportSalesContract reportSalesContract = new ReportSalesContract();
                double quantity = 0;
                reportSalesContract.productId = dt.Key.ProductId;
                reportSalesContract.SellingPrice = dt.Key.Price;
                reportSalesContract.UnitCost = dt.Key.Unitcost;
                reportSalesContract.productName = dt.Key.Name;
                foreach (var d in dt)
                {
                    quantity = quantity + d.Quantity;
                    //reportSalesContract.SellingPrice = d.Price;
                    //reportSalesContract.productId = d.ProductId;
                    //reportSalesContract.UnitCost = d.Product.Unitcost;
                }
                reportSalesContract.TotalUnitCost = reportSalesContract.UnitCost * quantity;
                reportSalesContract.TotalSellingPrice = reportSalesContract.SellingPrice * quantity;
                reportSalesContract.Profit = reportSalesContract.TotalSellingPrice - reportSalesContract.TotalUnitCost;
                reportSalesContract.Quantity = quantity;
                reportSalesContractList.Add(reportSalesContract);
            }
            return reportSalesContractList;
        }
        public List<ReportEmployeeContract> EmployeeReporting(int merchId, string stDate, string edDate)
        {
            DateTime startDate = DateTime.ParseExact(stDate, "yyyy-MM-dd", null);
            DateTime endDate = DateTime.ParseExact(edDate, "yyyy-MM-dd", null);
            var report = context.TicketLineProduct.Include(t => t.Ticket).Where(t => t.MerchantId == merchId && t.Ticket.OrderDate >= startDate && t.Ticket.OrderDate <= endDate).ToList();
            var reportData = from data in report
                             group data by data.Ticket.EmployeeId into dta
                             select dta;
            List<ReportEmployeeContract> reportEmployeeContracts = new List<ReportEmployeeContract>();

            foreach (var dt in reportData)
            {
                double? comission = 0;
                ReportEmployeeContract reportEmployeeContract = new ReportEmployeeContract();
                foreach (var d in dt)
                {
                    comission = comission + d.Commission;
                }
                reportEmployeeContract.TotalComission = comission;
                var employe = context.Employee.FirstOrDefault(e => e.MerchantId == merchId && e.EmployeeId == dt.Key);
                reportEmployeeContract.EmployeeName = employe.Name;
                reportEmployeeContracts.Add(reportEmployeeContract);
            }
            return reportEmployeeContracts;
        }
    }
}
