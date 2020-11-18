using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Common.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductAsync(int id);

        IQueryable GetProducts();

        Task<string> AddProductAsync(Product view);

        Task<string> EditProductAsync(Product view, string path, User user);

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
