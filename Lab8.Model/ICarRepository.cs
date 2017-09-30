using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8.Model
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
    }
}
