using System.Collections.Generic;

namespace Lab3.AutoLib
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
