using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ARKSO.Graphics
{
    class Loading
    {
        public static Label isInstallingLabel;

        public static void Build(Grid Grid, string message)
        {
            isInstallingLabel = new Label
            {
                Content = message,
                Width = 800,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 32,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Trebuchet MS")
            };
            Grid.Children.Add(isInstallingLabel);
        }
    }
}
