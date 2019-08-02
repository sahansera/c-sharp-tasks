using System.Collections.Generic;

namespace AsyncAppCore
{
    public static class RunSyncDemo
    {
        public static List<WebsiteDataModel> Start()
        {
            var websites = Utils.PrepData();
            var output = new List<WebsiteDataModel>();

            foreach (string site in websites)
            {
                var result = Utils.DownloadWebsite(site);
                output.Add(result);
            }

            return output;
        }
    }
}
