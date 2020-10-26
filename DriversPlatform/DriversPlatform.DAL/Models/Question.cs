using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Difficulty { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<Answer> Answers { get; set; }

        public byte[] Image { get; set; }
    }
}
