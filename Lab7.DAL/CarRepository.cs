using Lab7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7.DAL
{
    public class CarRepository : ICarRepository
    {
        public void AddCar(Car car)
        {
        }

        public IEnumerable<Car> GetCars()
        {
            return new List<Car>();
        }

        public void SaveCars(IEnumerable<Car> cars)
        {
        }
    }
}
