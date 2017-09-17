using Lab5.HippodromeLib;
using System;
using System.Windows;
using System.Windows.Media;

namespace Lab5.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            hippodromeControl1.PathBrush = Brushes.Green;
            hippodromeControl1.HorseBrush = Brushes.Blue;
            hippodromeControl2.PathRadius -= 30;
        }

        #endregion

        #region Event Handlers

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            hippodromeControl1.AngleSpeed = r.Next(1, 10) * 0.01;
            hippodromeControl2.AngleSpeed = r.Next(1, 10) * 0.01;
            hippodromeControl1.Start();
            hippodromeControl2.Start();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            hippodromeControl1.Stop();
            hippodromeControl2.Stop();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void horseLeftClick(object sender, EventArgs e)
        {
            HippodromeControl horseControl = sender as HippodromeControl;
            MessageBox.Show("Horse Speed: " + horseControl.AngleSpeed + " rad/s",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void horseRightClick(object sender, EventArgs e)
        {
            HippodromeControl horseControl = sender as HippodromeControl;
            MessageBox.Show(String.Format("Horse Coordinates: ({0:F0},{1:F0})", horseControl.CurrentPoint.X, horseControl.CurrentPoint.Y),
               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        } 

        #endregion
    }
}
