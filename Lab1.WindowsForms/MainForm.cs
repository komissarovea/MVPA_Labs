using System;
using System.Windows.Forms;

namespace Lab1.WindowsForms
{
    sealed class MainForm : Form
    {
        #region Fields

        private Label labelX = new Label() { Text = "x = ", Width = 30, Left = 20, Top = 20 };
        private Label labelY = new Label() { Text = "y = ", Width = 30, Left = 20, Top = 60 };
        private Label labelZ = new Label() { Text = "z = ", Width = 30, Left = 20, Top = 100 };
        private TextBox textBoxX = new TextBox() { Text = "6,251", Width = 150, Left = 50, Top = 20 };
        private TextBox textBoxY = new TextBox() { Text = "0,827", Width = 150, Left = 50, Top = 60 };
        private TextBox textBoxZ = new TextBox() { Text = "25,001", Width = 150, Left = 50, Top = 100 };
        private Button buttonCalculate = new Button() { Text = "Calculate", Width = 100, Left = 20, Top = 140 };
        private TextBox textBoxResult = new TextBox() { Text = "Lab1", Width = 300, Height = 100, Left = 20, Top = 180, Multiline = true, ReadOnly = true };

        #endregion

        #region Constructor

        public MainForm()
        {
            this.Text = "Lab1";
            this.Width = 500;
            this.Height = 350;

            Controls.AddRange(new Control[] { labelX, labelY, labelZ, textBoxX, textBoxY, textBoxZ, buttonCalculate, textBoxResult });
            buttonCalculate.Click += buttonCalculate_Click;
        }

        #endregion

        #region Event Handlers

        private void buttonCalculate_Click(object sender, EventArgs e)
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

                textBoxResult.Text = string.Format("Lab1{0}b = {1:0.0000}", Environment.NewLine, b);
            }
            catch (Exception ex)
            {
                textBoxResult.Text = ex.ToString();
            }
        } 

        #endregion
    }
}
