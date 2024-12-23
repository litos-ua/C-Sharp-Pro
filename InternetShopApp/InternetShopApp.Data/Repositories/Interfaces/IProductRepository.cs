﻿using InternetShopApp.Domain.Entities;


namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}