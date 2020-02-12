using System.Threading;
using System.Threading.Tasks;

namespace Promises.Console
{
    public class VolatileExamples
    {
        bool _stop;

        public void Run()
        {
            _stop = false;
            System.Console.WriteLine("Started");
            Task.Run(() =>
            {
                RunInternal();
            });
            Task.Run(() =>
            {
                RunInternal();
            });
            //Task.Delay(2000).Wait();
            Thread.Sleep(2000);

            _stop = true;
        }

        void RunInternal()
        {
            int x = 0;
            while(!_stop)
            {
                x++;
            }
            System.Console.WriteLine("Finished");
        }
    }
}
