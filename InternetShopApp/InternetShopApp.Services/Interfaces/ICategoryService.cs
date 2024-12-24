using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
    }
}

