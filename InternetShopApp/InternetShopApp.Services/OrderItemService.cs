using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;
//using InternetShopApp.Data.Entities;

namespace InternetShopApp.Services
{
    public class OrderItemService : GenericService<OrderItem>, IOrderItemService
    {

        private readonly IOrderItemRepository _repository;
        private readonly IProductRepository _productRepository;

        public OrderItemService(
            IOrderItemRepository repository,
            IProductRepository productRepository) : base(repository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }


        public async Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem)
        {
            var existingOrderItem = await _repository.GetByIdAsync(orderItem.Id);
            if (existingOrderItem == null)
            {
                throw new KeyNotFoundException($"OrderItem with ID {orderItem.Id} not found.");
            }

            var product = await _productRepository.GetByIdAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            orderItem.Price = product.Price; 
            orderItem.Total = product.Price * orderItem.Quantity; // Calculation Total

            //await _repository.UpdateAsync(orderItem);
            await _repository.EditOrderItemAsync(orderItem);

            return orderItem;
        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            // Receiving a product to determine the price
            var product = await _productRepository.GetByIdAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            orderItem.Price = product.Price;
            orderItem.Total = product.Price * orderItem.Quantity;

            return await _repository.AddAsync(orderItem);
        }
    }

}
