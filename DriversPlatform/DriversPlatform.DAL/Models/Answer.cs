using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public bool IsCorrect { get; set; }

        [Required]
        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
