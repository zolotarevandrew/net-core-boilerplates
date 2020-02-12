using Concurrent.Schedulers;
using System;
using System.Threading;

namespace Concurrent.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var syncContext = new CustomSyncContext2();
            for (int i = 0; i < 20; i++) syncContext.Post(DoWork, null);

            System.Console.ReadLine();
            syncContext.Dispose();
        }

        static void DoWork(object state)
        {
            var taskId = Guid.NewGuid();
            var name = Thread.CurrentThread.ManagedThreadId;
            int i = 0;
            do
            {
                i++;
            }
            while (i < 10000);

            System.Console.WriteLine($"taskId: {taskId}, {name} finished work");
        }
    }
}
