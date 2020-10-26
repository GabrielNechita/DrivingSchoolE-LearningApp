using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.BLL.Services
{
    public interface IInstructorService
    {
        void AddInstructor(Instructor newInstructor, IEnumerable<Category> categories);
        List<Instructor> GetInstructorsByCategory(string category);
        List<Instructor> GetInstructors();
        void DeleteInstructor(int instructorId);
        void UpdateInstructor(Instructor instructor, IList<Category> categories);
        Instructor GetInstructorByUserId(string userId);
        void GiveQuizAccess(int? driverId);
    }
}