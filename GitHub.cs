using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace ARKSO
{
    class GitHub
    {
        private static JObject json = new JObject();

        /// <summary>
        /// Returns if a new version of ARKSO is available (bool)
        /// </summary>
        public static bool IsNewVersionAvailable()
        {
            try
            {
                MainWindow.currentVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
                string latestVersion;
                string html = string.Empty;
                string URL = @"https://api.github.com/repos/CrackyStudio/arkso/releases/latest";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                json = Json.ParseString(html);

                MainWindow.currentVersion = MainWindow.currentVersion.Substring(0, Math.Min(MainWindow.currentVersion.Length, 3));
                latestVersion = json["tag_name"].ToString().TrimStart('v');

                double cv = double.Parse(MainWindow.currentVersion);
                double lv = double.Parse(latestVersion);

                if (cv < lv)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("");
                    return false;
                }
            } 
            catch (Exception ex)
            {
                MainWindow.currentVersion = MainWindow.currentVersion.Substring(0, Math.Min(MainWindow.currentVersion.Length, 3));
                Utils.Log($"{ex.Message}\n{ex.InnerException}", "ERROR");
                return false;
            }
        }

        /// <summary>
        /// Returns download url of latest released version of ARKSO
        /// </summary>
        public static string GetLatestExecutable()
        {
            return json["assets"][0]["browser_download_url"].ToString();
        }

        /// <summary>
        /// Returns latest release version of ARKSO
        /// </summary>
        /// <returns></returns>
        public static string GetLatestVersion()
        {
            return json["tag_name"].ToString().TrimStart('v');
        }
    }
}
