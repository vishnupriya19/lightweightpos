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
    public class DesignationController : Controller
    {
        private IDesignationRepository _designationRepository;

        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        [HttpGet]
        [Route("Designation/Designation")]
        public JsonResult GetAllDesignation() 
        {
            var des = _designationRepository.GetAllDesignation();
            return Json(des);
        }
        [HttpGet]
        [Route("Designation/Designation/{id}")]
        public JsonResult GetDesignation(int id)
        {
            return Json(_designationRepository.GetDesignation(id));
        }
        [HttpDelete]
        [Route("Designation/DeleteDesignation/{id}")]
        public JsonResult DeleteDesignation(int id)
        {
            return Json(_designationRepository.DeleteDesignation(id));
        }
        [HttpPost]
        [Route("Designation/Designation")]
        public JsonResult AddDesignation([FromBody]Designation designation)
        {
            return Json(_designationRepository.AddDesignation(designation));
        }
    }
}