using System.Windows;
using System.Windows.Controls;

namespace ARKSO.Graphics
{
    class Clear
    {
        /// <summary>
        /// Clear installation graphics
        /// </summary>
        public static void Installation(Grid Grid)
        {
            Grid.Children.Remove(Graphics.Installation.helloLabel);
            Grid.Children.Remove(Graphics.Installation.textLabel);
            Grid.Children.Remove(Graphics.Installation.isInstalledButton);
            Grid.Children.Remove(Graphics.Installation.notInstalledButton);
        }

        /// <summary>
        /// Clear is installing graphics
        /// </summary>
        public static void IsInstalling(Grid Grid)
        {
            Grid.Children.Remove(Loading.isInstallingLabel);
        }

        /// <summary>
        /// Clear main graphics
        /// </summary>
        public static void Main(Grid Grid)
        {
            Grid.Children.Remove(Graphics.Main.versionLabel);
            Grid.Children.Remove(Graphics.Main.donateLabel);
            Grid.Children.Remove(Graphics.Main.serverBox);
            Grid.Children.Remove(Graphics.Main.statusDescLabel);
            Grid.Children.Remove(Graphics.Main.statusLabel);
            Grid.Children.Remove(Graphics.Main.latencyDescLabel);
            Grid.Children.Remove(Graphics.Main.latencyLabel);
            Grid.Children.Remove(Graphics.Main.addressDescLabel);
            Grid.Children.Remove(Graphics.Main.addressLabel);
            Grid.Children.Remove(Graphics.Main.shareAddressButton);
            Grid.Children.Remove(Graphics.Main.settingsBox);
            Grid.Children.Remove(Graphics.Main.nameLabel);
            Grid.Children.Remove(Graphics.Main.nameTextbox);
            Grid.Children.Remove(Graphics.Main.mapLabel);
            Grid.Children.Remove(Graphics.Main.mapCbb);
            Grid.Children.Remove(Graphics.Main.playersLabel);
            Grid.Children.Remove(Graphics.Main.playersTextbox);
            Grid.Children.Remove(Graphics.Main.VACLabel);
            Grid.Children.Remove(Graphics.Main.VACCbb);
            Grid.Children.Remove(Graphics.Main.battlEyeLabel);
            Grid.Children.Remove(Graphics.Main.battlEyeCbb);
            Grid.Children.Remove(Graphics.Main.passwordLabel);
            Grid.Children.Remove(Graphics.Main.passwordTextbox);
            Grid.Children.Remove(Graphics.Main.adminPasswordLabel);
            Grid.Children.Remove(Graphics.Main.adminPasswordTextbox);
            Grid.Children.Remove(Graphics.Main.portLabel);
            Grid.Children.Remove(Graphics.Main.portTextbox);
            Grid.Children.Remove(Graphics.Main.queryPortLabel);
            Grid.Children.Remove(Graphics.Main.queryPortTextbox);
            Grid.Children.Remove(Graphics.Main.argumentsLabel);
            Grid.Children.Remove(Graphics.Main.argumentsTextbox);
            Grid.Children.Remove(Graphics.Main.optionsLabel);
            Grid.Children.Remove(Graphics.Main.optionsTextbox);
            Grid.Children.Remove(Graphics.Main.manualConfigLabel);
            Grid.Children.Remove(Graphics.Main.gameIniButton);
            Grid.Children.Remove(Graphics.Main.gameUserSettingsIniButton);
            Grid.Children.Remove(Graphics.Main.managementBox);
            Grid.Children.Remove(Graphics.Main.hideConsoleCheckbox);
            Grid.Children.Remove(Graphics.Main.actionBox);
            Grid.Children.Remove(Graphics.Main.turnOnOffButton);
            Grid.Children.Remove(Graphics.Main.updateButton);
            Grid.Children.Remove(Graphics.Main.backupButton);
            Grid.Children.Remove(Graphics.Main.credits);

            Application.Current.MainWindow.Width = 800;
            Grid.Width = 800;
            MainWindow.CenterApp();          
        }

        /// <summary>
        /// Clear update graphics
        /// </summary>
        public static void Update(Grid Grid)
        {
            Grid.Children.Remove(Graphics.Update.textLabel);
            Grid.Children.Remove(Graphics.Update.yesButton);
            Grid.Children.Remove(Graphics.Update.noButton);
        }
    }
}