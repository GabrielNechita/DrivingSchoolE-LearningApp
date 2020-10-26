using DriversPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriversPlatform.DAL.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly DatabaseContext _context;

        public InstructorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddInstructor(Instructor newInstructor, IEnumerable<Category> categories)
        {
            newInstructor.InstructorCategory = new List<InstructorCategoryLink>();
            foreach (var category in categories)
            {
                var categoryFromDb = _context.Categories.FirstOrDefault(c => c.Name == category.Name);
                newInstructor.InstructorCategory.Add(
                    new InstructorCategoryLink
                    {
                        Instructor = newInstructor,
                        Category = categoryFromDb
                    });
            }


            _context.Instructors.Add(newInstructor);
            _context.SaveChanges();
        }

        public void DeleteInstructor(int instructorId)
        {
            var instructorFromDb = _context.Instructors.Include(d => d.User).Include(d => d.Clients).FirstOrDefault(d => d.Id == instructorId);
            foreach (var driver in instructorFromDb.Clients)
            {
                driver.Instructor = null;
                driver.InstructorId = null;
            }
            _context.Users.Remove(instructorFromDb.User);
            _context.SaveChanges();
        }

        public Instructor GetInstructorByUserId(string userId)
        {
            return _context.Instructors
                .Include(d => d.User)
                .Include(d => d.Clients)
                .ThenInclude(c => c.User)
                .Include(i => i.InstructorCategory)
                .ThenInclude(i => i.Category)
                .FirstOrDefault(d => d.User.Id == userId);
        }

        public List<Instructor> GetInstructors()
        {
            return _context.Instructors
                .Include(i => i.User)
                .Include(i => i.InstructorCategory)
                .ThenInclude(i => i.Category)
                .ToList();
        }

        public List<Instructor> GetInstructorsByCategory(string category)
        {
            var resultTable = _context.Instructors.Include(i => i.User).Include(i => i.InstructorCategory).ThenInclude(i => i.Category);
            return resultTable.Where(i => i.InstructorCategory.Any(ic => ic.Category.Name == category)).ToList();
        }

        public void GiveQuizAccess(int? driverId)
        {
            _context.Drivers.FirstOrDefault(d => d.Id == driverId).HasQuizAccess = true;
            _context.SaveChanges();
        }

        public void UpdateInstructor(Instructor instructor, IList<Category> categories)
        {
            var instructorFromDb = _context.Instructors
                .Include(i => i.User)
                .Include(i => i.InstructorCategory)
                .ThenInclude(i => i.Category)
                .FirstOrDefault(i => i.Id == instructor.Id);

            if (instructorFromDb.InstructorCategory == null)
            {
                instructorFromDb.InstructorCategory = new List<InstructorCategoryLink>();
            }

            foreach (var instrCat in instructorFromDb.InstructorCategory)
            {
                var cat = categories.FirstOrDefault(c => c.Id == instrCat.Category.Id);
                if (cat == null)
                {
                    _context.InstructorCategoryLink.Remove(instrCat);
                }
            }

            foreach (var category in categories)
            {
                var instrCat = instructorFromDb.InstructorCategory.FirstOrDefault(ic => ic.Category.Id == category.Id);

                if (instrCat == null)
                {
                    instructorFromDb.InstructorCategory.Add(
                        new InstructorCategoryLink
                        {
                            Instructor = instructorFromDb,
                            Category = category
                        }
                    );
                }
            }

            instructorFromDb.User.FirstName = instructor.User.FirstName;
            instructorFromDb.User.LastName = instructor.User.LastName;
            instructorFromDb.User.Address = instructor.User.Address;
            instructorFromDb.User.Birthday = instructor.User.Birthday;
            instructorFromDb.User.PhoneNumber = instructor.User.PhoneNumber;
            instructorFromDb.User.Gender = instructor.User.Gender;
            instructorFromDb.HireDate = instructor.HireDate;
            instructorFromDb.Salary = instructor.Salary;
            _context.SaveChanges();
            
        }
    }
}
