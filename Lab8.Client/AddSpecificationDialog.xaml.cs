using Lab8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab8.Client
{
    /// <summary>
    /// Interaction logic for AddSpecificationDialog.xaml
    /// </summary>
    public partial class AddSpecificationDialog : Window
    {
        #region Properties

        public Specification NewSpecification { get; private set; }

        #endregion

        public AddSpecificationDialog()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtMaxSpeed.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                    throw new ApplicationException("Some empty fields!");
                this.NewSpecification = new Specification()
                {
                    Name = txtName.Text,
                    MaxSpeed = int.Parse(txtMaxSpeed.Text),
                    Price = decimal.Parse(txtPrice.Text)
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
