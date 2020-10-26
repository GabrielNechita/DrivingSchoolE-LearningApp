using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.DTOs
{
    public class DriverDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public Category Category { get; set; }

        public InstructorDTO Instructor { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public bool HasQuizAccess { get; set; }

        public IList<QuizResult> QuizResults { get; set; }
    }
}
