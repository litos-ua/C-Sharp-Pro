using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services
{
    public class CartService : GenericService<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository) : base(cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<Cart>> GetCartsByProductIdAsync(int productId)
        {
            return await _cartRepository.GetCartsByProductIdAsync(productId);
        }
    }
}

