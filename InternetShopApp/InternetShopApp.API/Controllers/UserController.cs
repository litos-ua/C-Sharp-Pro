using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("User ID mismatch.");

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        // GET: api/User/{id}/Cart
        //[HttpGet("{id}/Cart")]
        //public async Task<IActionResult> GetCartByUserId(int id)
        //{
        //    var cart = await _userService.GetCartByUserIdAsync(id);
        //    if (cart == null)
        //        return NotFound($"Cart for User ID {id} not found.");

        //    return Ok(cart);
        //}

        // GET: api/User/{id}/Orders
        [HttpGet("{id}/Orders")]
        public async Task<IActionResult> GetOrdersByUserId(int id)
        {
            var orders = await _userService.GetOrdersByUserIdAsync(id);
            if (orders == null || !orders.Any())
                return NotFound($"No orders found for User ID {id}.");

            return Ok(orders);
        }
    }
}

