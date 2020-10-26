using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class InstructorCategoryLink
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
