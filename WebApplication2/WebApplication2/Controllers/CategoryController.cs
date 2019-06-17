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
  //  [Route("api/[controller]")]
   // [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        [Route("Category/AllCategory/{id}")]
        public JsonResult GetAllCategories(int id)
        {
            return Json(_categoryRepository.GetAllCategory(id));
        }
        [HttpGet]
        [Route("Category/Category/{merchId}/{catId}")]
        public JsonResult GetCategory(int merchId, int catId)
        {
            var cat = _categoryRepository.GetCategory(merchId, catId);
            if (cat == null)
                return Json(new object[] { });
            return Json(cat);
        }
        [HttpPost]
        [Route("Category/AddCategory/{merchId}")]
        public JsonResult AddCategory(int merchId, [FromBody]CategoryContract categoryContract)
        {
            return Json(_categoryRepository.AddCategory(merchId, categoryContract));
        }
        [HttpDelete]
        [Route("Category/DeleteCategory/{merchId}/{catId}")]
        public JsonResult DeleteCategory(int merchId, int catId)
        {
            return Json(_categoryRepository.DeleteCategory(merchId, catId));
        }
    }
}