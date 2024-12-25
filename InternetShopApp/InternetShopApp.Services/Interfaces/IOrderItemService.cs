﻿using InternetShopApp.Domain.Entities;
//using InternetShopApp.Data.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface IOrderItemService : IGenericService<OrderItem>
    {
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem);
    }

}