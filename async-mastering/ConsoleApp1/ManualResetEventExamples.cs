using System.Threading;
using System.Threading.Tasks;

namespace Promises.Console
{
    public static class ManualResetEventExamples
    {
        public static ManualResetEvent _event = new ManualResetEvent(false);

        public static void Run()
        {
            Task.Run(RunInternal);
            Task.Run(RunInternal);

            System.Console.WriteLine("Press to signal");
            System.Console.ReadLine();
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
