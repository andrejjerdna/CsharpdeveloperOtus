using System.Collections.Concurrent;
using System.Diagnostics;

namespace ParallelSum
{
    /// <summary>
    /// Summator for list of int
    /// </summary>
    internal class Summator : ISummator
    {
        private readonly Stopwatch _stopwatch;
        private double _sum;
        private List<Thread> _threads;
        public Summator()
        {
            _stopwatch = new Stopwatch();
            _threads = new List<Thread>();
        }

        public AdditionResult LinqSum(IEnumerable<int> data)
        {
            _stopwatch.Restart();

            var sum = data.AsParallel().Sum(d => (double)d);

            _stopwatch.Stop();

            var title = $"The sum of {data.Count()} elements using LINQ";

            return new AdditionResult(sum, _stopwatch.Elapsed.TotalSeconds, title);
        }

        public AdditionResult ParallelSum(IEnumerable<int> data)
        {
            var processorCount = Environment.ProcessorCount;

            _stopwatch.Restart();

            var take = data.Count() / processorCount;

            _sum = 0.0;
            _threads.Clear();

            for (var i = 0; i <= processorCount; i++)
            {
                var currendData = data.Skip(i * take).Take(take);

                ThreadGenerate(currendData);
            }

            foreach (var thread in _threads)
                thread.Join();

            _stopwatch.Stop();

            var title = $"The sum of {data.Count()} elements using threads";

            return new AdditionResult(_sum, _stopwatch.Elapsed.TotalSeconds, title);
        }
        public AdditionResult Sum(IEnumerable<int> data)
        {
            _stopwatch.Restart();

            var sum = 0.0;

            foreach (var item in data)
                sum += item;

            _stopwatch.Stop();

            var title = $"The sum of {data.Count()} elements";

            return new AdditionResult(sum, _stopwatch.Elapsed.TotalSeconds, title);
        }

        private void ThreadGenerate(IEnumerable<int> currendData)
        {
            var thread = new Thread(() =>
            {
                var localSum = 0.0;

                foreach (var item in currendData)
                    localSum += item;

                _sum += localSum;
            });

            _threads.Add(thread);
            thread.Start();
        }
    }
}
