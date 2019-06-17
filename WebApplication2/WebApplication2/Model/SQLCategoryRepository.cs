using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public CategoryContract AddCategory(int merchId, CategoryContract categoryContract)
        {
            Category category = new Category();
            category.Name = categoryContract.Name;
            category.Description = categoryContract.Description;
            category.MerchantId = merchId;
            context.Category.Add(category);
            context.SaveChanges();
            categoryContract.CategoryId = category.CategoryId;
            categoryContract.MerchantId = merchId;
            return categoryContract;
        }

        public Category DeleteCategory(int merchId, int catId)
        {
            var prod = context.Product.Where(p => p.MerchantId == merchId && p.CategoryId == catId);
            if (prod != null)
            {
                foreach (var prods in prod)
                {
                    var quant = context.Quantity.Where(p => p.ProductId == prods.ProductId);
                    if (quant != null)
                    {
                        context.Quantity.RemoveRange(quant);
                        context.SaveChanges();
                    }
                }
                context.Product.RemoveRange(prod);
                context.SaveChanges();
            }
            var cat = context.Category.FirstOrDefault(c => c.MerchantId == merchId && c.CategoryId == catId);
            if (cat != null)
            {
                context.Category.Remove(cat);
                context.SaveChanges();
            }
            return cat;
        }

        public List<CategoryContract> GetAllCategory(int id)
        {
            var cat = context.Category.Where(c => c.MerchantId == id).ToList();
            var categoryData = (from data in cat
                                select new CategoryContract
                                {
                                    CategoryId = data.CategoryId,
                                    Name = data.Name,
                                    Description = data.Description,
                                    MerchantId = data.MerchantId
                                }).ToList();
            return categoryData;

        }

        public CategoryContract GetCategory(int merchId, int catId)
        {
            var cat = context.Category.FirstOrDefault(c => c.MerchantId == merchId && c.CategoryId == catId);
            if (cat != null)
            {
                CategoryContract categoryContract = new CategoryContract();
                categoryContract.CategoryId = cat.CategoryId;
                categoryContract.Name = cat.Name;
                categoryContract.Description = cat.Description;
                categoryContract.MerchantId = cat.MerchantId;
                return categoryContract;
            }
            return null;
        }
    }
}
