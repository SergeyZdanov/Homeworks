using System.Diagnostics;

namespace Otus28
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            int sum1 = 0;
            DateTime now = DateTime.Now;
            int lovkEl = 100000;
            int[] massiveNumbers = new int[lovkEl];



            WorkingWithNumbers workingWithNumbers = new WorkingWithNumbers();
            massiveNumbers = workingWithNumbers.RandomArrayFilling(massiveNumbers);

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Подсчет времени для " + lovkEl + " элементов");
            stopwatch.Start();

            foreach (var n in massiveNumbers)
            {
                sum += n;
            }

            stopwatch.Stop();
            Console.WriteLine("Время выполнения при обычном вычислении: " + stopwatch.ElapsedTicks);

            sum = 0;

            stopwatch.Reset();

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < massiveNumbers.Length / 2; i++)
                {
                    sum += massiveNumbers[i];
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = massiveNumbers.Length / 2; i < massiveNumbers.Length; i++)
                {
                    sum1 += massiveNumbers[i];
                }
            });
            stopwatch.Start();

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            stopwatch.Stop();
            Console.WriteLine("Время выполнения в двух потоках: " + stopwatch.ElapsedTicks);

            sum = 0;
            int x = 0;
            stopwatch.Restart();

            x = massiveNumbers.AsParallel().Sum();

            stopwatch.Stop();

            Console.WriteLine("Время выполнения в PLinq: " + stopwatch.ElapsedTicks);

        }

    }
}

