using Lab8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Lab8.DAL
{
    public class CarRepository : ICarRepository
    {
        private CarDbContext _carDbContext;

        public CarRepository(string nameOrConnectionString)
        {
            if (!string.IsNullOrWhiteSpace(nameOrConnectionString))
                _carDbContext = new CarDbContext(nameOrConnectionString);
        }

        public IEnumerable<Car> GetCars()
        {
            IEnumerable<Car> retval = null;
            if (_carDbContext != null)
            {
                if (_carDbContext.Cars.Count() == 0)
                {
                    var defaultCars = new List<Car>()
                    {
                        new Car() { Firm = "BMW", Make = "X5", Year = 2014 },
                        new Car() { Firm = "Audi", Make = "TT",  Year = 2012 },
                        new Car() { Firm = "Volkswagen", Make = "Tiguan",  Year = 2013 },
                        new Car() { Firm = "Renault", Make = "Logan",  Year = 2015 },
                        new Car() { Firm = "Lada", Make = "Vesta",  Year = 2017 },
                    };

                    _carDbContext.Cars.AddRange(defaultCars);
                    _carDbContext.SaveChanges();

                    var defaultSpecs = new List<Specification>()
                    {
                        new Specification() { MaxSpeed = 180, Price = 70000, Car = defaultCars[0], Name = "Base BMW" },
                        new Specification() { MaxSpeed = 190, Price = 90000, Car = defaultCars[1], Name = "Base Audi" },
                        new Specification() { MaxSpeed = 170, Price = 80000, Car = defaultCars[2], Name = "Base Volkswagen" },
                        new Specification() { MaxSpeed = 160, Price = 10000, Car = defaultCars[3], Name = "Base Renault" },
                        new Specification() { MaxSpeed = 150, Price = 11000, Car = defaultCars[4], Name = "Base Lada" },
                    };
                    _carDbContext.Specifications.AddRange(defaultSpecs);
                    _carDbContext.SaveChanges();
                }
                retval = _carDbContext.Cars;
            }
            return retval;
        }
    }

    class CarDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Specification> Specifications { get; set; }

        public CarDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specification>()
                .Property(e => e.Price)
                .HasPrecision(8, 0);
        }
    }
}
