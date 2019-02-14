using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace myLibrary.Model
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool IsValid { get; set; }
    }
}
