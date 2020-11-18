using Microsoft.EntityFrameworkCore;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Resources;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboCategories()
        {
            var list = this.context.Categories.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(c => c.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = Strings.ComboCategory,
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboSubcategories(int categoryId)
        {
            var category = this.context.Categories.Find(categoryId);
            var list = new List<SelectListItem>();
            if (category != null)
            {
                list = category.Subcategories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).OrderBy(l => l.Text).ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = Strings.ComboSubcategory,
                Value = "0"
            });

            return list;
        }

        public async Task<Category> GetCategoryAsync(Subcategory subcategory)
        {
            return await this.context.Categories.Where(c => c.Subcategories.Any(ci => ci.Id == subcategory.Id)).FirstOrDefaultAsync();
        }

        public async Task AddSubAsync(int id, string name)
        {
            var category = await this.GetCategoriesWithSubAsync(id);
            if (category == null)
            {
                return;
            }

            category.Subcategories.Add(new Subcategory { Name = name });
            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteSubAsync(Subcategory subcategory)
        {
            var category = await this.context.Categories.Where(c => c.Subcategories.Any(ci => ci.Id == subcategory.Id)).FirstOrDefaultAsync();
            if (category == null)
            {
                return 0;
            }

            this.context.Subcategories.Remove(subcategory);
            await this.context.SaveChangesAsync();
            return category.Id;
        }

        public IQueryable GetCategoriesWithSub()
        {
            return this.context.Categories
                .Include(c => c.Subcategories)
                .OrderBy(c => c.Name);
        }

        public async Task<Category> GetCategoriesWithSubAsync(int id)
        {
            return await this.context.Categories
                .Include(c => c.Subcategories)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateSubAsync(Subcategory subcategory)
        {
            var category = await this.context.Categories.Where(c => c.Subcategories.Any(ci => ci.Id == subcategory.Id)).FirstOrDefaultAsync();
            if (category == null)
            {
                return 0;
            }

            this.context.Subcategories.Update(subcategory);
            await this.context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<Subcategory> GetSubAsync(int id)
        {
            return await this.context.Subcategories.FindAsync(id);
        }

        public async Task<Category> EditCategoryAsync(int id, string name, string path, User user)
        {
            var category = await this.context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return null;
            }

            category.ImageUrl = path;
            category.Name = name;
            category.User = user;

            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
            return category;
        }
    }
}
