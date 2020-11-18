using Microsoft.AspNetCore.Mvc;
using Store.Repositories.Interfaces;

namespace Store.Backend.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return this.Ok(this._categoryRepository.GetCategoriesWithSub());
        }
    }
}
