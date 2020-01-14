using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ARKSO.Graphics
{
    class Main
    {
        public static Label versionLabel;
        public static Label nameLabel;
        public static TextBox nameTextbox;
        public static Label mapLabel;
        public static ComboBox mapCbb;
        public static Label playersLabel;
        public static TextBox playersTextbox;
        public static Label VACLabel;
        public static ComboBox VACCbb;
        public static Label battlEyeLabel;
        public static ComboBox battlEyeCbb;
        public static Label passwordLabel;
        public static TextBox passwordTextbox;
        public static Label adminPasswordLabel;
        public static TextBox adminPasswordTextbox;
        public static Label argumentsLabel;
        public static TextBox argumentsTextbox;       
        public static Label optionsLabel;
        public static TextBox optionsTextbox;
        public static Button turnOnOffButton;
        public static Button updateButton;
        public static Label statusLabel;
        public static Label latencyLabel;

        /// <summary>
        /// Build main interface of ARKSO (when setup is over)
        /// </summary>
        public static void Build(Grid AppGrid)
        {
            // Version control
            versionLabel = new Label
            {
                Content = MainWindow.currentVersion,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 2, 0),
                Padding = new Thickness(-10, 0, 0, 0),
                FontSize = 10
            };

            // Name controls
            nameLabel = new Label
            {
                Content = "Server Name",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 45, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            nameTextbox = new TextBox
            {
                Name = "name",
                Text = Json.GetProperty(Json.serverJson, "name"),
                Width = 350,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 65, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            // Map controls
            mapLabel = new Label
            {
                Content = "Map",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 95, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            mapCbb = new ComboBox
            {
                Name = "map",
                Width = 160,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 115, 0, 0),
                ItemsSource = Json.GetKeys(Json.mapsJson),
                SelectedIndex = Json.GetSelectedIndexProperty("map", Json.Read(Json.mapsJson)),
            };

            // Players controls
            playersLabel = new Label
            {
                Content = "Players",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 95, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            playersTextbox = new TextBox
            {
                Name = "players",
                Text = Json.GetProperty(Json.serverJson, "players"),
                Width = 50,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 115, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            // VAC controls
            VACLabel = new Label
            {
                Content = "VAC",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 145, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            VACCbb = new ComboBox
            {
                Name = "vac",
                Width = 75,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 165, 0, 0),
                ItemsSource = Json.GetKeys(Json.VACJson),
                SelectedIndex = Json.GetSelectedIndexProperty("vac", Json.Read(Json.VACJson))
            };

            // VAC controls
            battlEyeLabel = new Label
            {
                Content = "BattlEye",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 145, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            battlEyeCbb = new ComboBox
            {
                Name = "battleye",
                Width = 75,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 165, 0, 0),
                ItemsSource = Json.GetKeys(Json.VACJson),
                SelectedIndex = Json.GetSelectedIndexProperty("battleye", Json.Read(Json.BattlEyeJson))
            };

            // Password controls
            passwordLabel = new Label
            {
                Content = "Password",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 195, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            passwordTextbox = new TextBox
            {
                Name = "password",
                Text = Json.GetProperty(Json.serverJson, "password"),
                Width = 160,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 215, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            // Admin password controls
            adminPasswordLabel = new Label
            {
                Content = "Admin Password",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 195, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            adminPasswordTextbox = new TextBox
            {
                Name = "admin_password",
                Text = Json.GetProperty(Json.serverJson, "admin_password"),
                Width = 160,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 215, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            // Arguments controls
            argumentsLabel = new Label
            {
                Content = "Arguments",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 245, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            argumentsTextbox = new TextBox
            {
                Name = "arguments",
                Text = Json.GetProperty(Json.serverJson, "arguments"),
                Width = 350,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 265, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            // Options controls
            optionsLabel = new Label
            {
                Content = "Options",
                Width = 200,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 295, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0),
            };

            optionsTextbox = new TextBox
            {
                Name = "options",
                Text = Json.GetProperty(Json.serverJson, "options"),
                Width = 350,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 315, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            // Server controls
            turnOnOffButton = new Button
            {
                Content = "Start server",
                Width = 160,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 355, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            updateButton = new Button
            {
                Content = "Update server",
                Width = 160,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(200, 355, 0, 0),
                Padding = new Thickness(10, 10, 10, 10),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            // Server status controls
            statusLabel = new Label
            {
                Content = "Server is off",
                Width = 350,
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.Red),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 410, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0)
            };

            // Server latency controls
            latencyLabel = new Label
            {
                Content = "",
                Width = 350,
                Height = double.NaN,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 425, 0, 0),
                Padding = new Thickness(-10, 0, 0, 0)
            };

            // Add handlers
            nameTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            mapCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateMap));
            playersTextbox.AddHandler(UIElement.PreviewTextInputEvent, new TextCompositionEventHandler(Utils.TextBoxNumberValidation));
            playersTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            VACCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateVAC));
            battlEyeCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateBattlEye));
            passwordTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            adminPasswordTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            argumentsTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            optionsTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            turnOnOffButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.StartNStopServer));
            updateButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MainWindow.UpdateServer));

            // Adjust window size
            Application.Current.MainWindow.Width = 370;
            AppGrid.Width = 371;
            MainWindow.CenterApp();

            // Add controls
            AppGrid.Children.Add(versionLabel);
            AppGrid.Children.Add(nameLabel);
            AppGrid.Children.Add(nameTextbox);
            AppGrid.Children.Add(mapLabel);
            AppGrid.Children.Add(mapCbb);
            AppGrid.Children.Add(playersLabel);
            AppGrid.Children.Add(playersTextbox);
            AppGrid.Children.Add(VACLabel);
            AppGrid.Children.Add(VACCbb);
            AppGrid.Children.Add(battlEyeLabel);
            AppGrid.Children.Add(battlEyeCbb);
            AppGrid.Children.Add(passwordLabel);
            AppGrid.Children.Add(passwordTextbox);
            AppGrid.Children.Add(adminPasswordLabel);
            AppGrid.Children.Add(adminPasswordTextbox);
            AppGrid.Children.Add(argumentsLabel);
            AppGrid.Children.Add(argumentsTextbox);
            AppGrid.Children.Add(optionsLabel);
            AppGrid.Children.Add(optionsTextbox);
            AppGrid.Children.Add(turnOnOffButton);
            AppGrid.Children.Add(updateButton);
            AppGrid.Children.Add(statusLabel);
            AppGrid.Children.Add(latencyLabel);
        }
    }
}
