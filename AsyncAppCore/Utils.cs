using System;
using System.Collections.Generic;
using System.Net;

namespace AsyncAppCore
{
    public static class Utils
    {
        public static string ReportWebsiteInfo(WebsiteDataModel data)
        {
            return ($"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long.{ Environment.NewLine }");
        }

        public static WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;
        }

        public static List<string> PrepData()
        {
            var output = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.stackoverflow.com"
            };

            return output;
        }
    }
}
