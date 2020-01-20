using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ARKSO
{
    class Server
    {
        public static ProcessWindowStyle consoleStyle = ProcessWindowStyle.Normal;

        public static Process serverProcess;
        /// <summary>
        /// Start server
        /// </summary>
        public static void Start()
        {
            try
            {
                string steamCMDPath = File.ReadAllText(Path.Combine(MainWindow.confPath, "steamcmd.aso"));
                steamCMDPath = steamCMDPath.Remove(steamCMDPath.Length - 13);
                string SGSPath = steamCMDPath + "\\steamapps\\common\\ARK Survival Evolved Dedicated Server\\ShooterGame\\Binaries\\Win64\\ShooterGameServer.exe";

                if (bool.Parse(Json.GetProperty(Json.serverJson, "hide_console")))
                {
                    consoleStyle = ProcessWindowStyle.Hidden;
                }

                ProcessStartInfo pInfo = new ProcessStartInfo(SGSPath)
                {
                    WindowStyle = consoleStyle,
                    Arguments = $"\"{Json.GetProperty(Json.serverJson, "map")}?listen?SessionName={Json.GetProperty(Json.serverJson, "name")}?ServerAdminPassword={Json.GetProperty(Json.serverJson, "admin_password")}?ServerPassword={Json.GetProperty(Json.serverJson, "password")}?Port={Json.GetProperty(Json.serverJson, "port")}?QueryPort={Json.GetProperty(Json.serverJson, "query_port")}?MaxPlayers={Json.GetProperty(Json.serverJson, "players")}{Json.GetProperty(Json.serverJson, "options")}\" -{Json.GetProperty(Json.serverJson, "vac")} -{Json.GetProperty(Json.serverJson, "battleye")} {Json.GetProperty(Json.serverJson, "arguments")}"
                };
                serverProcess = Process.Start(pInfo);
                Utils.Log("Server started", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Stop server
        /// </summary>
        public static void Stop()
        {
            try
            {
                Process[] proc = Process.GetProcessesByName("ShooterGameServer");

                proc[0].Kill();

                Utils.Log("Server stopped", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Update server
        /// </summary>
        public static void Update()
        {
            try
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(delegate
                {
                    Graphics.Main.turnOnOffButton.IsEnabled = false;
                    Graphics.Main.updateButton.IsEnabled = false;
                }));
                
                ProcessStartInfo pInfo = new ProcessStartInfo($"{File.ReadAllText(Path.Combine(MainWindow.confPath, "steamcmd.aso"))}")
                {
                    Arguments = "+login anonymous +app_update 376030 +quit"
                };
                Process p = Process.Start(pInfo);
                /* WaitForExit() Is freezing graphics */
                p.WaitForExit();   
                Utils.Log("Server has been updated", "OK");

                Application.Current.Dispatcher.BeginInvoke(new Action(delegate
                {
                    Graphics.Main.turnOnOffButton.IsEnabled = true;
                    Graphics.Main.updateButton.IsEnabled = true;
                }));            
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Returns external/public IP address
        /// </summary>
        public static string GetIpAddress()
        {
            string url = "http://checkip.dyndns.org";
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        /// <summary>
        /// Returns server latency
        /// </summary>
        public static void GetLatency(object sender, RoutedEventArgs e)
        {
            GetLatency();
        }

        /// <summary>
        /// Returns server latency
        /// </summary>
        public static dynamic GetLatency()
        {
            try
            {
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(MainWindow.serverIP), MainWindow.serverPort);
                using (UdpClient client = new UdpClient())
                {
                    client.Client.ReceiveTimeout = 100;
                    byte[] request = new byte[] { 255, 255, 255, 255, Convert.ToByte(Strings.Asc("V")), 255, 255, 255, 255 };
                    Stopwatch sWatch = Stopwatch.StartNew();
                    client.Send(request, request.Length, server);
                    byte[] response = client.Receive(ref server);
                    sWatch.Stop();
                    return sWatch.ElapsedMilliseconds;
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    Console.WriteLine("Request Timed Out");
                }
                else
                {
                    Utils.Log($"{ex.Message}\n{ex.InnerException}", "ERROR");
                }
                return "--";
            }
        }

        /// <summary>
        /// Set server console property to visible or hidden
        /// </summary>
        public static void UpdateCheckbox(object sender, RoutedEventArgs e)
        {
            var control = (CheckBox)sender;
            var isChecked = control.IsChecked;
            Json.Update(Json.serverJson, control.Name, isChecked.ToString());
        }

        /// <summary>
        /// Backup server data
        /// </summary>
        public static void Backup(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        /// <summary>
        /// Backup server data
        /// </summary>
        public static void Backup()
        {
            /* Disable backup if server is started */
            string date = DateTime.Now.ToString("yyyy.MM.dd - HH.mm");
            string steamCMDPath = File.ReadAllText(Path.Combine(MainWindow.confPath, "steamcmd.aso"));
            steamCMDPath = steamCMDPath.Remove(steamCMDPath.Length - 13);
            string serverData = $"{steamCMDPath}\\steamapps\\common\\ARK Survival Evolved Dedicated Server\\ShooterGame\\Saved";
            string backupFolder = $"{MainWindow.arksoPath}\\backups\\{date}";

            Application.Current.Dispatcher.BeginInvoke(new Action(delegate
            {
                Graphics.Main.turnOnOffButton.IsEnabled = false;
                Graphics.Main.updateButton.IsEnabled = false;
                Graphics.Main.backupButton.IsEnabled = false;
                Graphics.Main.statusLabel.Foreground = new SolidColorBrush(Colors.AliceBlue);
                Graphics.Main.statusLabel.Content = "UPDATE";
            }));


            Utils.CopyFilesRecursively(serverData, backupFolder);

            Application.Current.Dispatcher.BeginInvoke(new Action(delegate
            {
                Graphics.Main.turnOnOffButton.IsEnabled = true;
                Graphics.Main.updateButton.IsEnabled = true;
                Graphics.Main.backupButton.IsEnabled = true;
                Graphics.Main.statusLabel.Foreground = new SolidColorBrush(Colors.Red);
                Graphics.Main.statusLabel.Content = "OFFLINE";
            }));
        }

        /// <summary>
        /// Backup and Update server automatically
        /// </summary>
        public static void AutoBackupNUpdate()
        {
            Stop();
            Backup();
            Update();
            Start();
        }

        /// <summary>
        /// Get update time
        /// </summary>
        public static TimeSpan GetUpdateTime()
        {
            string time = Json.GetProperty(Json.serverJson, "auto_unb_time");
            if (time != "")
            {
                int hours = int.Parse(time.Split(':')[0]);
                int minutes = int.Parse(time.Split(':')[1]);

                return new TimeSpan(0, hours, minutes, 0);
            }
            return new TimeSpan(0, 0, 0, 0);
        }
    }
}
