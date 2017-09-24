using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab7.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab7.ActiveRecord.ViewModel
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
        private string _message;
        private ICarRepository _repository;

        public string Message
        {
            get { return _message; }
            set { Set(nameof(Message), ref _message, value); }
        }

        public ObservableCollection<Car> Cars { get; set; }

        public RelayCommand AddCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ICarRepository repository)
        {
            ////if (IsInDesignMode)

            _message = "Hello!!!";
            _repository = repository;

            if (_repository != null)
            {
                this.Cars = new ObservableCollection<Car>(_repository.GetCars());
                this.AddCommand = new RelayCommand(() =>
                {
                    AddNewDialog dialog = new AddNewDialog()
                    {
                        Owner = Application.Current.MainWindow,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner
                    };
                    if (dialog.ShowDialog() == true)
                    {
                        Car car = dialog.NewCar;
                        car.Id = Cars.Count + 1;
                        _repository.AddCar(car);
                        this.Cars.Add(car);
                    }
                });
            }
        }
    }
}