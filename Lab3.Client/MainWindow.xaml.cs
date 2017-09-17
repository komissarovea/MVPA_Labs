using Lab3.AutoLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab3.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private ICarRepository _carRepository = null;
        private List<Car> _allCars = null;
        private ObservableCollection<Car> _cars = null;

        #endregion

        #region Constructor

        public MainWindow(ICarRepository carRepository)
        {
            InitializeComponent();
            _carRepository = carRepository;
            _allCars = carRepository.GetCars().ToList();
            _cars = new ObservableCollection<Car>(_allCars);
            lstCars.ItemsSource = _cars;
            if (_cars.Count > 0)
                lstCars.SelectedIndex = 0;
        }

        #endregion

        #region Event Handlers

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewDialog dlg = new AddNewDialog() { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            bool? result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                cmbFilter.SelectedIndex = 0;
                dlg.NewCar.Id = _cars.Count + 1;
                _allCars.Add(dlg.NewCar);
                _cars.Add(dlg.NewCar);
                lstCars.SelectedItem = dlg.NewCar;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _carRepository.SaveCars(_cars);
                MessageBox.Show("Information saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        #endregion

        #region Methods

        private void ApplyFilter()
        {
            if (_allCars != null)
            {
                Car selectedCar = lstCars.SelectedItem as Car;
                _cars.Clear();
                foreach (var car in _allCars)
                {
                    switch ((cmbFilter.SelectedItem as ComboBoxItem).Content.ToString())
                    {
                        case "None":
                            _cars.Add(car);
                            break;
                        case "Firm":
                            if (car.Firm.Contains(txtFilter.Text))
                                _cars.Add(car);
                            break;
                        case "Make":
                            if (car.Make.Contains(txtFilter.Text))
                                _cars.Add(car);
                            break;
                        case "Year":
                            if (car.Year.ToString().Contains(txtFilter.Text))
                                _cars.Add(car);
                            break;
                        case "Price":
                            if (car.Price.ToString().Contains(txtFilter.Text))
                                _cars.Add(car);
                            break;
                        case "Max speed":
                            if (car.MaxSpeed.ToString().Contains(txtFilter.Text))
                                _cars.Add(car);
                            break;
                    }
                }
                lstCars.SelectedItem = selectedCar;
            }
        } 
        
        #endregion
    }
}
