using Store.Common.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces
{
    public interface IShopRepository
    {
        List<Product> GetProducts();

        List<Product> GetProducts(string category);

        Task<Product> GetProductAsync(int? id);
    }
}
