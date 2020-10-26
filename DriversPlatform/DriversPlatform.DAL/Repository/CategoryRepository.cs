using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriversPlatform.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            _context.SaveChanges();
        }
    }
}
