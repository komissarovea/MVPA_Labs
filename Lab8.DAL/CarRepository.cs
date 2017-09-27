using Lab8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Lab8.DAL
{
    public class CarRepository : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Specification> Specifications { get; set; }

        public CarRepository() : base("CarRepository")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specification>()
                .Property(e => e.Price)
                .HasPrecision(8, 0);
        }

    }
}
