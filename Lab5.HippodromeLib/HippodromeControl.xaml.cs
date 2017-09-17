using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Lab5.HippodromeLib
{
    /// <summary>
    /// Interaction logic for HippodromeControl.xaml
    /// </summary>
    public partial class HippodromeControl : UserControl
    {
        #region Fields

        private double horseRadius = 10;
        private double angleSpeed = 0.01;
        private double pathRadius = 200;
        private Point currentPoint;
        private int time = 0;
        private DispatcherTimer dt = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1) };

        private Brush pathBrush;
        private Brush horseBrush;

        public event EventHandler HorseLeftClick;
        public event EventHandler HorseRightClick;

        #endregion

        #region Properties

        public Brush PathBrush
        {
            get { return pathBrush; }
            set
            {
                pathBrush = value;
                pathEllipse.Stroke = pathBrush;
            }
        }

        public Brush HorseBrush
        {
            get { return horseBrush; }
            set
            {
                horseBrush = value;
                horseEllipse.Fill = value;
            }
        }

        public double PathRadius
        {
            get
            {
                return pathRadius;
            }
            set
            {
                pathRadius = value;
                UpdateRadius();
            }
        }

        public double AngleSpeed
        {
            get { return angleSpeed; }
            set { angleSpeed = value; }
        }

        public Point CurrentPoint { get { return currentPoint; } }

        #endregion

        #region Constructor

        public HippodromeControl()
        {
            InitializeComponent();
            dt.Tick += DtOnTick;
            horseEllipse.Width = horseEllipse.Height = horseRadius * 2;
            UpdateRadius();
            //horseEllipse.Margin = new Thickness(pathRadius * 2 - horseRadius,
            //    pathRadius - horseRadius, 0, 0);
            //horseEllipse.Margin = new Thickness(currentPoint.X - horseRadius, currentPoint.Y - horseRadius, 0, 0);
        } 
        
        #endregion

        #region Methods

        public void Start()
        {
            dt.Start();
            currentPoint = new Point(pathRadius, 0);
            horseEllipse.Margin = new Thickness(pathRadius + currentPoint.X - horseRadius,
                                                pathRadius + currentPoint.Y - horseRadius, 0, 0);
            horseEllipse.Visibility = Visibility.Visible;
        }

        public void Stop()
        {
            dt.Stop();
            //horseEllipse.Visibility = Visibility.Collapsed;
            time = 0;
        }

        private void UpdateRadius()
        {
            canvas.Width = canvas.Height = pathRadius * 2;
            pathEllipse.Width = pathEllipse.Height = pathRadius * 2 + pathEllipse.StrokeThickness;
        }

        #endregion

        #region Event Handlers

        private void DtOnTick(object sender, EventArgs eventArgs)
        {
            time++;
            double x = pathRadius * Math.Cos(AngleSpeed * time);
            double y = pathRadius * Math.Sin(AngleSpeed * time);
            currentPoint = new Point(x, y);
            horseEllipse.Margin = new Thickness(pathRadius + currentPoint.X - horseRadius,
                                               pathRadius + currentPoint.Y - horseRadius, 0, 0);
            //Point newPoint;
            //if (currentPoint.X > 0 || currentPoint.Y == -pathRadius)
            //{
            //    newPoint = new Point(currentPoint.X, currentPoint.Y + 1);
            //    newPoint.X = Math.Sqrt(Math.Pow(pathRadius, 2) - Math.Pow(newPoint.Y, 2));

            //}
            //else
            //{
            //    newPoint = new Point(currentPoint.X, currentPoint.Y - 1);
            //    newPoint.X = -Math.Sqrt(Math.Pow(pathRadius, 2) - Math.Pow(newPoint.Y, 2));
            //}
            //horseEllipse.Margin = new Thickness(pathRadius + newPoint.X - horseRadius,
            //                                    pathRadius + newPoint.Y - horseRadius, 0, 0);
            //currentPoint = newPoint;
        }

        private void horseEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HorseLeftClick?.Invoke(this, new EventArgs());
        }

        private void horseEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            HorseRightClick?.Invoke(this, new EventArgs());
        } 

        #endregion
    }
}
