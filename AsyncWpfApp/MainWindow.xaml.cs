using AsyncAppCore;
using System.Collections.Generic;
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

        // Just plain o'l sync
        private void SyncBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            DisplayTaskDetails("Sync Task Running...\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var output = RunSyncDemo.Start();
            RenderListOutput(output);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            DisplayTaskDetails("Sync Task Stopped...\n");
            DisplayTaskDetails($"Elapsed Time: {elapsedMs}\n");

        }

        // Runs parallel tasks, but time adds up
        private async void AsyncBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            DisplayTaskDetails("Async Task Running...\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var output = await RunAsyncDemo.Start();
            RenderListOutput(output);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            DisplayTaskDetails("Async Task Stopped...\n");
            DisplayTaskDetails($"Elapsed Time: {elapsedMs}\n");

        }

        // Why is this fast?
        // Wait time? Runs in parallel but takes only the max of one task because we are doing WhenAll
        private async void AsyncParallelBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            DisplayTaskDetails("Async Parallel Running...\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var output = await RunAsyncParallelDemo.Start();
            RenderListOutput(output);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            DisplayTaskDetails("Async Parallel Stopped...\n");
            DisplayTaskDetails($"Elapsed Time: {elapsedMs}\n");
        }

        private void ClearOutput()
        {
            outputTxt.Text = "";
        }

        private void DisplayTaskDetails(string output)
        {

            outputTxt.Text += output;
        }

        private void RenderListOutput(List<WebsiteDataModel> output)
        {
            foreach (var item in output)
            {
                DisplayTaskDetails(Utils.ReportWebsiteInfo(item));
            }
        }

    }
}
