using Lab3.AutoDAL;
using System.Windows;

namespace Lab3.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.MainWindow = new MainWindow(new CarFileRepository());
            this.MainWindow.Show();
        }
    }
}
