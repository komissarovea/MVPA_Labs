using System;
using System.Threading.Tasks;

namespace Lab6.Integral
{
    class NumMethods
    {
        public static Task<double> IntegralAsync(double a, double b, int N, IProgress<int> progress)
        {
            Task<double> task = new Task<double>(() =>
            {
                double h = (b - a) / N;
                double x;
                double sum = 0;
                for (int i = 0; i < N; i++)
                {
                    x = a + i * h;
                    sum += Math.Sin(x);
                    if (i % 1000000 == 0)
                        progress.Report((int)(i / (double)N * 100));
                }

                return sum * h;
            });
            task.Start();
            return task;
        }

        #region Additionally

        public static double Integral(double a, double b, int N)
        {
            double h = (b - a) / N;
            double x;
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                x = a + i * h;
                sum += Math.Sin(x);
            }

            return sum * h;
        }

        public static Task<double> IntegralAsync(double a, double b, int N)
        {
            Task<double> task = new Task<double>(() =>
            {
                return Integral(a, b, N);
            });
            task.Start();
            return task;
        }

        public static Task<double> Integral2CPUAsync(double a, double b, int N)
        {
            Task<double> taskMain = Task<double>.Factory.StartNew(() =>
            {
                Task<double> task1 = new Task<double>(
                    () =>
                    {
                        return Integral(a, b / 2, N / 2);
                    });
                task1.Start();

                Task<double> task2 = Task<double>.Factory.StartNew(() =>
                {
                    return Integral(b / 2, b, N / 2);
                });

                Task.WaitAll(new[] { task1, task2 });
                return task1.Result + task2.Result;
            });

            return taskMain;
        } 
        
        #endregion
    }
}
