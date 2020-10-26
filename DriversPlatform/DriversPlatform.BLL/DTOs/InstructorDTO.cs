using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.DTOs
{
    public class InstructorDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }

        public DateTime HireDate { get; set; }

        public int Salary { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<DriverDTO> Clients { get; set; }
    }
}
