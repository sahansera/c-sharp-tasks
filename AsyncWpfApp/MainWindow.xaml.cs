using AsyncAppCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SyncBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            ReportOutput("Sync Task Running...\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ReportOutput("Sync Task Stopped...\n");
            ReportOutput($"Elapsed Time: {elapsedMs}\n");

        }

        private async void AsyncBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            ReportOutput("Async Task Running...\n");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await RunDownloadAsync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ReportOutput("Async Task Stopped...\n");
            ReportOutput($"Elapsed Time: {elapsedMs}\n");

        }

        private async void AsyncParallelBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            ReportOutput("Async Parallel Running...\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadParallelAsync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ReportOutput("Async Parallel Stopped...\n");
            ReportOutput($"Elapsed Time: {elapsedMs}\n");
        }

        private void RunDownloadSync()
        {
            List<string> websites = Utils.PrepData();

            foreach (string site in websites)
            {
                var results = Utils.DownloadWebsite(site);
                outputTxt.Text += Utils.ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var websites = Utils.PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            try
            {
                foreach (var site in websites)
                {
                    tasks.Add(Task.Run(() => Utils.DownloadWebsite(site)));
                }

                var results = await Task.WhenAll(tasks);

                foreach (var result in results)
                {
                    outputTxt.Text += Utils.ReportWebsiteInfo(result);
                }
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        private async Task RunDownloadAsync()
        {
            List<string> websites = Utils.PrepData();

            try
            {
                foreach (string site in websites)
                {
                    var results = await Task.Run(() => Utils.DownloadWebsite(site));
                    outputTxt.Text += Utils.ReportWebsiteInfo(results);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

        }

        private void ClearOutput()
        {
            outputTxt.Text = "";
        }

        private void ReportOutput(string output)
        {
            outputTxt.Text += output;
        }

    }
}
