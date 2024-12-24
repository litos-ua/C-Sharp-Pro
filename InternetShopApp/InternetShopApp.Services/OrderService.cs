using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersWithItemsAsync()
        {
            return await _orderRepository.GetOrdersWithItemsAsync();
        }

        public async Task<Order?> GetOrderWithItemsByIdAsync(int id)
        {
            return await _orderRepository.GetOrderWithItemsByIdAsync(id);
        }
    }
}

