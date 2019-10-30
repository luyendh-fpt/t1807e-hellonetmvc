using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T1807E_HelloMVC.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyContext")
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}