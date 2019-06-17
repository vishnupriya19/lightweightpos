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
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("Product/AllProduct/{id}")]
        public JsonResult GetAllProduct(int id)
        {
            return Json(_productRepository.GetAllProducts(id));
        }
        [HttpGet]
        [Route("Product/Product/{merchId}/{prodId}")]
        public JsonResult GetProduct(int merchId, int prodId)
        {
            var prod = _productRepository.GetProduct(merchId, prodId);
            if (prod == null)
                return Json(new object[] { });
            return Json(prod);
        }
        [HttpPost]
        [Route("Product/AddProduct/{merchId}")]
        public JsonResult AddProduct(int merchId, [FromBody]ProductContract productContract)
        {
            var prod = _productRepository.AddProduct(merchId, productContract);
            if (prod == null)
                return Json(new object[] { });
            return Json(prod);
        }
        [HttpDelete]
        [Route("Product/DeleteProduct/{merchId}/{prodId}")]
        public JsonResult DeleteProduct(int merchId, int prodId)
        {
            return Json(_productRepository.DeleteProduct(merchId, prodId));
        }
        [HttpGet]
        [Route("Product/GetAllProductsOfCategory/{merchId}/{catId}")]
        public JsonResult GetAllProductsOfCategory(int merchId, int catId)
        {
            return Json(_productRepository.GetAllProductsOfCategory(merchId, catId));
        }
    }
}