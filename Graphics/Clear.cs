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
            Grid.Children.Remove(Graphics.Main.argumentsLabel);
            Grid.Children.Remove(Graphics.Main.argumentsTextbox);
            Grid.Children.Remove(Graphics.Main.optionsLabel);
            Grid.Children.Remove(Graphics.Main.optionsTextbox);
            Grid.Children.Remove(Graphics.Main.turnOnOffButton);
            Grid.Children.Remove(Graphics.Main.updateButton);
            Grid.Children.Remove(Graphics.Main.statusLabel);
            Grid.Children.Remove(Graphics.Main.latencyLabel);
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