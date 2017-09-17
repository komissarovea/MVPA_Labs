using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab2Controls
{
    // Variant 11
    class MainWindow : Window
    {
        #region Fields

        private Canvas canvas = new Canvas();
        private Label labelX = new Label() { Content = "x = ", Margin = new Thickness(20, 20, 0, 0) };
        private Label labelY = new Label() { Content = "y = ", Margin = new Thickness(20, 60, 0, 0) };
        private Label labelA = new Label() { Content = "a = ", Margin = new Thickness(20, 100, 0, 0) };
        private TextBox textBoxX = new TextBox() { Text = "45", Width = 100, Margin = new Thickness(50, 23, 0, 0) };
        private TextBox textBoxY = new TextBox() { Text = "20", Width = 100, Margin = new Thickness(50, 63, 0, 0) };
        private TextBox textBoxA = new TextBox() { Text = "", Width = 100, Margin = new Thickness(50, 103, 0, 0) };
        private Button buttonCalculate = new Button() { Content = "Calculate", Width = 130, Margin = new Thickness(20, 140, 0, 0) };
        private TextBox textBoxResult = new TextBox() { Text = "Lab2\n", Width = 400, Height = 100, Margin = new Thickness(20, 180, 0, 0), IsReadOnly = true };

        private GroupBox groupBoxFX = new GroupBox() { Header = "f(x)", Content = new Canvas(), Width = 120, Height = 150, Margin = new Thickness(200, 10, 0, 0) };
        private RadioButton radioButtonSin = new RadioButton() { Content = "sin(x)", IsChecked = true, Margin = new Thickness(10, 10, 0, 0) };
        private RadioButton radioButtonCos = new RadioButton() { Content = "cos(x)", IsChecked = false, Margin = new Thickness(10, 40, 0, 0) };
        private RadioButton radioButtonTg = new RadioButton() { Content = "tg(x)", IsChecked = false, Margin = new Thickness(10, 70, 0, 0) };

        private CheckBox checkBoxMin = new CheckBox() { Content = "min", Margin = new Thickness(350, 20, 0, 0) };
        private CheckBox checkBoxMax = new CheckBox() { Content = "max", Margin = new Thickness(350, 60, 0, 0) };

        private List<double> allResults = new List<double>();

        #endregion

        #region Constructor

        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Width = 500;
            this.Height = 350;
            this.Title = "Lab2";

            this.Content = canvas;
            canvas.Children.Add(labelX);
            canvas.Children.Add(labelY);
            //canvas.Children.Add(labelA);
            canvas.Children.Add(textBoxX);
            canvas.Children.Add(textBoxY);
            //canvas.Children.Add(textBoxA);
            canvas.Children.Add(buttonCalculate);
            buttonCalculate.Click += buttonCalculate_Click;
            canvas.Children.Add(textBoxResult);

            canvas.Children.Add(groupBoxFX);
            var canvasFX = groupBoxFX.Content as Canvas;
            if (canvasFX != null)
            {
                canvasFX.Children.Add(radioButtonSin);
                canvasFX.Children.Add(radioButtonCos);
                canvasFX.Children.Add(radioButtonTg);
            }

            canvas.Children.Add(checkBoxMin);
            canvas.Children.Add(checkBoxMax);
        }

        #endregion

        #region Event Handlers

        void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(textBoxX.Text);
                double y = double.Parse(textBoxY.Text);
                double fx = radioButtonSin.IsChecked.HasValue && radioButtonSin.IsChecked.Value ? Math.Sin(x)
                    : (radioButtonCos.IsChecked.HasValue && radioButtonCos.IsChecked.Value ? Math.Cos(x) : Math.Tan(x));
                double a;
                string branchText;

                if (x * y > 0)
                {
                    a = Math.Pow(fx + y, 2) - Math.Sqrt(fx * y);
                    branchText = "Ветвь №1 - xy > 0";
                }
                else if (x * y < 0)
                {
                    a = Math.Pow(fx + y, 2) + Math.Sqrt(Math.Abs(fx * y));
                    branchText = "Ветвь №2 - xy < 0";
                }
                else
                {
                    a = Math.Pow(fx + y, 2) + 1;
                    branchText = "Ветвь №3 - xy = 0";
                }
                allResults.Add(a);

                string resultText = string.Format("fx = {2:0.0000}\na = {0:0.0000}\n{1}", a, branchText, fx);

                if (checkBoxMin.IsChecked.HasValue && checkBoxMin.IsChecked.Value)
                    resultText += string.Format("\nmin = {0:0.0000}", allResults.Min());

                if (checkBoxMax.IsChecked.HasValue && checkBoxMax.IsChecked.Value)
                    resultText += string.Format("\nmax = {0:0.0000}", allResults.Max());

                textBoxResult.Text = resultText;
                //textBoxA.Text = string.Format("{0:0.0000}", a);
            }
            catch (Exception ex)
            {
                textBoxResult.Text = ex.ToString();
            }
        }

        #endregion
    }
}
