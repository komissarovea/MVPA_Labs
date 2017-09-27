using Lab7.ActiveRecord.ViewModel;
using Lab7.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lab7.ActiveRecord
{
    public class DialogService
    {
        public void ShowAddNewDialog()
        {
            AddNewDialog dialog = new AddNewDialog()
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (dialog.ShowDialog() == true)
            {
                MainViewModel mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
                Car car = dialog.NewCar;
                car.Id = mainViewModel.Cars.Count + 1;
                mainViewModel.Repository.AddCar(car);
                mainViewModel.Cars.Add(car);
            }
        }
    }
}
