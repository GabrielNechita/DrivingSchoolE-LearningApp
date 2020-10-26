using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.BLL.Services
{
    public interface IDriverService
    {
        void AddDriver(Driver newDriver);
        Driver GetDriverByUserId(string id);
        void UpdateDriver(Driver driver);
        void AddCategoryToDriver(int driverId, string categoryName);
        void AddInstructorToDriver(int driverId, int instructorId);
        List<Driver> GetDrivers();
        void DeleteDriver(int driverId);
        List<Question> GetQuizByCategory(int categoryId);
        List<Question> GetQuizByDifficultyAndCategory(string difficulty, int categoryId);
        void AddQuizResult(QuizResult result);
    }
}