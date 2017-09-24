using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7.Model
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
        /// <param name="cars"></param>
        void SaveCars(IEnumerable<Car> cars);
    }
}
