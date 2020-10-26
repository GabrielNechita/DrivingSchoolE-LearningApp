using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.DAL.Repository
{
    public interface IDriverRepository
    {
        void AddDriver(Driver newDriver);
        Driver GetDriverByUserId(string id);
        void UpdateDriver(Driver driver);
        void AddCategoryToDriver(int driverId, string categoryName);
        void AddInstructorToDriver(int driverId, int instructorId);
        List<Driver> GetDrivers();
        void DeleteDriver(int driverId);
        void AddQuizResult(QuizResult result);
    }
}