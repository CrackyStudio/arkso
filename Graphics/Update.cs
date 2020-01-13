using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ARKSO.Graphics
{
    class Update
    {
        public static Label textLabel;
        public static Button yesButton;
        public static Button noButton;

        /// <summary>
        /// Build installation interface of ARKSO (setup phase)
        /// </summary>
        public static void Build(Grid AppGrid)
        {
            textLabel = new Label
            {
                Content = "A new version is available, would you like to udpate?",
                Width = 800,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -50, 0, 0),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS")
            };
            AppGrid.Children.Add(textLabel);

            yesButton = new Button
            {
                Content = "Yes",
                Width = 200,
                Height = Double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(-250, 50, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS"),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };
            yesButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.UpdateApp));
            AppGrid.Children.Add(yesButton);

            noButton = new Button
            {
                Content = "No",
                Width = 200,
                Height = Double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(250, 50, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS"),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };
            noButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.BuildInterface));
            AppGrid.Children.Add(noButton);
        }
    }
}
