using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLProductRepository : IProductRepository
    {
        private AppDbContext context;

        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public ProductContract AddProduct(int merchId, ProductContract productContract)
        {
            var cat = context.Category.FirstOrDefault(c => c.MerchantId == merchId && c.CategoryId == productContract.CategoryId);
            if (cat == null)
                return null;
            Product prod = new Product();
            prod.Name = productContract.ProductName;
            prod.Unitcost = productContract.UnitCost;
            prod.Sellingprice = productContract.SellingPrice;
            prod.Comission = productContract.Comission;
            prod.CreatedDate = DateTime.Now;
            prod.ModifiedDate = DateTime.Now;
            prod.Rating = productContract.Rating;
            prod.ModifiedUserName = productContract.ModifiedUser;
            prod.MerchantId = merchId;
            prod.CategoryId = productContract.CategoryId;
            context.Product.Add(prod);
            context.SaveChanges();

            productContract.ProductId = prod.ProductId;

            Quantity quantity = new Quantity();
            quantity.ProductId = prod.ProductId;
            quantity.QuantityInStock = productContract.QuantityRemaining;
            quantity.QuantitySold = 0;
            quantity.QuantityRemaining = productContract.QuantityRemaining;
            quantity.MerchantId = merchId;
            context.Quantity.Add(quantity);
            context.SaveChanges();

            productContract.CreatedDate = prod.CreatedDate;
            productContract.ModifiedDate = prod.ModifiedDate;
            productContract.MerchantId = merchId;
            return productContract;
        }

        public Product DeleteProduct(int merchId, int prodId)
        {
            var quantity = context.Quantity.FirstOrDefault(p => p.ProductId == prodId && p.MerchantId == merchId);
            if (quantity != null)
            {
                context.Quantity.Remove(quantity);
                context.SaveChanges();
            }
            var product = context.Product.FirstOrDefault(p => p.ProductId == prodId && p.MerchantId == merchId);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public List<ProductContract> GetAllProducts(int id)
        {
            var prod = context.Product.Include(p => p.Category).Include(p => p.Quantity).Where(p => p.MerchantId == id).ToList();
            var prodData = (from data in prod
                            select new ProductContract
                            {
                                ProductId = data.ProductId,
                                ProductName = data.Name,
                                UnitCost = data.Unitcost,
                                SellingPrice = data.Sellingprice,
                                Comission = data.Comission,
                                Rating = data.Rating,
                                CreatedDate = data.CreatedDate,
                                ModifiedDate = data.ModifiedDate,
                                ModifiedUser = data.ModifiedUserName,
                                CategoryId = data.CategoryId,
                                MerchantId = data.MerchantId,
                                QuantityRemaining = data.Quantity.QuantityRemaining
                            }).ToList();
            return prodData;
        }

        public List<ProductContract> GetAllProductsOfCategory(int merchId, int catId)
        {
            var prod = context.Product.Include(p => p.Category).Include(p => p.Quantity).Where(p => p.MerchantId == merchId && p.CategoryId == catId).ToList();
            var prodData = (from data in prod
                            select new ProductContract
                            {
                                ProductId = data.ProductId,
                                ProductName = data.Name,
                                UnitCost = data.Unitcost,
                                SellingPrice = data.Sellingprice,
                                Comission = data.Comission,
                                Rating = data.Rating,
                                CreatedDate = data.CreatedDate,
                                ModifiedDate = data.ModifiedDate,
                                ModifiedUser = data.ModifiedUserName,
                                CategoryId = data.CategoryId,
                                MerchantId = data.MerchantId,
                                QuantityRemaining = data.Quantity.QuantityRemaining
                            }).ToList();
            return prodData;
        }

        public ProductContract GetProduct(int merchId, int prodId)
        {
            var prod = context.Product.Include(p => p.Category).Include(p => p.Quantity).FirstOrDefault(p => p.MerchantId == merchId && p.ProductId == prodId);
            if (prod != null)
            {
                ProductContract productContract = new ProductContract();
                productContract.ProductId = prod.ProductId;
                productContract.ProductName = prod.Name;
                productContract.UnitCost = prod.Unitcost;
                productContract.SellingPrice = prod.Sellingprice;
                productContract.Comission = prod.Comission;
                productContract.Rating = prod.Rating;
                productContract.CreatedDate = prod.CreatedDate;
                productContract.ModifiedDate = prod.ModifiedDate;
                productContract.ModifiedUser = prod.ModifiedUserName;
                productContract.CategoryId = prod.CategoryId;
                productContract.MerchantId = prod.MerchantId;
                productContract.QuantityRemaining = prod.Quantity.QuantityRemaining;
                return productContract;
            }
            return null;
        }
    }
}
