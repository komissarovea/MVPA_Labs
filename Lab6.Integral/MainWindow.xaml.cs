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
        public double LowLimit { get; set; }

        public double UpperLimit { get; set; }

        public int RegionSplitNumber { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.LowLimit = 0;
            this.UpperLimit = Math.PI * 2;
            this.RegionSplitNumber = 100000000;
            txtSettings.Text = $"Нижний предел: {LowLimit}\nВерхний предел: {UpperLimit}\nЧисло разбиений области: {RegionSplitNumber}";
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow() { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            bool? result = inputWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                this.LowLimit = inputWindow.LowLimit;
                this.UpperLimit = inputWindow.UpperLimit;
                this.RegionSplitNumber = inputWindow.RegionSplitNumber;
                txtSettings.Text = $"Нижний предел: {LowLimit}\nВерхний предел: {UpperLimit}\nЧисло разбиений области: {RegionSplitNumber}";
            }
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            btnStart.IsEnabled = false;
            double resIntegral = await NumMethods.IntegralAsync(this.LowLimit, this.UpperLimit, this.RegionSplitNumber, this);
            lbResult.Content = $"Результат: {resIntegral}";
            Cursor = Cursors.Arrow;
            btnStart.IsEnabled = true;
            progressBar1.Value = 100;
        }

        public void Report(int value)
        {
            Dispatcher.Invoke(() => progressBar1.Value = value);
        }

        #region Additionally

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////int nCPU = Environment.ProcessorCount;
            ////Title = "Cpu=" + nCPU;

            //Cursor = Cursors.Wait;
            //btn.IsEnabled = false;

            ////double integralValue1 = NumMethods.Integral(0, 1, 100000000);
            ////labelRes.Content = integralValue1.ToString();

            //Task<double> task = new Task<double>(() =>
            //{
            //    double integralValue = NumMethods.Integral(0, 1, 100000000);
            //    return integralValue;
            //});
            //task.Start();

            //task.ContinueWith((task2) =>
            //{
            //    double integralValue = task2.Result;
            //    //labelRes.Content = integralValue.ToString();
            //    Action action = () =>
            //    {
            //        labelRes.Content = integralValue.ToString();
            //        Cursor = Cursors.Arrow;
            //        btn.IsEnabled = true;
            //    };
            //    Dispatcher.Invoke(action);
            //});
        }

        #endregion


    }
}
