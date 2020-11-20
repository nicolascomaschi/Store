
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Data.Entities;
using Store.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Store.Backend.Controllers.API
{
	[Route("api/[Controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IUserRepository _userRepository;
		private readonly IProductRepository _productRepository;

		public OrdersController(IOrderRepository orderRepository,
			IUserRepository userRepository,
			IProductRepository productRepository)
		{
			_orderRepository = orderRepository;
			_userRepository = userRepository;
			_productRepository = productRepository;
		}

		[HttpPost]
		public async Task<IActionResult> PostShoppingCart([FromBody] ShoppingCart shoppingCart)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			var user = await this._userRepository.GetUserByUserNameAsync(shoppingCart.User.UserName);
			if (user == null)
			{
				return this.BadRequest("Usuario Invalido");
			}

			var product = await this._productRepository.GetProductAsync(shoppingCart.Product.Id);
			if (product == null)
			{
				return this.BadRequest("Producto Invalido");
			}

			shoppingCart.User = user;
			shoppingCart.Product = product;
			return Ok(await this._orderRepository.AddProductToCartAPIAsync(shoppingCart));
		}

		[HttpPut]
		[Route("CartIncrease/{id}")]
		public async Task<IActionResult> PutCartIncrease([FromRoute] int id, [FromBody] ShoppingCart shoppingCart)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			if (id != shoppingCart.Id)
			{
				return BadRequest();
			}

			var oldCart = await this._orderRepository.GetCartByIdAsync(id);
			if (oldCart == null)
			{
				return this.BadRequest("El producto no existe.");
			}

			var updatedCart = await this._orderRepository.ModifyCartQuantityAsync(oldCart.Id, 1);
			return Ok(updatedCart);
		}

		[HttpPut]
		[Route("CartDecrease/{id}")]
		public async Task<IActionResult> PutCartDecrease([FromRoute] int id, [FromBody] ShoppingCart shoppingCart)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			if (id != shoppingCart.Id)
			{
				return BadRequest();
			}

			var oldCart = await this._orderRepository.GetCartByIdAsync(id);
			if (oldCart == null)
			{
				return this.BadRequest("El producto no existe.");
			}

			var updatedCart = await this._orderRepository.ModifyCartQuantityAsync(oldCart.Id, -1);
			return Ok(updatedCart);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteItemCart([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ShoppingCart shoppingCart = await _orderRepository.GetCartByIdAsync(id);
			if (shoppingCart == null)
			{
				return NotFound();
			}

			await _orderRepository.DeleteCartAsync(shoppingCart.Id);
			return Ok(shoppingCart);
		}

		[HttpPost]
		[Route("ConfirmOrder")]
		public async Task<IActionResult> ConfirmOrder([FromBody] User user)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			return Ok(await _orderRepository.ConfirmOrderAsync(user.UserName));
		}
	}
}
