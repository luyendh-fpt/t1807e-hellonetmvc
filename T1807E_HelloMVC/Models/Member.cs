using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1807E_HelloMVC.Models
{
    public class Member
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password length must be 6 to 30 characters!")]
        public string Password { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; } // 1. Active | 0. Deactive | -1. Deleted

        public enum MemberStatus { Active = 1, Deactive = 0, Deleted = -1 };

        public static void Main(string[] args)
        {
            Console.Write("Hello");
        }

    }

}