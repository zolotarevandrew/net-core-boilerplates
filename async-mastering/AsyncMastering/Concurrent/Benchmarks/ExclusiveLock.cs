using BenchmarkDotNet.Attributes;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent
{
    public class ExclusiveLock
    {

        public void TestSimpleCycle()
        {
            using (var timer = new Timer("Mutex"))
            using (var mutex = new ByMutex())
            {
                mutex.Run();
            }

            using (var timer = new Timer("Lock"))
            {
                var @lock = new ByLock();
                @lock.Run();
            }

            using (var timer = new Timer("Cycle"))
            {
                var @lock = new ByCycle();
                @lock.Run();
            }

            using (var timer = new Timer("Interlocked"))
            {
                var @lock = new ByInterlocked();
                @lock.Run();
            }
        }

        public class ByMutex : IDisposable
        {
            private int _counter = 0;
            private Mutex _mutex = new Mutex();

            public void Dispose()
            {
                _mutex.Dispose();
            }

            [Benchmark]
            public void Run()
            {
                for(int i = 0; i < 8; i++)
                {

                    Task.Run(() => RunInternal());
                }
            }

            void RunInternal()
            {
                while(_counter != 1000000)
                {
                    _mutex.WaitOne();
                    _counter++;
                    _mutex.ReleaseMutex();
                }
            }
        }

        public class ByLock
        {
            private int _counter = 0;
            private object _lockObj = new object();

            [Benchmark]
            public void Run()
            {
                for (int i = 0; i < 8; i++)
                {
                    Task.Run(() => RunInternal());
                }
            }

            void RunInternal()
            {
                while (_counter != 1000000)
                {
                    lock (_lockObj)
                    {
                        _counter++;
                    }
                }
            }
        }

        public class ByCycle
        {
            private int _counter = 0;

            [Benchmark]
            public void Run()
            {
                while (_counter != 1000000)
                {
                    _counter++;
                }
            }
        }

        public class ByInterlocked
        {
            private int _counter = 0;

            [Benchmark]
            public void Run()
            {
                for (int i = 0; i < 8; i++)
                {
                    Task.Run(() => RunInternal());
                }
            }

            void RunInternal()
            {
                while (_counter != 1000000)
                {
                    Interlocked.Increment(ref _counter);
                }
            }
        }

        public class Timer : IDisposable
        {
            Stopwatch _watch;
            string _name;
            public Timer(string name)
            {
                _name = name;
                _watch = new Stopwatch();
                _watch.Start();
            }

            public void Dispose()
            {
                _watch.Stop();
                Console.WriteLine($"{_name}: {_watch.Elapsed.TotalMilliseconds}");
                _watch = null;
                _name = null;
            }
        }
    }
}
