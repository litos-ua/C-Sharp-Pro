﻿using InternetShopApp.Data.Repositories.Interfaces;
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

        //public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        //{
        //    return await _categoryRepository.GetCategoriesWithProductsAsync();
        //}
        public async Task<Category?> GetCategoryWithProductsByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryWithProductsByIdAsync(categoryId);
        }
    }
}

