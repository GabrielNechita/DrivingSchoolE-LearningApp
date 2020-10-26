using DriversPlatform.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DriversPlatform.DAL.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DatabaseContext _context;

        public DriverRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddCategoryToDriver(int driverId, string categoryName)
        {
            var driverFromDb = _context.Drivers.FirstOrDefault(d => d.Id == driverId);
            var categoryFromDb = _context.Categories.FirstOrDefault(c => c.Name == categoryName);

            driverFromDb.Category = categoryFromDb;
            driverFromDb.CategoryId = categoryFromDb.Id;
            _context.SaveChanges();
        }

        public void AddDriver(Driver newDriver)
        {
            _context.Drivers.Add(newDriver);
            _context.SaveChanges();
        }

        public void AddInstructorToDriver(int driverId, int instructorId)
        {
            var driverFromDb = _context.Drivers.FirstOrDefault(d => d.Id == driverId);
            var instructorFromDb = _context.Instructors.FirstOrDefault(i => i.Id == instructorId);

            driverFromDb.Instructor = instructorFromDb;
            driverFromDb.InstructorId = instructorFromDb.Id;
            driverFromDb.HasQuizAccess = false;
            _context.SaveChanges();
        }

        public void AddQuizResult(QuizResult result)
        {
            _context.QuizResults.Add(result);
            _context.SaveChanges();
        }

        public void DeleteDriver(int driverId)
        {
            var driverFromDb = _context.Drivers.Include(d => d.User).FirstOrDefault(d => d.Id == driverId);
            
            _context.Users.Remove(driverFromDb.User);
            _context.SaveChanges();
        }

        public Driver GetDriverByUserId(string id)
        {
            return _context.Drivers
                .Include(d => d.QuizResults)
                .Include(d => d.User)
                .Include(d => d.Category)
                .Include(d => d.Instructor)
                .ThenInclude(i=>i.User)
                .FirstOrDefault(d => d.UserId == id);
        }

        public List<Driver> GetDrivers()
        {
            return _context.Drivers.Include(d => d.User).Include(d => d.Category).Include(d => d.Instructor).ThenInclude(i => i.User).ToList();
        }

        public void UpdateDriver(Driver driver)
        {
            var driverFromDb = _context.Drivers.Include(d => d.User).FirstOrDefault(d => d.Id == driver.Id);
            var userFromDb = driverFromDb.User;
            userFromDb.FirstName = driver.User.FirstName;
            userFromDb.LastName = driver.User.LastName;
            userFromDb.Birthday = driver.User.Birthday;
            userFromDb.Address = driver.User.Address;
            userFromDb.PhoneNumber = driver.User.PhoneNumber;
            _context.SaveChanges();

        }
    }
}
