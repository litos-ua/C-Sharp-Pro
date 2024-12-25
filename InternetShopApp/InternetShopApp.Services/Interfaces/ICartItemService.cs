using InternetShopApp.Domain.Entities;
//using InternetShopApp.Data.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface ICartItemService : IGenericService<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
    }
}
