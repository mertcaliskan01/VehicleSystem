using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace myLibrary.Model
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }
        public string name { get; set; }
        public string nickName { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public string plate { get; set; }
        public string modelYear { get; set; }
        public string vehicleType { get; set; }
        public string color { get; set; }
        public bool IsActive { get; set; } 



    }
}
