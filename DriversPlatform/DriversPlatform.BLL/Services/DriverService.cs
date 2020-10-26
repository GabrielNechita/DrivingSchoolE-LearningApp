using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using DriversPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IQuestionRepository _questionRepository;

        public DriverService(IDriverRepository driverRepository, IQuestionRepository questionRepository)
        {
            _driverRepository = driverRepository;
            _questionRepository = questionRepository;
        }

        public void AddCategoryToDriver(int driverId, string categoryName)
        {
            _driverRepository.AddCategoryToDriver(driverId, categoryName);
        }

        public void AddDriver(Driver newDriver)
        {
            _driverRepository.AddDriver(newDriver);
        }

        public void AddInstructorToDriver(int driverId, int instructorId)
        {
            _driverRepository.AddInstructorToDriver(driverId, instructorId);
        }

        public void AddQuizResult(QuizResult result)
        {
            _driverRepository.AddQuizResult(result);
        }

        public void DeleteDriver(int driverId)
        {
            _driverRepository.DeleteDriver(driverId);
        }

        public Driver GetDriverByUserId(string id)
        {
            return _driverRepository.GetDriverByUserId(id);
        }

        public List<Driver> GetDrivers()
        {
            return _driverRepository.GetDrivers();
        }

        public List<Question> GetQuizByCategory(int categoryId)
        {
            return _questionRepository.GetQuizByCategory(categoryId);
        }

        public List<Question> GetQuizByDifficultyAndCategory(string difficulty, int categoryId)
        {
            return _questionRepository.GetQuizByDifficultyAndCategory(difficulty, categoryId);
        }

        public void UpdateDriver(Driver driver)
        {
            _driverRepository.UpdateDriver(driver);
        }
    }
}
