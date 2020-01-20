using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace ARKSO
{
    class Utils
    {
        /// <summary>
        /// Save string into logs file
        /// </summary>
        public static void Log(string message, string type)
        {
            try
            {
                using (StreamWriter sw = System.IO.File.AppendText(Path.Combine(MainWindow.logsPath, "Logs.txt")))
                {
                    sw.Write("\r\n");
                    sw.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    sw.WriteLine($"|--- {type}: {message}");
                    sw.WriteLine("-------------------------------");
                }
            } catch (Exception ex)
            {
                throw ex;
            }      
        }

        /// <summary>
        /// Create file with static data forever
        /// </summary>
        public static void StoreData(string filename, string data)
        {
            try
            {
                using (StreamWriter sw = System.IO.File.CreateText(Path.Combine(MainWindow.confPath, $"{filename}.aso")))
                {
                    sw.Write(data);
                }
                Log($"Data was stored in {filename}.aso with success", "OK");
            }
            catch (Exception ex)
            {
                Log(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// Create file with static data forever (convert data type to string)
        /// </summary>
        public static void StoreData(string filename, bool data)
        {
            try
            {
                StoreData(filename, data.ToString().ToLower());
            }
            catch (Exception ex)
            {
                Log(ex.Message, "ERROR");
            }         
        }

        /// <summary>
        /// Returns username from windows user folder
        /// </summary>
        public static string GetUserName()
        {
            try
            {
                string userPath = Environment.GetEnvironmentVariable("USERPROFILE");
                int p = userPath.LastIndexOf("\\") + 1;
                return Capitalize(userPath.Substring(p, userPath.Length - p));
            }
            catch (Exception ex)
            {
                Log(ex.Message, "ERROR");
                return "player";
            }
        }

        /// <summary>
        /// Return string with first letter Capitalized
        /// </summary>
        public static string Capitalize(string input)
        {
            try
            {
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            catch (Exception ex)
            {
                Log(ex.Message, "ERROR");
                return input;
            }
        }

        /// <summary>
        /// Returns if app is configured
        /// </summary>
        public static bool IsAppConfigured()
        {
            try
            {
                if (System.IO.File.ReadAllText(Path.Combine(MainWindow.confPath, "configured.aso")) == "false")
                {
                    Log("Check if app is configured - Result: false", "OK");
                    return false;
                }
                Log("Check if app is configured - Result: true", "OK");
                return true;
            }
            catch (Exception ex)
            {
                Log(ex.Message, "ERROR");
                return false;
            }
        }

        /// <summary>
        /// Check if install path contains steamcmd. Returns bool
        /// </summary>
        public static bool ValidateInstall(string path)
        {
            if (path.ToLower().Split('\\').Last() != "steamcmd")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Textbox content is valided only if is number
        /// </summary>
        public static void TextBoxNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Create a windows shortcut
        /// </summary>
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            /* Remove .lnk if already exists */
            // Remove filename.exe from path
            int index = shortcutPath.LastIndexOf("\\");
            if (index > 0)
                shortcutPath = shortcutPath.Substring(0, index);

            string shortcutLocation = Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            
            shortcut.Description = "ARK Server Organiser (ARKSO)";
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }

        /// <summary>
        /// App timer
        /// </summary>
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            bool autoUnB = bool.Parse(Json.GetProperty(Json.serverJson, "auto_unb"));
            string updateTime = Json.GetProperty(Json.serverJson, "auto_unb_time");
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            if (autoUnB && $"{updateTime}:00" == currentTime)
            {
                Server.AutoBackupNUpdate();
            }

            dynamic latency = Server.GetLatency();
            Color color = Colors.Black;

            if (!(latency is string))
            {
                switch (latency)
                {
                    case var _ when latency <= 60:
                        color = Colors.Green;
                        break;
                    case var _ when latency > 60 && latency <= 80:
                        color = Colors.Yellow;
                        break;
                    case var _ when latency > 80 && latency <= 100:
                        color = Colors.Orange;
                        break;
                    case var _ when latency > 100:
                        color = Colors.Red;
                        break;
                    default:
                        color = Colors.Black;
                        break;
                }

                Application.Current.Dispatcher.BeginInvoke(new Action(delegate
                {
                    if (Graphics.Main.statusLabel.Content.ToString() != "ONLINE")
                    {
                        Graphics.Main.statusLabel.Foreground = new SolidColorBrush(Colors.Green);
                        Graphics.Main.statusLabel.Content = "ONLINE";
                    }

                    Graphics.Main.latencyLabel.Foreground = new SolidColorBrush(color);
                    Graphics.Main.latencyLabel.Content = $"{latency} ms";

                }));
            }           
        }

        /// <summary>
        /// Edit config files
        /// </summary>
        public static void EditFile(object sender, RoutedEventArgs e)
        {
            var control = (Button)sender;
            var controlName = control.Name;
            string steamCMDPath = System.IO.File.ReadAllText(Path.Combine(MainWindow.confPath, "steamcmd.aso"));
            steamCMDPath = steamCMDPath.Remove(steamCMDPath.Length - 13);
            string file = $"{steamCMDPath}\\steamapps\\common\\ARK Survival Evolved Dedicated Server\\ShooterGame\\Saved\\Config\\WindowsServer\\{controlName}.ini";
            Process.Start(file);
        }

        /// <summary>
        /// Copy all files and folders
        /// </summary>
        public static void CopyFilesRecursively(string source, string target)
        {
            if (!Directory.Exists(new DirectoryInfo(target).FullName))
            {
                foreach (string dirPath in Directory.GetDirectories(source, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(source, target));

                foreach (string newPath in Directory.GetFiles(source, "*.*",
                    SearchOption.AllDirectories))
                    System.IO.File.Copy(newPath, newPath.Replace(source, target), true);
            }               
        }

        /// <summary>
        /// Textbox content is valided only if is number
        /// </summary>
        public static void TimePicker(object sender, RoutedEventArgs e)
        {
            var control = (TimeSpanUpDown)sender;
            var controlValue = control.Value.ToString();
            var value = controlValue.Remove(controlValue.Length - 3);
            Json.Update(Json.serverJson, "auto_unb_time", value);
        }
    }
}
