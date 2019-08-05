using AsyncAppCore;
using System;
using System.Threading.Tasks;

namespace AsyncUsingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching data - SYNC!");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var output = RunSyncDemo.Start();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Total execution time: { elapsedMs }");

            Console.WriteLine("========================");

            Console.WriteLine("Fetching data - ASYNC!");

            Task.Run(async () =>
            {
                var output = await RunAsyncDemo.Start();
                Console.WriteLine("Fetching data - ASYNC! Done");

            });
        }
    }
}
