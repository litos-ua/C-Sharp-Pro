using Microsoft.AspNetCore.Mvc;
using InternetShopApp.Domain.Entities;
//using InternetShopApp.Data.Entities;
using InternetShopApp.Services.Interfaces;

namespace InternetShopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            if (stock == null)
                return NotFound();

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _stockService.AddAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != stock.Id)
                return BadRequest();

            await _stockService.UpdateAsync(stock);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            if (stock == null)
                return NotFound();

            await _stockService.DeleteAsync(id);
            return NoContent();
        }
    }
}

