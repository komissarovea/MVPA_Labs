using Lab8.Client.ViewModel;
using Lab8.Model;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace Lab8.Client
{
    public class DialogService
    {
        public void ShowAddCarDialog()
        {
            AddCarDialog dialog = new AddCarDialog()
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (dialog.ShowDialog() == true)
            {
                MainViewModel mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
                Car car = dialog.NewCar;
                mainViewModel.Repository?.AddCar(car);
                mainViewModel.Cars.Add(car);
            }
        }

        public void ShowAddSpecificationDialog(Car car)
        {
            if (car == null)
                return;
            AddSpecificationDialog dialog = new AddSpecificationDialog()
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (dialog.ShowDialog() == true)
            {
                MainViewModel mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
                Specification sp = dialog.NewSpecification;
                sp.Car = car;
                sp.CarID = car.Id;
                mainViewModel.Repository?.AddSpecification(sp);
                //car.OnPropertyChanged("Specifications");
                //var mainWindow = Application.Current.MainWindow as MainWindow;
                //mainWindow.lstCars.SelectedItem = null;
                //mainWindow.lstCars.SelectedItem = car;
                //mainWindow.UpdateLayout();
            }
        }
    }
}
