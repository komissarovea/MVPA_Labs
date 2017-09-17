using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Lab4.GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        
        private Brush _backgroundColor = Brushes.LightCyan; //new SolidColorBrush(new Color() { R = #FFCBFEFE});
        private Brush _lineColor = Brushes.Black;
        private double _lineThickness = 2;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void drawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(drawingCanvas);
            CrossControl newElement = new CrossControl();
            newElement.Figure.StrokeThickness = _lineThickness;
            newElement.Figure.Fill = _backgroundColor;
            newElement.Figure.Stroke = _lineColor;
            Canvas.SetLeft(newElement, position.X - newElement.Width / 2);
            Canvas.SetTop(newElement, position.Y - newElement.Height / 2);
            drawingCanvas.Children.Add(newElement);
        }

        private void drawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(drawingCanvas);
            sbiPosition.Content = string.Format("x:{0}, y:{1}", (int)position.X, (int)position.Y);
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Graphic Editor\nVersion 1.0.0\nCopyright 2017, All Rights Reserved", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void miSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow(_lineThickness, _backgroundColor, _lineColor) { Owner = this };
            bool? result = settingsWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                _backgroundColor = settingsWindow.BackgroundColor;
                _lineThickness = settingsWindow.LineThickness;
                _lineColor = settingsWindow.LineColor;
            }
        }

        private void miNew_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.Children.Clear();
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog() { Filter = "XAML File|*.xaml" };
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value)
                {

                    string xaml = File.ReadAllText(dlg.FileName);
                    Canvas sourceCanvas = XamlReader.Parse(xaml) as Canvas;
                    drawingCanvas.Children.Clear();
                    while (sourceCanvas.Children.Count > 0)
                    {
                        UIElement child = sourceCanvas.Children[0];
                        sourceCanvas.Children.Remove(child);
                        drawingCanvas.Children.Add(child);
                    }
                    this.Title = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog() { Filter = "XAML File|*.xaml" };
            bool? result = dlg.ShowDialog(this);
            if (result.HasValue && result.Value)
            {
                string xaml = XamlWriter.Save(drawingCanvas);
                File.WriteAllText(dlg.FileName, xaml);
            }
        } 
        
        #endregion
    }
}
