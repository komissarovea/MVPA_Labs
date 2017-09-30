using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab8.Model;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab8.Client.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ICarRepository _repository;

        public ObservableCollection<Car> Cars { get; set; }

        public RelayCommand AddCommand { get; set; }

        public ICarRepository Repository { get { return _repository; } }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ICarRepository repository)
        {
            _repository = repository;

            if (_repository != null)
            {
                this.Cars = new ObservableCollection<Car>(_repository.GetCars() ?? new List<Car>());
                this.AddCommand = new RelayCommand(() =>
                {
                    ServiceLocator.Current.GetInstance<DialogService>().ShowAddNewDialog();
                });
            }
        }
    }
}