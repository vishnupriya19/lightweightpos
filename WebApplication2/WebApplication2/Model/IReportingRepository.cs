using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface IReportingRepository
    {
        List<ReportSalesContract> ProductReporting(int merchId, string stDate, string edDate);
        List<ReportEmployeeContract> EmployeeReporting(int merchId, string stDate, string edDate);
    }
}
