using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1807E_HelloMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("Full name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }

    }
}