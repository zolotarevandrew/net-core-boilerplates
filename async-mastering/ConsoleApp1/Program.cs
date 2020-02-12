using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                var wait = new SpinWait();
                while (true)
                {
                    if (wait.NextSpinWillYield)
                    {
                        Console.WriteLine("Thread yield!");
                    }
                    Console.WriteLine("Work");
                    wait.SpinOnce();
                }
            });
            thread.Start();


            Console.ReadLine();
        }
    }
}
