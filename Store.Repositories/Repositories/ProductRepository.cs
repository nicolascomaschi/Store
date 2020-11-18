using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Resources;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = this.context.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = Strings.comboProduct,
                Value = "0"
            });

            return list;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await this.context.Products
                .Include(o => o.Brand)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(p => p.Presentation)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return product;
        }

        public IQueryable GetProducts()
        {
            return this.context.Products
                .Include(o => o.Brand)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(p => p.Presentation)
                .Include(u => u.User)
                .OrderBy(pr => pr.DateCration);
        }

        public async Task<string> AddProductAsync(Product view)
        {
            var product = await this.context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(odt => odt.Name == view.Name)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                this.context.Products.Add(product);
                await this.context.SaveChangesAsync();
                return Strings.MsjSuccess;
            }

            return Strings.ErrorDuplicateRecord;
        }

        public async Task<string> EditProductAsync(Product model, string path, User user)
        {
            var product = await this.context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(o => o.Id == model.Id)
                .FirstOrDefaultAsync();

            this.context.Products.Update(product);
            await this.context.SaveChangesAsync();
            return Strings.MsjSuccess;
        }
    }
}
