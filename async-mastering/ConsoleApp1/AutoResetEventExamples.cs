using System.Threading;
using System.Threading.Tasks;

namespace Promises.Console
{
    public static class AutoResetEventExamples
    {
        public static AutoResetEvent _event = new AutoResetEvent(false);

        public static void Run()
        {
            Task.Run(RunInternal);
            Task.Run(RunInternal);

            System.Console.WriteLine("Press to signal");
            System.Console.ReadLine();
            _event.Set();
            _event.Set();

            System.Console.ReadLine();
        }

        static void RunInternal()
        {
            var name = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine($"Thread {name} is waiting");
            _event.WaitOne();
            System.Console.WriteLine($"Thread {name} finished");
        }
    }
}
