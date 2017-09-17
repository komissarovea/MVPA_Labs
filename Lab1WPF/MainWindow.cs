using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab1WPF
{
    class MainWindow : Window
    {
        #region Fields

        //private double x = 6.251;
        //private double y = 0.827;
        //private double z = 25.001;
        //private double b = 0.7121;

        private Canvas canvas = new Canvas();
        private Label labelX = new Label() { Content = "x = ", Margin = new Thickness(20, 20, 0, 0) };
        private Label labelY = new Label() { Content = "y = ", Margin = new Thickness(20, 60, 0, 0) };
        private Label labelZ = new Label() { Content = "z = ", Margin = new Thickness(20, 100, 0, 0) };
        private TextBox textBoxX = new TextBox() { Text = "6,251", Width = 150, Margin = new Thickness(50, 23, 0, 0) };
        private TextBox textBoxY = new TextBox() { Text = "0,827", Width = 150, Margin = new Thickness(50, 63, 0, 0) };
        private TextBox textBoxZ = new TextBox() { Text = "25,001", Width = 150, Margin = new Thickness(50, 103, 0, 0) };
        private Button buttonCalculate = new Button() { Content = "Calculate", Width = 100, Margin = new Thickness(20, 140, 0, 0) };
        private TextBox textBoxResult = new TextBox() { Text = "Lab1\n", Width = 300, Height = 100, Margin = new Thickness(20, 180, 0, 0), IsReadOnly = true };

        #endregion

        #region Constructor

        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Width = 500;
            this.Height = 350;
            this.Title = "Lab1";

            this.Content = canvas;
            canvas.Children.Add(labelX);
            canvas.Children.Add(labelY);
            canvas.Children.Add(labelZ);
            canvas.Children.Add(textBoxX);
            canvas.Children.Add(textBoxY);
            canvas.Children.Add(textBoxZ);
            canvas.Children.Add(buttonCalculate);
            buttonCalculate.Click += buttonCalculate_Click;
            canvas.Children.Add(textBoxResult);
        }

        #endregion

        #region Event Handlers

        void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(textBoxX.Text);
                double y = double.Parse(textBoxY.Text);
                double z = double.Parse(textBoxZ.Text);
                double b = Math.Sin(z);
                b = Math.Pow(b, 2);
                b = b / Math.Sqrt(x + y) + 1;
                b = Math.Abs(x - y) * b;
                double t2 = Math.Pow(Math.E, Math.Abs(x - y)) + x / 2;
                b = Math.Pow(Math.Cos(y), 3) * b / t2;
                b = Math.Pow(y, Math.Pow(Math.Abs(x), (double)1 / 3)) + b;

                textBoxResult.Text = string.Format("Lab1\nb = {0:0.0000}\n", b);
            }
            catch (Exception ex)
            {
                textBoxResult.Text = ex.ToString();
            }
        }

        #endregion
    }
}
