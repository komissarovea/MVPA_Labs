/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Lab8.Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Lab8.DAL;
using Lab8.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Diagnostics;

namespace Lab8.Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<ICarRepository>(() => { return new CarRepository("CarsDB"); });
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DialogService>();
        }

        public MainViewModel Main
        {
            get
            {
                MainViewModel model = null;
                try
                {
                    model = ServiceLocator.Current.GetInstance<MainViewModel>();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                return model;
            }
        }

        public DialogService DialogService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DialogService>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}