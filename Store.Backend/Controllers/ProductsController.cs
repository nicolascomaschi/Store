using Microsoft.AspNetCore.Mvc;
using Store.Repositories.Interfaces;

namespace Store.Backend.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return this.Ok(this._productRepository.GetProducts());
        }

    }
}
