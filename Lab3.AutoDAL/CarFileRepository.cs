using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Lab3.AutoLib;

namespace Lab3.AutoDAL
{
    public class CarFileRepository : ICarRepository
    {
        #region Fields

        private const string CARS_FILE = "cars.xml";
        private List<Car> _cars = null;

        #endregion

        #region ICarRepository Members

        public IEnumerable<Car> GetCars()
        {
            if (_cars == null)
            {
                if (File.Exists(CARS_FILE))
                {
                    _cars = new List<Car>();
                    XDocument xdoc = XDocument.Load(CARS_FILE);
                    foreach (var carNode in xdoc.Root.Elements("car"))
                    {
                        _cars.Add(new Car()
                        {
                            Id = int.Parse(carNode.Attribute("Id").Value),
                            Firm = carNode.Attribute("Firm").Value,
                            Make = carNode.Attribute("Make").Value,
                            MaxSpeed = int.Parse(carNode.Attribute("MaxSpeed").Value),
                            Price = int.Parse(carNode.Attribute("Price").Value),
                            Year = int.Parse(carNode.Attribute("Year").Value)
                        });
                    }
                }
                else
                    _cars = new List<Car>()
                       {
                           new Car() { Id = 1, Firm = "BMW", Make = "X5", MaxSpeed = 180, Price = 70000, Year = 2014 },
                           new Car() { Id = 2, Firm = "Audi", Make = "TT", MaxSpeed = 190, Price = 90000, Year = 2012 },
                           new Car() { Id = 3, Firm = "Volkswagen", Make = "Tiguan", MaxSpeed = 170, Price = 80000, Year = 2013 },
                           new Car() { Id = 4, Firm = "Renault", Make = "Logan", MaxSpeed = 160, Price = 10000, Year = 2015 },
                           new Car() { Id = 5, Firm = "Lada", Make = "Vesta", MaxSpeed = 150, Price = 11000, Year = 2017 },
                       };
            }
            return _cars;
        }

        public void AddCar(Car car)
        {
            if (_cars != null)
                _cars.Add(car);
        }

        public void SaveCars(IEnumerable<Car> cars)
        {
            if (cars != null)
            {
                XDocument xdoc = new XDocument(new XElement("root"));
                foreach (var car in cars)
                {
                    xdoc.Root.Add(new XElement("car",
                        new XAttribute("Id", car.Id),
                        new XAttribute("Firm", car.Firm),
                        new XAttribute("Make", car.Make),
                        new XAttribute("MaxSpeed", car.MaxSpeed),
                        new XAttribute("Price", car.Price),
                        new XAttribute("Year", car.Year)
                        ));
                }
                xdoc.Save(CARS_FILE);
            }
        }

        #endregion
    }
}
