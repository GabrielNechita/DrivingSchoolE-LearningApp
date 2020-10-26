using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.DAL.Repository
{
    public interface ICategoryRepository
    {
        void AddCategory(Category newCategory);
        List<Category> GetCategories();
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
    }
}