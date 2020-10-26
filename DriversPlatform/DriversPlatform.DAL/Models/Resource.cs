using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.DAL.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
    }
}
