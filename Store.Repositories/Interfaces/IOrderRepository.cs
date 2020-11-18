using Store.Common.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersAsync(string userName);

        Task<IQueryable<ShoppingCart>> GetCartAsync(string userName);

        Task AddItemToOrderAsync(int productId, double quantity, string userName);

        Task<ShoppingCart> ModifyCartQuantityAsync(int id, double quantity);

        Task DeleteCartAsync(int id);

        Task<bool> ConfirmOrderAsync(string userName);

        Task<Order> GetOrderWithDetailAsync(int id, string userName);

        IQueryable<Order> GetOrderWithDetailAsync();

        Task<ShoppingCart> AddProductToCartAPIAsync(ShoppingCart model);

        Task<ShoppingCart> GetCartByIdAsync(int id);
    }
}
