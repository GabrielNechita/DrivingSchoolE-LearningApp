using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.BLL.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category newCategory);
        List<Category> GetCategories();
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
    }
}