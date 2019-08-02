using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAppCore
{
    public class RunAsyncParallelDemo
    {
        public static async Task<List<WebsiteDataModel>> Start()
        {
            var websites = Utils.PrepData();
            var output = new List<WebsiteDataModel>();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites)
            {
                tasks.Add(Task.Run(() => Utils.DownloadWebsite(site)));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                output.Add(result);
            }

            return output;
        }
    }
}
