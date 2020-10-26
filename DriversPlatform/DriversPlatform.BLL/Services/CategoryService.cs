using DriversPlatform.DAL.Models;
using DriversPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public void AddCategory(Category newCategory)
        {
            _categoryRepository.AddCategory(newCategory);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}
