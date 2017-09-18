using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab6.Integral
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IProgress<int>
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            btn2.IsEnabled = false;
            double resIntegral = await NumMethods.IntegralAsync(0, 1, 20000000, this);
            labelRes.Content = resIntegral.ToString();
            Cursor = Cursors.Arrow;
            btn2.IsEnabled = true;
            progressBar1.Value = 100;
        }

        public void Report(int value)
        {
            Dispatcher.Invoke(() => progressBar1.Value = value);
        }

        #region Additionally

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int nCPU = Environment.ProcessorCount;
            //Title = "Cpu=" + nCPU;

            Cursor = Cursors.Wait;
            btn.IsEnabled = false;

            //double integralValue1 = NumMethods.Integral(0, 1, 100000000);
            //labelRes.Content = integralValue1.ToString();

            Task<double> task = new Task<double>(() =>
            {
                double integralValue = NumMethods.Integral(0, 1, 100000000);
                return integralValue;
            });
            task.Start();

            task.ContinueWith((task2) =>
            {
                double integralValue = task2.Result;
                //labelRes.Content = integralValue.ToString();
                Action action = () =>
                {
                    labelRes.Content = integralValue.ToString();
                    Cursor = Cursors.Arrow;
                    btn.IsEnabled = true;
                };
                Dispatcher.Invoke(action);
            });
        } 
        #endregion
    }
}
