using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<Cart?> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }
}

