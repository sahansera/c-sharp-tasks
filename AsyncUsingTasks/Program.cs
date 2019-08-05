using AsyncAppCore;
using Nito.AsyncEx;
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

            // Main returns to the OS - so your program exits.
            Task.Run(async () =>
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var output = await RunAsyncDemo.Start();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine($"Total execution time: { elapsedMs }");
            });

            // As a workaround to the above, we can provide our own async-compatible context
            try
            {
                AsyncContext.Run(() => RunAsyncDemo.Start());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
