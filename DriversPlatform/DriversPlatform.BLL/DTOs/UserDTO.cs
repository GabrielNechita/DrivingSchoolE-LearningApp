using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DriversPlatform.BLL.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
