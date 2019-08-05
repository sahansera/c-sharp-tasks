using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAppCore
{
    public static class RunAsyncDemo
    {
        public static async Task<List<WebsiteDataModel>> Start()
        {
            var websites = Utils.PrepData();
            var output = new List<WebsiteDataModel>();

            foreach (string site in websites)
            {
                var result = await Task.Run(() => Utils.DownloadWebsite(site));
                output.Add(result);
            }
            return output;
        }
    }
}
