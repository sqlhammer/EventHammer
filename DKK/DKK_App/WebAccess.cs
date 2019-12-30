using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace DKK_App
{
    public static class WebAccess
    {
        public static Version GetLatestEventHammerVersion()
        {
            string json_response = GetWebClientResponse("https://eventhammeronline.com/go/ehversion/");

            JObject json = JObject.Parse(json_response);

            string version = (string)json["content"]["rendered"];
            version = version.Replace("<p>","");
            version = version.Replace("</p>", "");
            version = version.Replace("\n", "");
                        
            return new Version(version);
        }

        public static string GetWebClientResponse(string url)
        {
            var client = new WebClient();

            var response = client.DownloadString(url);

            return response;
        }
    }
}
