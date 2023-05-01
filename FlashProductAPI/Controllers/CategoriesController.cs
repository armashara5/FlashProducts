using FlashProductAPI_7.Services;
using FlashProductAPI_7.Services.ServicesModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService? _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            if (_categoryService == null)
            {
                return NotFound();
            }
            IEnumerable<CategoryDTO>? categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<CategoryDTO>>(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO?>> GetProduct(int id)
        {
            if (_categoryService == null)
            {
                return NotFound();
            }
            CategoryDTO? category = await _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [Route("categories/{categoryId}/products")]
        // GET: api/Category/5/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsInCategory(int categoryId)
        {
            if (_categoryService == null)
            {
                return NotFound();
            }
            IEnumerable<ProductDTO>? products = await _categoryService.GetProductsInCategory(categoryId);
            if (products == null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<ProductDTO>>(products);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_categoryService == null)
            {
                return NotFound();
            }
            try
            {
                var product = await _categoryService.DeleteCategory(id);
                if (product == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
