using System;
using System.Windows;

namespace Lab6.Integral
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public double LowLimit { get; set; }

        public double UpperLimit { get; set; }

        public int RegionSplitNumber { get; set; }

        public InputWindow()
        {
            InitializeComponent();
            this.LowLimit = 0;
            this.UpperLimit = Math.PI * 2;
            this.RegionSplitNumber = 100000000;
            this.DataContext = this;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
