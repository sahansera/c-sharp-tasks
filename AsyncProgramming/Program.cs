using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Downloading");
            //Download();
            //Console.ReadLine();

            int? i = null;
            Console.WriteLine(i);
        }

        static async void Download() {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetStringAsync("http://rouxacademy.com");
            Console.WriteLine(data);
        }

    }
}
