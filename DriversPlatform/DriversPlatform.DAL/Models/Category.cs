using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<InstructorCategoryLink> InstructorCategory { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
