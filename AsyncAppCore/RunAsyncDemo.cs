using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAppCore
{
    public class RunAsyncDemo
    {
        public async Task Start()
        {
            await RunDownloadAsync();
        }

        public async Task RunDownloadAsync()
        {
            List<string> websites = Utils.PrepData();

            foreach (string site in websites)
            {
                var results = await Task.Run(() => Utils.DownloadWebsite(site));
                Utils.ReportWebsiteInfo(results);
            }
        }
    }
}
