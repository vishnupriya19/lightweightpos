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
   // [Route("api/[controller]")]
    //[ApiController]
    public class MerchantController : Controller
    {
        private IMerchantRepository _merchantRepository;
        private IEmployeeRepository _employeeRepository;

        public MerchantController(IMerchantRepository merchantRepository, IEmployeeRepository employeeRepository)
        {
            _merchantRepository = merchantRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("Merchant/Merchant")]
        public JsonResult AddMerchantDetails([FromBody]RegisterContract registerContract)
        {
            Merchant merchant = new Merchant();
            merchant.Name = registerContract.Name;
            merchant.OrganizationName = registerContract.Organization;
            merchant.Address = registerContract.Address;
            merchant.Phone = registerContract.Phone;
            registerContract.id = _merchantRepository.AddMerchantDetails(merchant);

            Employee employee = new Employee();
            employee.Name = registerContract.Name;
            employee.Phone = registerContract.Phone;
            employee.Email = registerContract.Email;
            employee.Username = registerContract.Username;
            employee.Password = registerContract.Password;
            employee.Dateofjoining = DateTime.UtcNow;
            employee.MerchantId = merchant.MerchantId;
            employee.DesignationId = 1;
            _employeeRepository.AddEmployee(merchant.MerchantId, employee);

            return Json(registerContract);
        }
        [HttpGet]
        [Route("Merchant/Merchant")]
        public JsonResult GetAllMerchants()
        {
            var merchant = _merchantRepository.GetAllMerchants();
            return Json(merchant);
        }
    }
}