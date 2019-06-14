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
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("")]
        [Route("Employee/AllEmployee/{id}")]
        //[Route("Home/GetAllEmployee")]
        public JsonResult GetEmployeeDetails(int id)
        {
            //return Json("Vishnu");
            var employees = _employeeRepository.GetAllEmployee(id).ToList();
            return Json(employees);
        }
        [HttpGet]
        [Route("Employee/Employee/{merchId}/{empId}")]
        // [Route("Home/GetEmployee/{id?}")]
        public JsonResult EmployeeDetails(int merchId, int empId)
        {
            var model = _employeeRepository.GetEmployee(merchId, empId);
            return Json(model);
        }
        [HttpPost]
        [Route("Employee/AddEmployee/{id}")]
        public JsonResult AddEmployeeDetails(int id, [FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(id, employee);
            return Json(employee);
        }
        [HttpDelete]
        [Route("Employee/DeleteEmployee/{merchId}/{empId}")]
        public JsonResult DeleteEmployeeDetails(int merchId, int empId)
        {
            return Json(_employeeRepository.DeleteEmployee(merchId, empId));

        }
        [HttpPost]
        [Route("Employee/ValidateLogin/{id}")]
        public JsonResult ValidateLogin(int id, [FromBody]LoginContract loginContract)
        {

            return Json(_employeeRepository.ValidateLogin(id, loginContract));
        }
    }
}