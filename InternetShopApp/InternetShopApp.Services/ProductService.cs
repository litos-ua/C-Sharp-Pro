using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services;

namespace InternetShopApp.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _productRepository.GetProductsByNameAsync(name);
        }
    }
}

