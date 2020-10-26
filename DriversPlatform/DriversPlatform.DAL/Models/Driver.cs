using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("InstructorId")]
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public bool HasQuizAccess { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

        public IList<QuizResult> QuizResults { get; set; }

    }
}
