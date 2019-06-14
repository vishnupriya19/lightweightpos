using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contracts;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("")]
        [Route("Employee/Employee")]
        //[Route("Home/GetAllEmployee")]
        public JsonResult GetEmployeeDetails()
        {
            var employees = _employeeRepository.GetAllEmployee().ToList();
            return Json(employees);
        }
        [HttpGet]
        [Route("Employee/Employee/{id}")]
        // [Route("Home/GetEmployee/{id?}")]
        public JsonResult EmployeeDetails(int id)
        {
            Employee model = _employeeRepository.GetEmployee(id);
            return Json(model);
        }
        [HttpPost]
        [Route("Employee/Employee")]
        public JsonResult AddEmployeeDetails([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return Json(employee);
        }
        [HttpDelete]
        [Route("Employee/DeleteEmployee/{empId}/{merchId}")]
        public JsonResult DeleteEmployeeDetails(int empId,int merchId)
        {
           return Json( _employeeRepository.DeleteEmployee(empId,merchId));
           
        }
    }
}