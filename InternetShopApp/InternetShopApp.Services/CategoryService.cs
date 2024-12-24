using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await _categoryRepository.GetCategoriesWithProductsAsync();
        }
    }
}

