using Lab7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7.DAL
{
    public class CarRepository : ICarRepository
    {
        private string _connectionString = "";

        public CarRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Car> GetCars()
        {
            return DAL.CarActiveRecord.GetAll(_connectionString).Select(c =>
            {
                return new Car()
                {
                    Id = c.Id,
                    Firm = c.Firm,
                    Make = c.Make,
                    Year = c.Year,
                    Price = c.Price,
                    MaxSpeed = c.MaxSpeed,
                };
            });
        }

        public void AddCar(Car car)
        {
            DAL.CarActiveRecord record = new DAL.CarActiveRecord();
            record.Id = car.Id;
            record.Firm = car.Firm;
            record.Make = car.Make;
            record.Year = car.Year;
            record.Price = car.Price;
            record.MaxSpeed = car.MaxSpeed;
            record.Add(_connectionString);
        }
    }
}
