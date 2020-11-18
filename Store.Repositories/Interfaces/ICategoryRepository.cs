using Store.Common.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<SelectListItem> GetComboCategories();

        IEnumerable<SelectListItem> GetComboSubcategories(int categoryId);

        Task<Category> GetCategoryAsync(Subcategory subcategory);

        IQueryable GetCategoriesWithSub();

        Task<Category> GetCategoriesWithSubAsync(int id);

        Task<Subcategory> GetSubAsync(int id);

        Task AddSubAsync(int id, string name);

        Task<int> UpdateSubAsync(Subcategory subcategory);

        Task<int> DeleteSubAsync(Subcategory subcategory);

        Task<Category> EditCategoryAsync(int id, string name, string path, User user);
    }
}
