using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;
//using InternetShopApp.Data.Entities;

namespace InternetShopApp.Services
{
    public class CartItemService : GenericService<CartItem>, ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository) : base(cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
        }
    }

}
