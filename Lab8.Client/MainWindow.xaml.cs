using Lab8.DAL;
using Lab8.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab8.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            using (CarRepository db = new CarRepository())
            {
                //Car car = new Car() { Firm = "BMW", Make = "X5", Year = 2010 };
                //db.Cars.Add(car);
                //db.SaveChanges();

                //Specification specification = new Specification() { Name = "Max2", Price = 100000, MaxSpeed = 200, Car = car };
                //db.Specifications.Add(specification);
                //db.SaveChanges();

                //foreach (var c in db.Cars)
                //    Debug.WriteLine(c);

                foreach (var sp in db.Specifications)//.Include("Car"))
                    Debug.WriteLine("{0} - {1}", sp.Name, sp.Car != null ? sp.Car.ToString() : "");
                Debug.WriteLine("");
            }
        }
    }
}
