using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8.Model
{
    public interface ICarRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Car> GetCars();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="car"></param>
        void AddCar(Car car);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        void AddSpecification(Specification specification);
    }
}
