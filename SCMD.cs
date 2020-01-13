using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;

namespace ARKSO
{
    class SCMD
    {
        private static readonly string exeUrl = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
        private static readonly string SCMDZip = Path.Combine(MainWindow.arksoPath, "steamcmd.zip");

        /// <summary>
        /// Download SteamCMD archive from official the Steam CDN
        /// </summary>
        public static void Download()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(exeUrl, SCMDZip);
                    Utils.Log("SteamCMD was downloaded with success", "OK");
                }

            } 
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }        
        }

        /// <summary>
        /// Extract the SteamCMD archive to get the executable
        /// </summary>
        public static void Extract()
        {
            try
            {
                ZipFile.ExtractToDirectory(SCMDZip, MainWindow.arksoPath);
                Utils.Log("SteamCMD was extracted with success", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }         
        }

        /// <summary>
        /// Install SteamCMD
        /// </summary>
        public static void Install()
        {
            try
            {
                ProcessStartInfo pInfo = new ProcessStartInfo($"{File.ReadAllText(Path.Combine(MainWindow.confPath, "steamcmd.aso"))}")
                {
                    Arguments = "+login anonymous +app_update 376030 +quit"
                };
                Process p = Process.Start(pInfo);
                p.WaitForExit();
                Utils.Log("SteamCMD was installed with success", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }
        }
    }
}
