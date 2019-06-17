using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        [Route("Customer/AllCustomer/{id}")]
        public JsonResult GetAllCustomer(int id)
        {
            return Json(_customerRepository.GetAllCustomer(id));
        }
        [HttpGet]
        [Route("Customer/Customer/{merchId}/{custId}")]
        public JsonResult GetCustomer(int merchId, int custId)
        {
            var cat = _customerRepository.GetCustomer(merchId, custId);
            return Json(cat);
        }
        [HttpPost]
        [Route("Customer/AddCustomer/{merchId}")]
        public JsonResult AddCustomer(int merchId, [FromBody]Customer customer)
        {
            return Json(_customerRepository.AddCustomer(merchId, customer));
        }
        [HttpDelete]
        [Route("Customer/DeleteCustomer/{merchId}/{custId}")]
        public JsonResult DeleteCustomer(int merchId, int custId)
        {
            return Json(_customerRepository.DeleteCustomer(merchId, custId));
        }
    }
}