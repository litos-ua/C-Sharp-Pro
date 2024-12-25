using InternetShopApp.Services;
using InternetShopApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet] //GET: api/Category
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")] // GET: api/Category/{id}
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("with-products")] // GET: api/Category/with-products
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            var categories = await _categoryService.GetCategoriesWithProductsAsync();
            return Ok(categories);
        }

        [HttpPost] // POST: api/Category
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")] // PUT: api/Category/{id}
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            await _categoryService.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")] // DELITE: api/Category/{id}
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}


