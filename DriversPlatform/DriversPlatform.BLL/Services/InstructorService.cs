using System;
using System.Collections.Generic;
using System.Text;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using DriversPlatform.DAL.Repository;

namespace DriversPlatform.BLL.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void AddInstructor(Instructor newInstructor, IEnumerable<Category> categories)
        {
            _instructorRepository.AddInstructor(newInstructor, categories);
        }

        public void DeleteInstructor(int instructorId)
        {
            _instructorRepository.DeleteInstructor(instructorId);
        }

        public Instructor GetInstructorByUserId(string userId)
        {
            return _instructorRepository.GetInstructorByUserId(userId);
        }

        public List<Instructor> GetInstructors()
        {
            return _instructorRepository.GetInstructors();
        }

        public List<Instructor> GetInstructorsByCategory(string category)
        {
            return _instructorRepository.GetInstructorsByCategory(category);
        }

        public void GiveQuizAccess(int? driverId)
        {
            _instructorRepository.GiveQuizAccess(driverId);
        }

        public void UpdateInstructor(Instructor instructor, IList<Category> categories)
        {
            _instructorRepository.UpdateInstructor(instructor, categories);
        }
    }
}
