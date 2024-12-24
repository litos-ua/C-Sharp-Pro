using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;

namespace InternetShopApp.Services
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<IEnumerable<Order>> GetOrdersWithItemsAsync();
        Task<Order?> GetOrderWithItemsByIdAsync(int id);
    }
}

