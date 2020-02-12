using System.Threading;
using System.Threading.Tasks;

namespace Promises.Console
{
    public static class SemaphoreExamples
    {
        private static Semaphore _pool;
        public static void Run()
        {
            _pool = new Semaphore(0, 3);
 
            for (int i = 1; i <= 5; i++)
            {
                Task.Run(() => Work());
            }

            Thread.Sleep(500);

            System.Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);

            System.Console.WriteLine("Main thread exits.");
        }

        static void Work()
        {
            int num = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine($"Thread {num} begins " + "and waits for the semaphore.");
            _pool.WaitOne();

            System.Console.WriteLine($"Thread {num} enters the semaphore.");

            Thread.Sleep(1000);

            System.Console.WriteLine($"Thread {num} releases the semaphore.");
            System.Console.WriteLine($"Thread {num} previous semaphore count: {_pool.Release()}");
        }
    }
}
