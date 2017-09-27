using Lab7.Model;
using System;
using System.Windows;

namespace Lab7.ActiveRecord
{
    /// <summary>
    /// Interaction logic for AddNewDialog.xaml
    /// </summary>
    public partial class AddNewDialog : Window
    {
        #region Properties

        public Car NewCar { get; private set; }

        #endregion

        #region Constructor

        public AddNewDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirm.Text) || string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtMaxSpeed.Text)
                    || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtYear.Text))
                    throw new ApplicationException("Some empty fields!");
                this.NewCar = new Car()
                {
                    Firm = txtFirm.Text,
                    Make = txtMake.Text,
                    MaxSpeed = int.Parse(txtMaxSpeed.Text),
                    Price = int.Parse(txtPrice.Text),
                    Year = int.Parse(txtYear.Text)
                };
                this.DialogResult = true;
                this.Close();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect input!\n" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        #endregion

    }
}
