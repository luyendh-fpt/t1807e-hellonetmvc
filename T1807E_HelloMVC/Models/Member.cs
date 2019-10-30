using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1807E_HelloMVC.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; } // 1. Active | 0. Deactive | -1. Deleted

        public enum MemberStatus { Active = 1, Deactive = 0, Deleted = -1 };

    }

}