using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contracts;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ReportingController : Controller
    {
        private IReportingRepository _reportingRepository;

        public ReportingController(IReportingRepository reportingRepository)
        {
            _reportingRepository = reportingRepository;
        }
        [HttpPost]
        [Route("Reporting/Reporting/{merchId}")]
        public JsonResult GetReporting(int merchId, [FromBody]ReportContract reportContract)
        {
            return Json(_reportingRepository.ProductReporting(merchId, reportContract.startDate, reportContract.endDate));
        }
        [HttpPost]
        [Route("Reporting/EmployeeReporting/{merchId}")]
        public JsonResult GetEmployeeReporting(int merchId, [FromBody]ReportContract reportContract)
        {
            return Json(_reportingRepository.EmployeeReporting(merchId, reportContract.startDate, reportContract.endDate));
        }
    }
}