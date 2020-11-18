using Microsoft.EntityFrameworkCore;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository _userRepository;

        public OrderRepository(DataContext context, IUserRepository userRepository) : base(context)
        {
            this.context = context;
            this._userRepository = userRepository;
        }

        public async Task<bool> ConfirmOrderAsync(string userName)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return false;
            }

            var cart = await this.context.ShoppingCarts
                .Include(o => o.Product)
                .Where(o => o.User == user)
                .ToListAsync();

            if (cart == null || cart.Count == 0)
            {
                return false;
            }

            var details = cart.Select(o => new OrderDetail
            {
                Price = o.Price,
                Product = o.Product,
                Quantity = o.Quantity
            }).ToList();

            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                User = user,
                Items = details,
                Status = "Creado",
            };

            this.context.Orders.Add(order);
            this.context.ShoppingCarts.RemoveRange(cart);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCartAsync(int id)
        {
            var cart = await this.context.ShoppingCarts.FindAsync(id);
            if (cart == null)
            {
                return;
            }

            this.context.ShoppingCarts.Remove(cart);
            await this.context.SaveChangesAsync();
        }

        public async Task AddItemToOrderAsync(int productId, double quantity, string userName)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return;
            }

            var product = await this.context.Products.FindAsync(productId);
            if (product == null)
            {
                return;
            }

            var cart = await this.context.ShoppingCarts
                .Where(odt => odt.User == user && odt.Product == product)
                .FirstOrDefaultAsync();
            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    Price = (decimal)product.Price,
                    Product = product,
                    Quantity = quantity,
                    User = user,
                    Discount = (decimal)product.Discount,
                };

                this.context.ShoppingCarts.Add(cart);
            }
            else
            {
                cart.Quantity += quantity;
                this.context.ShoppingCarts.Update(cart);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> ModifyCartQuantityAsync(int id, double quantity)
        {
            var shoppingCart = await this.context.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return null;
            }

            shoppingCart.Quantity += quantity;
            if (shoppingCart.Quantity > 0)
            {
                this.context.ShoppingCarts.Update(shoppingCart);
                await this.context.SaveChangesAsync();
                return shoppingCart;
            }
            return shoppingCart;
        }

        public async Task<IQueryable<ShoppingCart>> GetCartAsync(string userName)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return null;
            }

            return this.context.ShoppingCarts
                .Include(o => o.Product)
                .Where(o => o.User == user)
                .OrderBy(o => o.Product.Name);
        }

        public async Task<IQueryable<Order>> GetOrdersAsync(string userName)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this._userRepository.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            return this.context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }

        public async Task<Order> GetOrderWithDetailAsync(int id, string userName)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this._userRepository.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }

            return this.context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User == user && o.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Order> GetOrderWithDetailAsync()
        {
            return this.context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate);
        }

        public async Task<ShoppingCart> AddProductToCartAPIAsync(ShoppingCart model)
        {
            var user = await this._userRepository.GetUserByUserNameAsync(model.User.UserName);
            if (user == null)
            {
                return null;
            }

            var product = await this.context.Products.FindAsync(model.Product.Id);
            if (product == null)
            {
                return null;
            }

            var cart = await this.context.ShoppingCarts
                .Where(c => c.User == user && c.Product == product)
                .FirstOrDefaultAsync();
            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    Price = (decimal)product.Price,
                    Product = product,
                    Quantity = model.Quantity,
                    User = user,
                    Discount = (decimal)product.Discount,
                };

                this.context.ShoppingCarts.Add(cart);
            }
            else
            {
                cart.Quantity += model.Quantity;
                this.context.ShoppingCarts.Update(cart);
            }

            await this.context.SaveChangesAsync();
            return cart;
        }

        public async Task<ShoppingCart> GetCartByIdAsync(int id)
        {
            var cart = await this.context.ShoppingCarts.FindAsync(id);
            if (cart == null)
            {
                return null;
            }

            return cart;
        }
    }
}
