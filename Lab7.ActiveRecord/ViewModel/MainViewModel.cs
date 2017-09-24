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
            Message = "Hello!!!";
            if (repository != null)
            {
                this.Cars = new ObservableCollection<Car>(repository.GetCars());
                this.AddCommand = new RelayCommand(() =>
                {
                    Car car = new Car()
                    {
                        Firm = "Firm1",
                        Make = "Make1"
                    };
                    //repository.AddCar(car);
                    this.Cars.Add(car);
                });
            }
        }

        public void AddCar()
        {
            MessageBox.Show("");
        }
    }
}