using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public IList<Driver> Clients { get; set; }

        public IList<InstructorCategoryLink> InstructorCategory { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
