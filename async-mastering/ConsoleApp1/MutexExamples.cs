using System.Threading;
using System.Threading.Tasks;

namespace Promises.Console
{
    public static class MutexExamples
    {
        public static Mutex mutex = new Mutex();
        public static bool IsSingleInstance()
        {
            try
            {
                mutex = Mutex.OpenExisting("PERL");
            }
            catch
            {
                mutex = new Mutex(true, "PERL");
                return true;
            }
            return false;
        }

        public static void RunMultipleThreads()
        {
            for(int i = 0; i < 5; i++)
            {
                Task.Run(() => UseResource());
            }
        }

        static void UseResource()
        {
            var thread = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine($"{thread} is requesting the mutex");
            if (mutex.WaitOne(1000))
            {
                System.Console.WriteLine($"{thread} has entered the protected area");

                //Simulate some work
                Thread.Sleep(2000);

                System.Console.WriteLine($"{thread} is leaving the protected area");

                // Release the Mutex.
                mutex.ReleaseMutex();
                System.Console.WriteLine($"{thread} has released the mutex");
            }
            else
            {
                System.Console.WriteLine($"{thread} will not acquire the mutex");
            }
        }
    }
}
