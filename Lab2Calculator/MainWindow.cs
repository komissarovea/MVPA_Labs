using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2Calculator
{
    class MainWindow : Window
    {
        #region Fields

        private const int rbMargin = 10;
        private const int windowWidth = 276;
        private const int windowHeight = 350;

        private Canvas canvas = new Canvas();
        private RadioButton rbDegrees = new RadioButton() { Content = "Градусы", Margin = new Thickness(rbMargin), IsChecked = true };
        private RadioButton rbRadians = new RadioButton() { Content = "Радианы", Margin = new Thickness(95, rbMargin, 0, rbMargin) };
        private RadioButton rbGrads = new RadioButton() { Content = "Грады", Margin = new Thickness(175, rbMargin, 0, rbMargin) };
        private TextBox txtInput = new TextBox() { Margin = new Thickness(10), Width = windowWidth - 20, IsReadOnly = true, TextAlignment = TextAlignment.Right };

        private bool isCalculated = false;
        private double firstArgument = 0;
        private string sign = "";

        #endregion

        #region Constructor
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Width = windowWidth;
            this.Height = windowHeight;
            this.Title = "Calculator";
            this.ResizeMode = ResizeMode.NoResize;

            this.Content = canvas;

            canvas.Children.Add(txtInput);

            GroupBox groupBox = new GroupBox() { Width = this.Width - 20, Height = 35, Margin = new Thickness(10, 45, 15, 10) };
            Canvas groupCanvas = new Canvas();
            groupBox.Content = groupCanvas;
            groupCanvas.Children.Add(rbDegrees);
            groupCanvas.Children.Add(rbRadians);
            groupCanvas.Children.Add(rbGrads);
            canvas.Children.Add(groupBox);

            const int size = 40;
            const int space = 45;
            int left = 10;
            const int bottom = 60;

            List<Button> digitButtons = new List<Button>();
            for (int i = 0; i < 10; i++)
            {
                Button btnDigit = new Button() { Content = i, Width = size, Height = size };
                btnDigit.Click += btnDigit_Click;
                digitButtons.Add(btnDigit);

            }
            Button btnComma = new Button() { Content = ",", Width = size, Height = size };
            btnComma.Click += btnComma_Click;
            digitButtons.Insert(1, btnComma);
            Button btnSign = new Button() { Content = "+/-", Width = size, Height = size };
            btnSign.Click += btnSign_Click;
            digitButtons.Insert(1, btnSign);
            for (int i = 0; i < digitButtons.Count; i++)
            {
                Button btnDigit = digitButtons[i];
                btnDigit.Foreground = Brushes.Blue;
                Canvas.SetLeft(btnDigit, left + i % 3 * space);
                Canvas.SetBottom(btnDigit, bottom + i / 3 * space);

                canvas.Children.Add(btnDigit);
            }

            List<Button> otherButtons = new List<Button>();
            Button btnPlus = new Button() { Content = "+", Width = size, Height = size };
            btnPlus.Click += btnOperator_Click;
            otherButtons.Add(btnPlus);
            Button btnEqual = new Button() { Content = "=", Width = size, Height = size };
            btnEqual.Click += btnEqual_Click;
            otherButtons.Add(btnEqual);
            Button btnMinus = new Button() { Content = "-", Width = size, Height = size };
            btnMinus.Click += btnOperator_Click;
            otherButtons.Add(btnMinus);
            Button btnTg = new Button() { Content = "tg", Width = size, Height = size };
            btnTg.Click += btnTg_Click;
            otherButtons.Add(btnTg);
            Button btnPower = new Button() { Content = "*", Width = size, Height = size };
            btnPower.Click += btnOperator_Click;
            otherButtons.Add(btnPower);
            Button btnCos = new Button() { Content = "cos", Width = size, Height = size };
            btnCos.Click += btnCos_Click;
            otherButtons.Add(btnCos);
            Button btnDivide = new Button() { Content = "/", Width = size, Height = size };
            btnDivide.Click += btnOperator_Click;
            otherButtons.Add(btnDivide);
            Button btnSin = new Button() { Content = "sin", Width = size, Height = size };
            btnSin.Click += btnSin_Click;
            otherButtons.Add(btnSin);

            left += space * 3 + 30;
            for (int i = 0; i < otherButtons.Count; i++)
            {
                Button btn = otherButtons[i];
                btn.Foreground = Brushes.Red;
                Canvas.SetLeft(btn, left + i % 2 * space);
                Canvas.SetBottom(btn, bottom + i / 2 * space);

                canvas.Children.Add(btn);
            }

            Button btnClear = new Button() { Content = "C", Width = size, Height = size };
            Canvas.SetRight(btnClear, 10);
            Canvas.SetBottom(btnClear, 10);
            btnClear.Click += btnClear_Click;
            canvas.Children.Add(btnClear);
        }
        #endregion

        #region Event Handlers

        void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
        }

        void btnSin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            double number = double.Parse(txtInput.Text, Thread.CurrentThread.CurrentUICulture);
            double radians = GetRadians(number);
            txtInput.Text = Math.Sin(radians).ToString(Thread.CurrentThread.CurrentUICulture);
            isCalculated = true;
        }

        void btnCos_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            double number = double.Parse(txtInput.Text, Thread.CurrentThread.CurrentUICulture);
            double radians = GetRadians(number);
            txtInput.Text = Math.Cos(radians).ToString(Thread.CurrentThread.CurrentUICulture);
            isCalculated = true;
        }

        void btnTg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            double number = double.Parse(txtInput.Text, Thread.CurrentThread.CurrentUICulture);
            double radians = GetRadians(number);
            txtInput.Text = Math.Tan(radians).ToString(Thread.CurrentThread.CurrentUICulture);
            isCalculated = true;
        }

        void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            firstArgument = double.Parse(txtInput.Text, Thread.CurrentThread.CurrentUICulture);
            sign = (sender as Button).Content.ToString();
            isCalculated = true;
        }

        void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            if (!string.IsNullOrEmpty(sign))
            {
                double secondArgument = double.Parse(txtInput.Text);
                switch (sign)
                {
                    case "+":
                        txtInput.Text = (firstArgument + secondArgument).ToString(Thread.CurrentThread.CurrentUICulture);
                        break;
                    case "-":
                        txtInput.Text = (firstArgument - secondArgument).ToString(Thread.CurrentThread.CurrentUICulture);
                        break;
                    case "*":
                        txtInput.Text = (firstArgument * secondArgument).ToString(Thread.CurrentThread.CurrentUICulture);
                        break;
                    case "/":
                        txtInput.Text = (firstArgument / secondArgument).ToString(Thread.CurrentThread.CurrentUICulture);
                        break;
                }
                isCalculated = true;
            }
        }

        void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (isCalculated)
                txtInput.Text = "";
            if (txtInput.Text.Length == 0)
                return;
            if (!txtInput.Text.Contains("-"))
                txtInput.Text = "-" + txtInput.Text;
            else
                txtInput.Text = txtInput.Text.Replace("-", "");
        }

        void btnComma_Click(object sender, RoutedEventArgs e)
        {
            if (isCalculated)
                txtInput.Text = "";
            if (txtInput.Text.Length == 0)
                return;
            if (!txtInput.Text.Contains(","))
                txtInput.Text += ",";
        }

        void btnDigit_Click(object sender, RoutedEventArgs e)
        {
            if (isCalculated)
                txtInput.Text = "";
            Button btnDigit = sender as Button;
            if (btnDigit != null)
                txtInput.Text += btnDigit.Content.ToString();
            isCalculated = false;
        }

        #endregion

        #region Methods

        private double GetRadians(double value)
        {
            double retval = value;
            if (rbDegrees.IsChecked.HasValue && rbDegrees.IsChecked.Value)
            {
                retval = value * Math.PI / 180;
            }
            else if (rbGrads.IsChecked.HasValue && rbGrads.IsChecked.Value)
            {
                retval = value * Math.PI / 200;
            }
            return retval;
        }

        #endregion
    }
}
