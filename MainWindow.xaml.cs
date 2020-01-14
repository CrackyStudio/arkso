using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ARKSO
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        private static readonly string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private static Grid Grid;

        public static Timer serverTimer = new Timer();
        public static string arksoPath = Path.Combine(roamingPath, "ARK Server Organiser");
        public static string confPath = Path.Combine(arksoPath, "conf");
        public static string logsPath = Path.Combine(arksoPath, "logs");
        public static string currentVersion;

        /// <summary>
        /// Load application
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();  
            Grid = ((MainWindow)Application.Current.MainWindow).AppGrid;

            if (!Directory.Exists(arksoPath))
            {
                SetupApp();
            }

            // Check for app update
            if (GitHub.IsNewVersionAvailable() == true)
            {
                Graphics.Update.Build(Grid);
            } else
            {
                BuildInterface();
            }     
        }

        /// <summary>
        /// Exit application
        /// </summary>
        private void ExitApp(object sender, RoutedEventArgs e)
        {
            if (Server.serverProcess == null || Server.serverProcess.HasExited)
            {
                Application.Current.Shutdown();
            }
            else
            {
                /* Tell user that app can't be closed while server is running */
            }
        }

        /// <summary>
        /// Make the app draggable
        /// </summary>
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Close/Show MainWindow and app system tray icon
        /// </summary>
        private void SendToTray(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow.IsVisible)
            {
                TrayIcon.Visibility = Visibility.Visible;
                App.Current.MainWindow.Hide();
            } else
            {
                TrayIcon.Visibility = Visibility.Hidden;
                App.Current.MainWindow.Show();
            }
        }

        /// <summary>
        /// Donate via PayPal
        /// </summary>
        public static void Donate(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.paypal.me/officialcracky/5");
        }

        /// <summary>
        /// Install app folder and necessary contents
        /// </summary>
        public static void SetupApp()
        {
            try
            {
                Directory.CreateDirectory(arksoPath);
                Directory.CreateDirectory(confPath);
                Directory.CreateDirectory(logsPath);
                Json.Create();
                Utils.StoreData("configured", false);
                Utils.Log($"ARKSO app path successfully created in \"{arksoPath}\"", "OK");
            }
            catch (Exception ex)
            {
                // Cannot log because logs are saved in ARKSO folder
                // Utils.Log(ex.Message, "ERROR")
                Trace.WriteLine(ex);
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Show where SCMD is installed
        /// </summary>
        public static void SelectSCMDLocation(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = false,
                Title = "Select steamcmd.exe"
            };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                Utils.StoreData("steamcmd", dialog.FileName);
                Utils.StoreData("configured", true);
                Graphics.Clear.Installation(Grid);
                BuildInterface();
            }
        }

        /// <summary>
        /// Install SCMD & ARK Survival Evolved Dedicated Server
        /// </summary>
        private static void SetInstallation()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select a folder to install SteamCMD"
            };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                string installDir = dialog.FileName;
                bool isValidated = Utils.ValidateInstall(installDir);
                if (!isValidated)
                {
                    installDir = Path.Combine(installDir, "SteamCMD");
                }
                Utils.StoreData("steamcmd", $"{installDir}\\steamcmd.exe");
                SCMD.Download();
                SCMD.Extract();
                File.Copy(Path.Combine(arksoPath, "steamcmd.exe"), Path.Combine(installDir, "steamcmd.exe"), true);
                File.Delete(Path.Combine(arksoPath, "steamcmd.zip"));
                File.Delete(Path.Combine(arksoPath, "steamcmd.exe"));
                SCMD.Install();
                Utils.StoreData("configured", true);
                Utils.Log("Check if app is configured - Result: true", "OK");
                Graphics.Clear.IsInstalling(Grid);
                BuildInterface();
            }
        }

        /// <summary>
        /// Set grid and start installation
        /// </summary>
        public static void SCMDSetup(object sender, RoutedEventArgs e)
        {
            Graphics.Clear.Installation(Grid);
            Graphics.Loading.Build(Grid, "Please wait during setup...");
            SetInstallation();
        }

        /// <summary>
        /// Build app interface
        /// </summary>
        public static void BuildInterface()
        {
            if (!Utils.IsAppConfigured())
            {
                Graphics.Installation.Build(Grid);         
            } else
            {
                Graphics.Main.Build(Grid);
            }
        }

        /// <summary>
        /// Build app interface
        /// </summary>
        public static void BuildInterface(object sender, RoutedEventArgs e)
        {
            Graphics.Clear.Update(Grid);
            BuildInterface();
        }

        /// <summary>
        /// Center app in screen after a resize
        /// </summary>
        public static void CenterApp()
        {
            Rect workArea = SystemParameters.WorkArea;
            Application.Current.MainWindow.Left = (workArea.Width - Application.Current.MainWindow.Width) / 2 + workArea.Left;
            Application.Current.MainWindow.Top = (workArea.Height - Application.Current.MainWindow.Height) / 2 + workArea.Top;
        }

        /// <summary>
        /// Start and Stop ARK server
        /// </summary>
        public static void StartNStopServer(object sender, RoutedEventArgs e)
        {
            if (Graphics.Main.turnOnOffButton.Content.ToString() == "Start server")
            {
                // Start server
                Graphics.Main.turnOnOffButton.Content = "Stop server";
                Graphics.Main.updateButton.IsEnabled = false;
                Graphics.Main.statusLabel.Foreground = new SolidColorBrush(Colors.Yellow);
                Graphics.Main.statusLabel.Content = "Server is starting";
                Server.Start();
                serverTimer.Elapsed += new ElapsedEventHandler(Utils.OnTimedEvent);
                serverTimer.Interval = 1000;
                serverTimer.Enabled = true;
            }
            else
            {
                // Stop server
                serverTimer.Enabled = false;
                Server.Stop();
                Graphics.Main.turnOnOffButton.Content = "Start server";
                Graphics.Main.updateButton.IsEnabled = true;
                Graphics.Main.statusLabel.Foreground = new SolidColorBrush(Colors.Red);
                Graphics.Main.statusLabel.Content = "Server is off";
                Graphics.Main.latencyLabel.Content = "";
                Graphics.Main.latencyLabel.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// Update ARK server
        /// </summary>
        public static void UpdateServer(object sender, RoutedEventArgs e)
        {
            Server.Update();            
        }

        /// <summary>
        /// Update ARKSO app
        /// </summary>
        public static void UpdateApp(object sender, RoutedEventArgs e)
        {
            string latestVersion = GitHub.GetLatestVersion();
            string appDestination = Path.Combine(arksoPath, $"ARK Server Organiser {latestVersion}.exe");
            string downloadUrl = GitHub.GetLatestExecutable();
            string activeAppPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            // Download new release
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(downloadUrl, appDestination);
                    Utils.Log($"ARKSO {latestVersion} was downloaded with success", "OK");
                }
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }

            // Create shortcut
            try
            {
                Utils.CreateShortcut($"ARK Server Organiser {latestVersion}", activeAppPath, appDestination);
            }
            catch (Exception ex)
            {
                Utils.Log($"{ex.Message}\n{ex.InnerException}", "ERROR");
                Application.Current.Shutdown();
            }

            // Run new version and close this one
            try
            {
                ProcessStartInfo pInfo = new ProcessStartInfo($"{arksoPath}\\ARK Server Organiser {latestVersion}.exe");
                Process p = Process.Start(pInfo);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }
        }
    }
}
