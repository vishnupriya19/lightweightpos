using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface ICategoryRepository
    {
        List<CategoryContract> GetAllCategory(int id);
        CategoryContract GetCategory(int merchId, int catId);
        CategoryContract AddCategory(int merchId, CategoryContract categoryContract);
        Category DeleteCategory(int merchId, int catId);
    }
}
