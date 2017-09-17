using System.Windows.Controls;
using System.Windows.Shapes;

namespace Lab4.GraphicEditor
{
    /// <summary>
    /// Interaction logic for CrossControl.xaml
    /// </summary>
    public partial class CrossControl : UserControl
    {
        public Path Figure
        {
            get { return (this.Content as Viewbox).Child as Path; }
        }

        public CrossControl()
        {
            InitializeComponent();
        }
    }
}
