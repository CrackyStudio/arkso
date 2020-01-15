using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ARKSO.Graphics
{
    class Main
    {
        public static Label donateLabel;
        public static Label versionLabel;

        public static Label serverBox;
        public static Label statusDescLabel;
        public static Label statusLabel;
        public static Label latencyDescLabel;
        public static Label latencyLabel;
        public static Label addressDescLabel;
        public static Label addressLabel;
        public static Button shareAddressButton;

        public static Label settingsBox;
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
        public static Label portLabel;
        public static TextBox portTextbox;
        public static Label queryPortLabel;
        public static TextBox queryPortTextbox;
        public static Label argumentsLabel;
        public static TextBox argumentsTextbox;       
        public static Label optionsLabel;
        public static TextBox optionsTextbox;
        public static Label manualConfigLabel;
        public static Button gameIniButton;
        public static Button gameUserSettingsIniButton;

        public static Label managementBox;
        public static CheckBox hideConsoleCheckbox;

        public static Label actionBox;
        public static Button turnOnOffButton;
        public static Button updateButton;
        public static Button backupButton;

        public static TextBlock credits;

        /// <summary>
        /// Build main interface of ARKSO (when setup is over)
        /// </summary>
        public static void Build(Grid AppGrid)
        {
            // Misc
            donateLabel = new Label
            {
                Content = "$",
                Width = 25,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 25, 0),
                Cursor = Cursors.Hand
            };

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

            // Server
            serverBox = new Label
            {
                Width = 480,
                Height = 40,
                BorderThickness = new Thickness(0.5),
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 35, 10, 0),
            };

            statusDescLabel = new Label
            {
                Content = "Status:",
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20, 42, 20, 0),
            };

            statusLabel = new Label
            {
                Content = "OFFLINE",
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.Red),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(70, 42, 20, 0)
            };

            latencyDescLabel = new Label
            {
                Content = "Latency:",
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(140, 42, 20, 0),
            };

            latencyLabel = new Label
            {
                Content = "-- ms",
                Height = double.NaN,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(200, 42, 20, 0)
            };

            addressDescLabel = new Label
            {
                Content = "Address:",
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(250, 42, 0, 0),
            };

            addressLabel = new Label
            {
                Content = $"{MainWindow.serverIP}:{Json.GetProperty(Json.serverJson, "port")}",
                Height = double.NaN,
                Foreground = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(310, 42, 20, 0),
            };

            shareAddressButton = new Button
            {
                Content = "Copy",
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 42, 25, 0),
                Padding = new Thickness(4, 4, 4, 4),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"],
                Cursor = Cursors.Hand
            };

            // Settings
            settingsBox = new Label
            {
                Width = 480,
                Height = 260,
                BorderThickness = new Thickness(0.5),
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 90, 10, 0),
            };

            nameLabel = new Label
            {
                Content = "Server Name:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 98, 0, 0),
            };

            nameTextbox = new TextBox
            {
                Name = "name",
                Text = Json.GetProperty(Json.serverJson, "name"),
                Width = 362,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 101, 0, 0),
                Padding = new Thickness(5, 1.5, 5, 0)
            };

            mapLabel = new Label
            {
                Content = "Map:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 128, 0, 0),
            };

            mapCbb = new ComboBox
            {
                Name = "map",
                Width = 130,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 130, 0, 0),
                ItemsSource = Json.GetKeys(Json.mapsJson),
                SelectedIndex = Json.GetSelectedIndexProperty("map", Json.Read(Json.mapsJson)),
            };

            playersLabel = new Label
            {
                Content = "Players:",
                Width = 100,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(260, 128, 0, 0),
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
                Margin = new Thickness(365, 130, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            VACLabel = new Label
            {
                Content = "VAC:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 158, 0, 0),
            };

            VACCbb = new ComboBox
            {
                Name = "vac",
                Width = 75,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 160, 0, 0),
                ItemsSource = Json.GetKeys(Json.VACJson),
                SelectedIndex = Json.GetSelectedIndexProperty("vac", Json.Read(Json.VACJson))
            };

            battlEyeLabel = new Label
            {
                Content = "BattlEye:",
                Width = 100,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(260, 158, 0, 0),
            };

            battlEyeCbb = new ComboBox
            {
                Name = "battleye",
                Width = 75,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(365, 160, 0, 0),
                ItemsSource = Json.GetKeys(Json.VACJson),
                SelectedIndex = Json.GetSelectedIndexProperty("battleye", Json.Read(Json.BattlEyeJson))
            };

            passwordLabel = new Label
            {
                Content = "Password:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 188, 0, 0),
            };

            passwordTextbox = new TextBox
            {
                Name = "password",
                Text = Json.GetProperty(Json.serverJson, "password"),
                Width = 110,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 190, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            adminPasswordLabel = new Label
            {
                Content = "Admin Password:",
                Width = 100,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(260, 188, 0, 0),
            };

            adminPasswordTextbox = new TextBox
            {
                Name = "admin_password",
                Text = Json.GetProperty(Json.serverJson, "admin_password"),
                Width = 110,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(365, 190, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            portLabel = new Label
            {
                Content = "Port:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 218, 0, 0),
            };

            portTextbox = new TextBox
            {
                Name = "port",
                Text = Json.GetProperty(Json.serverJson, "port"),
                Width = 80,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 220, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            queryPortLabel = new Label
            {
                Content = "Query Port:",
                Width = 100,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(260, 218, 0, 0),
            };

            queryPortTextbox = new TextBox
            {
                Name = "query_port",
                Text = Json.GetProperty(Json.serverJson, "query_port"),
                Width = 80,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(365, 220, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            argumentsLabel = new Label
            {
                Content = "Arguments:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 248, 0, 0),
            };

            argumentsTextbox = new TextBox
            {
                Name = "arguments",
                Text = Json.GetProperty(Json.serverJson, "arguments"),
                Width = 362,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 250, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            optionsLabel = new Label
            {
                Content = "Options:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 278, 0, 0),
            };

            optionsTextbox = new TextBox
            {
                Name = "options",
                Text = Json.GetProperty(Json.serverJson, "options"),
                Width = 362,
                Height = 22,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 280, 0, 0),
                Padding = new Thickness(5, 1.5, 0, 0)
            };

            manualConfigLabel = new Label
            {
                Content = "Maunal Config:",
                Width = 90,
                Height = Double.NaN,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 310, 0, 0),
            };

            gameIniButton = new Button
            {
                Name = "Game",
                Content = "Edit Game",
                Width = 160,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(115, 310, 0, 0),
                Padding = new Thickness(5, 5, 5, 5),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            gameUserSettingsIniButton = new Button
            {
                Name = "GameUserSettings",
                Content = "Edit GameUserSettings",
                Width = 160,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(316, 310, 0, 0),
                Padding = new Thickness(5, 5, 5, 5),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            // Management
            managementBox = new Label
            {
                Width = 480,
                Height = 35,
                BorderThickness = new Thickness(0.5),
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 365, 10, 0),
            };

            hideConsoleCheckbox = new CheckBox
            {
                Content = "Hide server console",
                IsChecked = bool.Parse(Json.GetProperty(Json.serverJson, "hide_console")),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                Margin = new Thickness(315, 375, 10, 0),
            };

            // Action
            actionBox = new Label
            {
                Width = 480,
                Height = 47,
                BorderThickness = new Thickness(0.5),
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 415, 10, 0),
            };

            turnOnOffButton = new Button
            {
                Content = "Start server",
                Width = 140,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20, 425, 0, 0),
                Padding = new Thickness(5, 5, 5, 5),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            updateButton = new Button
            {
                Content = "Update server",
                Width = 140,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(180, 425, 0, 0),
                Padding = new Thickness(5, 5, 5, 5),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"]
            };

            backupButton = new Button
            {
                Content = "Backup server",
                Width = 140,
                Height = double.NaN,
                Background = new SolidColorBrush(Color.FromRgb(48, 65, 87)),
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(340, 425, 0, 0),
                Padding = new Thickness(5, 5, 5, 5),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                Style = (Style)Application.Current.Resources["onHoverButton"],
                IsEnabled = false
            };

            // Credits
            credits = new TextBlock
            {
                Text = "ARKSO and Cracky are not affiliated with anyone. All trademarks and registered trademarks are the property of their respective owners.",
                Width = 480,
                Height = 47,
                Foreground = new SolidColorBrush(Color.FromRgb(171, 173, 168)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.WrapWithOverflow,
                Margin = new Thickness(12, 470, 20, 0),
                Padding = new Thickness(5, 5, 5, 5)
            };

            // Add handlers
            donateLabel.AddHandler(UIElement.PreviewMouseDownEvent, new RoutedEventHandler(MainWindow.Donate));
            shareAddressButton.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(MainWindow.ShareServer));
            nameTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            mapCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateMap));
            playersTextbox.AddHandler(UIElement.PreviewTextInputEvent, new TextCompositionEventHandler(Utils.TextBoxNumberValidation));
            playersTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            VACCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateVAC));
            battlEyeCbb.AddHandler(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new RoutedEventHandler(Json.UpdateBattlEye));
            passwordTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            adminPasswordTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            portTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            argumentsTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            optionsTextbox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new RoutedEventHandler(Json.Update));
            turnOnOffButton.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(MainWindow.StartNStopServer));
            updateButton.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(MainWindow.UpdateServer));
            gameIniButton.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(Utils.EditFile));
            gameUserSettingsIniButton.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(Utils.EditFile));
            hideConsoleCheckbox.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(Server.HideConsole));

            // Adjust window size
            Application.Current.MainWindow.Width = 500;
            Application.Current.MainWindow.Height = 520;
            AppGrid.Width = 501;
            MainWindow.CenterApp();

            // Add controls
            AppGrid.Children.Add(donateLabel);
            AppGrid.Children.Add(versionLabel);

            AppGrid.Children.Add(serverBox);
            AppGrid.Children.Add(statusDescLabel);
            AppGrid.Children.Add(statusLabel);
            AppGrid.Children.Add(latencyDescLabel);
            AppGrid.Children.Add(latencyLabel);
            AppGrid.Children.Add(addressDescLabel);
            AppGrid.Children.Add(addressLabel);
            AppGrid.Children.Add(shareAddressButton);

            AppGrid.Children.Add(settingsBox);
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
            AppGrid.Children.Add(portLabel);
            AppGrid.Children.Add(portTextbox);
            AppGrid.Children.Add(queryPortLabel);
            AppGrid.Children.Add(queryPortTextbox);
            AppGrid.Children.Add(argumentsLabel);
            AppGrid.Children.Add(argumentsTextbox);
            AppGrid.Children.Add(optionsLabel);
            AppGrid.Children.Add(optionsTextbox);
            AppGrid.Children.Add(manualConfigLabel);
            AppGrid.Children.Add(gameIniButton);
            AppGrid.Children.Add(gameUserSettingsIniButton);

            AppGrid.Children.Add(managementBox);
            AppGrid.Children.Add(hideConsoleCheckbox);

            AppGrid.Children.Add(actionBox);
            AppGrid.Children.Add(turnOnOffButton);
            AppGrid.Children.Add(updateButton);
            AppGrid.Children.Add(backupButton);

            AppGrid.Children.Add(credits);
        }
    }
}