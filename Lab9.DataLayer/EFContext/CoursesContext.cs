using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Lab9.DataLayer.EFContext
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(string name) : base(name)
        {
            Database.SetInitializer(new CourcesInitializer());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
