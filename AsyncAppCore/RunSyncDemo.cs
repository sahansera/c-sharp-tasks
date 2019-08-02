using System.Collections.Generic;

namespace AsyncAppCore
{
    public class RunSyncDemo
    {
        public void Start()
        {
            RunDownloadSync();
        }

        private void RunDownloadSync()
        {
            List<string> websites = Utils.PrepData();

            foreach (string site in websites)
            {
                var results = Utils.DownloadWebsite(site);
                Utils.ReportWebsiteInfo(results);
            }
        }
    }
}
