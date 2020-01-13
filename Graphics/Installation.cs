using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ARKSO.Graphics
{
    class Installation
    {
        public static Label helloLabel;
        public static Label textLabel;
        public static Button isInstalledButton;
        public static Button notInstalledButton;

        /// <summary>
        /// Build installation interface of ARKSO (setup phase)
        /// </summary>
        public static void Build(Grid AppGrid)
        {
            helloLabel = new Label
            {
                Content = $"Hello {Utils.GetUserName()}!",
                Width = 800,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -100, 0, 0),
                FontSize = 32,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS")
            };
            AppGrid.Children.Add(helloLabel);

            textLabel = new Label
            {
                Content = "ARKSO needs SteamCMD, do you already have it installed somewhere?",
                Width = 800,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS")
            };
            AppGrid.Children.Add(textLabel);

            isInstalledButton = new Button
            {
                Content = "Yes, let me show you where",
                Width = 200,
                Height = Double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(-250, 100, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS"),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };
            isInstalledButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.SelectSCMDLocation));
            AppGrid.Children.Add(isInstalledButton);

            notInstalledButton = new Button
            {
                Content = "No, let's install it",
                Width = 200,
                Height = Double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(250, 100, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS"),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };
            notInstalledButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.SCMDSetup));
            AppGrid.Children.Add(notInstalledButton);
        }
    }
}
