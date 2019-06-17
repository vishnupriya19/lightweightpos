using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface IProductRepository
    {
        List<ProductContract> GetAllProducts(int id);
        ProductContract GetProduct(int merchId, int prodId);
        ProductContract AddProduct(int merchId, ProductContract product);
        Product DeleteProduct(int merchId, int prodId);
        List<ProductContract> GetAllProductsOfCategory(int merchId, int catId);
    }
}
 