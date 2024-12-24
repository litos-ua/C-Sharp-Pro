using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var existingProduct = await _productService.GetByIdAsync(id);
            //if (existingProduct == null)
            //    return NotFound($"Product with ID {id} not found.");

            // Update the product
            product.Id = id;
            await _productService.UpdateAsync(product);

            return NoContent();
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with ID {id} not found.");

            await _productService.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/Product/ByCategory/{categoryId}
        [HttpGet("ByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId);
            if (products == null || !products.Any())
                return NotFound($"No products found for category ID {categoryId}.");

            return Ok(products);
        }

        // GET: api/Product/ByName/{name}
        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Product name cannot be null or empty.");

            var products = await _productService.GetProductsByNameAsync(name);
            if (products == null || !products.Any())
                return NotFound($"No products found with name containing '{name}'.");

            return Ok(products);
        }

    }
}

