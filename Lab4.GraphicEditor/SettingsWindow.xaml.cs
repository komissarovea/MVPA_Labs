using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab4.GraphicEditor
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        #region Properties

        public double LineThickness
        {
            get;
            set;
        }

        public Brush BackgroundColor
        {
            get { return (Brush)(cmbBackgroundColor.SelectedItem as PropertyInfo).GetValue(null, null); }
        }

        public Brush LineColor
        {
            get { return (Brush)(cmbLineColor.SelectedItem as PropertyInfo).GetValue(null, null); }
        }

        #endregion

        #region Constructor

        public SettingsWindow()
        {
            InitializeComponent();
        }

        public SettingsWindow(double lineThickness, Brush backgroundColor, Brush lineColor) : this()
        {
            LineThickness = lineThickness;
            txtLineThickness.Text = lineThickness.ToString();
            foreach (PropertyInfo propertyInfo in cmbBackgroundColor.Items)
            {
                Brush brush = (Brush)propertyInfo.GetValue(null, null);
                if (brush == backgroundColor)
                    cmbBackgroundColor.SelectedItem = propertyInfo;
                if (brush == lineColor)
                    cmbLineColor.SelectedItem = propertyInfo;
            }
        }

        #endregion

        #region Event Handlers

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(txtLineThickness))
                this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        } 
        
        #endregion
    }
}
