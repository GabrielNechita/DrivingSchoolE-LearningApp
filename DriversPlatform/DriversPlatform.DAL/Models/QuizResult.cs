using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class QuizResult
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Difficulty { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey("DriverId")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
