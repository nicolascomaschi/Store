using Microsoft.EntityFrameworkCore;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly DataContext _dataContext;

        public ShopRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Product> GetProducts()
        {
            return _dataContext.Products
                .Include(o => o.Brand)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(p => p.Presentation)
                .OrderBy(pr => pr.DateCration).ToList();
        }

        public List<Product> GetProducts(string category)
        {
            return _dataContext.Products
                .Include(o => o.Brand)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(p => p.Presentation)
                .Where(p => p.Category.Name == category)
                .OrderBy(pr => pr.DateCration).ToList();
        }

        public async Task<Product> GetProductAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var product = await _dataContext.Products
                .Include(o => o.Brand)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(p => p.Presentation)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return product;
        }
    }
}
