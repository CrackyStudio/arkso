'_________                       __
'\_   ___ \____________    ____ |  | _____.__.
'/    \  \/\_  __ \__  \ _/ ___\|  |/ <   |  |
'\     \____|  | \// __ \\  \___|    < \___  |
' \______  /|__|  (____  /\___  >__|_ \/ ____|
'        \/            \/     \/     \/\/  
'This freeware was developed by Cracky
'http://steamcommunity.com/id/crackystudio/
'This code is free to use - If you use it, give credits
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Public Class Form1
    Private Property PageIsReady As Boolean = False
    Private Web As New WebBrowser
    Private SteamCMDPath As String
    Private STimer As New Timer
#Region "Controls"
#Region "Common_Controls"
    Private HNavBar As New Label
    Private ExitButton As New Label
    Private CExitButton As New Label
#End Region
#Region "SteamCMD_Install_Controls"
    Private InfoSCMD As New Label
    Private SteamCMDInst As New Label
    Private SteamCMDInstY As New Label
    Private SteamCMDInstN As New Label
#End Region
#Region "CheckForUpdate_Controls"
    Private NewVersionAvailable As New Label
    Private UpdateY As New Label
    Private UpdateN As New Label
#End Region
#Region "ARKSO_Controls"
#Region "MiscControls"
    Private Donate As New PictureBox
    Private Trademarks As New Label
    Private Steam As New Label
    Private ARK As New Label
    Private NI As New NotifyIcon
    Private CM As New ContextMenuStrip
    Private item As New ToolStripMenuItem("Exit")
    Private item2 As New ToolStripMenuItem("Show")
    Private AUBTimer As New Timer
#End Region
#Region "ServerControls"
    Private Server As New GroupBox
    Private SteamCMDexePath As New TextBox
    Private SCMDexePathButton As New PictureBox
    Private SCMDexePath As New Label
    Private Status As New Label
    Private StatusIs As New Label
    Private PING As New Label
    Private PINGIs As New Label
    Private IP As New Label
    Private IPIs As New Label
    Private GenerMess As New Label
    Private IPAdress As String = GetIPAddress()
    Private IPAd As String
#End Region
#Region "SettingsControls"
    Private Settings As New GroupBox
    Private ServerName As New Label
    Private ServerNameIs As New TextBox
    Private Map As New Label
    Private MapIs As New ComboBox
    Private Players As New Label
    Private PlayersIs As New NumericUpDown
    Private VAC As New Label
    Private VACIs As New ComboBox
    Private BattlEye As New Label
    Private BattlEyeIs As New ComboBox
    Private Password As New Label
    Private PasswordIs As New TextBox
    Private AdminPass As New Label
    Private AdminPassIs As New TextBox
    Private Port As New Label
    Private PortIs As New TextBox
    Private QueryPort As New Label
    Private QueryPortIs As New TextBox
    Private Arguments As New Label
    Private ArgumentsIs As New TextBox
    Private Options As New Label
    Private OptionsIs As New TextBox
#End Region
#Region "ManagementControls"
    Private Management As New GroupBox
    Private AutoUpdateNBackup As New CheckBox
    Private HideServerWindow As New CheckBox
    Private DateTimePicker As New DateTimePicker
    Private MEditText As New Label
    Private MEdit As New ComboBox
    Private MEditButton As New PictureBox
#End Region
#Region "ActionControls"
    Private Action As New GroupBox
    Private TurnON As New Label
    Private TurnOFF As New Label
    Private UpdateServer As New Label
    Private BackupServer As New Label
#End Region

#End Region
#End Region
#Region "PowerSaveMode"
    Private Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
    Public Enum EXECUTION_STATE As Integer
        ES_CONTINUOUS = &H80000000
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
    End Enum
    Public Shared Function PowerSaveOff() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS)
    End Function
    Public Shared Function PowerSaveOn() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Function
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForUpdate()
    End Sub
    Sub SteamCMD_Install()
#Region "SetForm"
        Me.Size = New Size(500, 200)
        Me.BackColor = Color.FromArgb(42, 49, 65)
        Me.WindowState = FormWindowState.Normal
        Me.CenterToScreen()
        Me.Show()
#End Region
#Region "SetGraphics"
        With HNavBar
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(475, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = " ARKSO 4.1"
        End With
        With ExitButton
            .Location = New System.Drawing.Point(475, 0)
            .Size = New System.Drawing.Size(25, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "X"
            AddHandler ExitButton.Click, AddressOf Me.OnClick
        End With
        With InfoSCMD
            .Location = New System.Drawing.Point(0, 50)
            .Size = New System.Drawing.Size(500, 50)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Welcome to ARKSO." & vbCrLf & "Working with SteamCMD, it allows you to install and configure quickly and easily a game server."
        End With
        With SteamCMDInst
            .Location = New System.Drawing.Point(0, 100)
            .Size = New System.Drawing.Size(500, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Do you already have SteamCMD?"
        End With
        With SteamCMDInstY
            .Location = New System.Drawing.Point(70, 140)
            .Size = New System.Drawing.Size(130, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Yes, it is already installed"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler SteamCMDInstY.Click, AddressOf Me.OnClick
        End With
        With SteamCMDInstN
            .Location = New System.Drawing.Point(300, 140)
            .Size = New System.Drawing.Size(130, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "No, I want to install it"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler SteamCMDInstN.Click, AddressOf Me.OnClick
        End With
#End Region
#Region "AddControls"
        Me.Controls.Add(HNavBar)
        Me.Controls.Add(ExitButton)
        Me.Controls.Add(InfoSCMD)
        Me.Controls.Add(SteamCMDInst)
        Me.Controls.Add(SteamCMDInstY)
        Me.Controls.Add(SteamCMDInstN)
#End Region
    End Sub
    Sub UpdateAvailable()
#Region "SetForm"
        Me.Size = New Size(500, 140)
        Me.BackColor = Color.FromArgb(42, 49, 65)
        Me.WindowState = FormWindowState.Normal
        Me.CenterToScreen()
        Me.Show()
#End Region
#Region "SetGraphics"
        With HNavBar
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(475, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = " ARKSO - Updater"
        End With
        With ExitButton
            .Location = New System.Drawing.Point(475, 0)
            .Size = New System.Drawing.Size(25, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "X"
            AddHandler ExitButton.Click, AddressOf Me.OnClick
        End With
        With NewVersionAvailable
            .Location = New System.Drawing.Point(0, 50)
            .Size = New System.Drawing.Size(500, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "A new version is available, would you like to update?"
        End With
        With UpdateY
            .Location = New System.Drawing.Point(70, 85)
            .Size = New System.Drawing.Size(130, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Yes"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler UpdateY.Click, AddressOf Me.OnClick
        End With
        With UpdateN
            .Location = New System.Drawing.Point(300, 85)
            .Size = New System.Drawing.Size(130, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "No"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler UpdateN.Click, AddressOf Me.OnClick
        End With
#End Region
#Region "AddControls"
        Me.Controls.Add(HNavBar)
        Me.Controls.Add(ExitButton)
        Me.Controls.Add(NewVersionAvailable)
        Me.Controls.Add(UpdateY)
        Me.Controls.Add(UpdateN)
#End Region
    End Sub
    Sub ARKSO()
#Region "SetForm"
        MyIPIs()
        Me.Size = New Size(500, 540)
        Me.BackColor = Color.FromArgb(42, 49, 65)
        Me.WindowState = FormWindowState.Normal
        Me.CenterToScreen()
        Me.Show()
#End Region
#Region "SetGraphics"
#Region "Common'N'MiscControls"
        With HNavBar
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(450, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = " ARK Server Organiser"
        End With
        With CExitButton
            .Location = New System.Drawing.Point(475, 0)
            .Size = New System.Drawing.Size(25, 25)
            .BackColor = Color.FromArgb(23, 26, 35)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "X"
            AddHandler CExitButton.Click, AddressOf Me.OnClick
        End With
        With Donate
            .Location = New System.Drawing.Point(450, 0)
            .Size = New System.Drawing.Size(25, 25)
            .Image = My.Resources.FeedMe
            .SizeMode = PictureBoxSizeMode.StretchImage
            .BackColor = Color.FromArgb(23, 26, 35)
            AddHandler Donate.Click, AddressOf Me.OnClick
        End With
        With Trademarks
            .Location = New System.Drawing.Point(0, 495)
            .Size = New System.Drawing.Size(500, 40)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(171, 173, 168)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "ARKSO and Cracky are not affiliated with anyone. All trademarks and registered" & vbCrLf & "trademarks are the property of their respective owners."
        End With
        With Steam
            .Location = New System.Drawing.Point(75, 470)
            .Size = New System.Drawing.Size(100, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.Aqua
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Powered by Steam"
            AddHandler Steam.Click, AddressOf Me.OnClick
            AddHandler Steam.MouseEnter, AddressOf Me.OnMouseEnter
            AddHandler Steam.MouseLeave, AddressOf Me.OnMouseLeave
        End With
        With ARK
            .Location = New System.Drawing.Point(345, 470)
            .Size = New System.Drawing.Size(60, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.Aqua
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Play ARK"
            AddHandler ARK.Click, AddressOf Me.OnClick
            AddHandler ARK.MouseEnter, AddressOf Me.OnMouseEnter
            AddHandler ARK.MouseLeave, AddressOf Me.OnMouseLeave
        End With
#End Region
#Region "ServerControls"
        With Server
            .Location = New System.Drawing.Point(5, 30)
            .Size = New System.Drawing.Size(490, 50)
            .Text = "Server"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
        With Status
            .Location = New System.Drawing.Point(5, 15)
            .Size = New System.Drawing.Size(40, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "Status:"
        End With
        With StatusIs
            .Location = New System.Drawing.Point(50, 15)
            .Size = New System.Drawing.Size(65, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.Red
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "OFFLINE"
        End With
        With PING
            .Location = New System.Drawing.Point(125, 15)
            .Size = New System.Drawing.Size(35, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "Ping:"
        End With
        With PINGIs
            .Location = New System.Drawing.Point(160, 15)
            .Size = New System.Drawing.Size(55, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = ""
        End With
        With IP
            .Location = New System.Drawing.Point(235, 15)
            .Size = New System.Drawing.Size(20, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "IP:"
        End With
        With IPIs
            .Location = New System.Drawing.Point(260, 15)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With STimer
            .Enabled = False
            AddHandler STimer.Tick, AddressOf MyTimerTick
        End With
        With AUBTimer
            .Enabled = False
            AddHandler AUBTimer.Tick, AddressOf MyTimerTick2
        End With
        With GenerMess
            .Location = New System.Drawing.Point(385, 15)
            .Size = New System.Drawing.Size(95, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Copy to clipboard"
            .BorderStyle = BorderStyle.FixedSingle
            .Enabled = False
            AddHandler GenerMess.Click, AddressOf Me.OnClick
        End With
#End Region
#Region "SettingsControls"
        With Settings
            .Location = New System.Drawing.Point(5, 90)
            .Size = New System.Drawing.Size(490, 250)
            .Text = "Settings"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
        With SCMDexePath
            .Location = New System.Drawing.Point(5, 15)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "SteamCMD Exec:"
        End With
        With SteamCMDexePath
            .Location = New System.Drawing.Point(100, 18)
            .Size = New System.Drawing.Size(345, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
            .ReadOnly = True
        End With
        With SCMDexePathButton
            .Location = New System.Drawing.Point(455, 18)
            .Size = New System.Drawing.Size(20, 20)
            .Image = My.Resources.folder_icon
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = Color.FromArgb(42, 49, 65)
            AddHandler SCMDexePathButton.Click, AddressOf Me.OnClick
        End With
        With ServerName
            .Location = New System.Drawing.Point(5, 40)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Server Name:"
        End With
        With ServerNameIs
            .Location = New System.Drawing.Point(100, 43)
            .Size = New System.Drawing.Size(375, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With Map
            .Location = New System.Drawing.Point(5, 65)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Map:"
        End With
        With MapIs
            .Location = New System.Drawing.Point(100, 68)
            .Size = New System.Drawing.Size(115, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("TheIsland")
            .Items.Add("TheCenter")
            .Items.Add("ScorchedEarth_P")
            .Items.Add("Ragnarok")
            .Items.Add("Aberration_P")
        End With
        With Players
            .Location = New System.Drawing.Point(255, 65)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Players:"
        End With
        With PlayersIs
            .Location = New System.Drawing.Point(350, 68)
            .Size = New System.Drawing.Size(50, 25)
            .BackColor = SystemColors.ControlLight
            .Maximum = 100
            .Minimum = 1
            .Value = 70
        End With
        With VAC
            .Location = New System.Drawing.Point(5, 90)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "VAC:"
        End With
        With VACIs
            .Location = New System.Drawing.Point(100, 93)
            .Size = New System.Drawing.Size(85, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("secure")
            .Items.Add("insecure")
        End With
        With BattlEye
            .Location = New System.Drawing.Point(255, 90)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "BattlEye:"
        End With
        With BattlEyeIs
            .Location = New System.Drawing.Point(350, 93)
            .Size = New System.Drawing.Size(85, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("UseBattlEye")
            .Items.Add("NoBattlEye")
        End With
        With Password
            .Location = New System.Drawing.Point(5, 115)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Password:"
        End With
        With PasswordIs
            .Location = New System.Drawing.Point(100, 118)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With AdminPass
            .Location = New System.Drawing.Point(255, 115)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Admin Password:"
        End With
        With AdminPassIs
            .Location = New System.Drawing.Point(350, 118)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With Port
            .Location = New System.Drawing.Point(5, 140)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Port:"
        End With
        With PortIs
            .Location = New System.Drawing.Point(100, 143)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With QueryPort
            .Location = New System.Drawing.Point(255, 140)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Query Port:"
        End With
        With QueryPortIs
            .Location = New System.Drawing.Point(350, 143)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With Arguments
            .Location = New System.Drawing.Point(5, 165)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Arguments:"
        End With
        With ArgumentsIs
            .Location = New System.Drawing.Point(100, 168)
            .Size = New System.Drawing.Size(375, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With Options
            .Location = New System.Drawing.Point(5, 190)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Options:"
        End With
        With OptionsIs
            .Location = New System.Drawing.Point(100, 193)
            .Size = New System.Drawing.Size(375, 25)
            .BackColor = SystemColors.ControlLight
            .ForeColor = SystemColors.ControlText
            .BorderStyle = BorderStyle.FixedSingle
        End With
        With MEditText
            .Location = New System.Drawing.Point(5, 215)
            .Size = New System.Drawing.Size(92, 25)
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Manual Config:"
        End With
        With MEdit
            .Location = New System.Drawing.Point(100, 218)
            .Size = New System.Drawing.Size(125, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("Game.ini")
            .Items.Add("GameUserSettings.ini")
        End With
        With MEditButton
            .Location = New System.Drawing.Point(235, 219)
            .Size = New System.Drawing.Size(20, 20)
            .Image = My.Resources.edit
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = Color.FromArgb(42, 49, 65)
            AddHandler MEditButton.Click, AddressOf Me.OnClick
        End With
#End Region
#Region "ManagementControls"
        With Management
            .Location = New System.Drawing.Point(5, 350)
            .Size = New System.Drawing.Size(490, 50)
            .Text = "Management"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
        With AutoUpdateNBackup
            .Location = New System.Drawing.Point(55, 15)
            .Size = New System.Drawing.Size(175, 25)
            .Text = "Automatic Update and Backup"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
            AddHandler AutoUpdateNBackup.CheckedChanged, AddressOf CheckBox_CheckedChanged
        End With
        With HideServerWindow
            .Location = New System.Drawing.Point(315, 15)
            .Size = New System.Drawing.Size(150, 25)
            .Text = "Hide Server Window"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
        With DateTimePicker
            .Location = New System.Drawing.Point(230, 17)
            .Size = New System.Drawing.Size(55, 25)
            .CustomFormat = "HH:mm"
            .Format = DateTimePickerFormat.Custom
            .ShowUpDown = True
            .Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 37, 0)
            .BackColor = SystemColors.ControlLight
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
#End Region
#Region "ActionControls"
        With Action
            .Location = New System.Drawing.Point(5, 410)
            .Size = New System.Drawing.Size(490, 50)
            .Text = "Action"
            .BackColor = Color.FromArgb(42, 49, 65)
            .ForeColor = Color.FromArgb(178, 191, 191)
        End With
        With TurnON
            .Location = New System.Drawing.Point(25, 15)
            .Size = New System.Drawing.Size(95, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Turn ON"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler TurnON.Click, AddressOf Me.OnClick
        End With
        With TurnOFF
            .Location = New System.Drawing.Point(140, 15)
            .Size = New System.Drawing.Size(95, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Turn OFF"
            .BorderStyle = BorderStyle.FixedSingle
            .Enabled = False
            AddHandler TurnOFF.Click, AddressOf Me.OnClick
        End With
        With UpdateServer
            .Location = New System.Drawing.Point(255, 15)
            .Size = New System.Drawing.Size(95, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Update"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler UpdateServer.Click, AddressOf Me.OnClick
        End With
        With BackupServer
            .Location = New System.Drawing.Point(370, 15)
            .Size = New System.Drawing.Size(95, 25)
            .BackColor = Color.FromArgb(48, 65, 87)
            .ForeColor = Color.FromArgb(178, 191, 191)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Backup"
            .BorderStyle = BorderStyle.FixedSingle
            AddHandler BackupServer.Click, AddressOf Me.OnClick
        End With
#End Region
#End Region
#Region "AddControls"
#Region "CommonControls"
        Me.Controls.Add(HNavBar)
        Me.Controls.Add(CExitButton)
        Me.Controls.Add(Donate)
        Me.Controls.Add(Trademarks)
        Me.Controls.Add(Steam)
        Me.Controls.Add(ARK)
#End Region
#Region "ServerControls"
        Me.Controls.Add(Server)
        Me.Server.Controls.Add(Status)
        Me.Server.Controls.Add(StatusIs)
        Me.Server.Controls.Add(PING)
        Me.Server.Controls.Add(PINGIs)
        Me.Server.Controls.Add(IP)
        Me.Server.Controls.Add(IPIs)
        Me.Server.Controls.Add(GenerMess)
#End Region
#Region "SettingsControls"
        Me.Controls.Add(Settings)
        Me.Settings.Controls.Add(SteamCMDexePath)
        Me.Settings.Controls.Add(SCMDexePathButton)
        Me.Settings.Controls.Add(SCMDexePath)
        Me.Settings.Controls.Add(ServerName)
        Me.Settings.Controls.Add(ServerNameIs)
        Me.Settings.Controls.Add(Map)
        Me.Settings.Controls.Add(MapIs)
        Me.Settings.Controls.Add(Players)
        Me.Settings.Controls.Add(PlayersIs)
        Me.Settings.Controls.Add(VAC)
        Me.Settings.Controls.Add(VACIs)
        Me.Settings.Controls.Add(BattlEye)
        Me.Settings.Controls.Add(BattlEyeIs)
        Me.Settings.Controls.Add(Password)
        Me.Settings.Controls.Add(PasswordIs)
        Me.Settings.Controls.Add(AdminPass)
        Me.Settings.Controls.Add(AdminPassIs)
        Me.Settings.Controls.Add(Port)
        Me.Settings.Controls.Add(PortIs)
        Me.Settings.Controls.Add(QueryPort)
        Me.Settings.Controls.Add(QueryPortIs)
        Me.Settings.Controls.Add(Arguments)
        Me.Settings.Controls.Add(ArgumentsIs)
        Me.Settings.Controls.Add(Options)
        Me.Settings.Controls.Add(OptionsIs)
        Me.Settings.Controls.Add(MEditText)
        Me.Settings.Controls.Add(MEdit)
        Me.Settings.Controls.Add(MEditButton)
#End Region
#Region "ManagementControls"
        Me.Controls.Add(Management)
        Me.Management.Controls.Add(AutoUpdateNBackup)
        Me.Management.Controls.Add(HideServerWindow)
        Me.Management.Controls.Add(DateTimePicker)
#End Region
#Region "ActionControls"
        Me.Controls.Add(Action)
        Me.Action.Controls.Add(TurnON)
        Me.Action.Controls.Add(TurnOFF)
        Me.Action.Controls.Add(UpdateServer)
        Me.Action.Controls.Add(BackupServer)
#End Region
        NI.Icon = My.Resources.Icon
        NI.Visible = False
        NI.ContextMenuStrip = CM
        NI.Text = "ARKSO"
        Me.CM.Items.Add(item2)
        Me.CM.Items.Add(item)
        AddHandler item.Click, AddressOf Me.OnClick
        AddHandler item2.Click, AddressOf Me.OnClick
#End Region
        LoadSettings()
    End Sub
    Private Overloads Sub OnClick(sender As Object, e As EventArgs)
        If sender Is ExitButton Then
            Application.Exit()
        ElseIf sender Is CExitButton Then
            Me.Hide()
            NI.Visible = True
        ElseIf sender Is SteamCMDInstY Then
            Controls.Clear()
            ARKSO()
            SteamCMDPathLoc()
        ElseIf sender Is SteamCMDInstN Then
            InstallSteamCMD()
        ElseIf sender Is UpdateY Then
            UpdateARKSO()
        ElseIf sender Is UpdateN Then
            NoUpdateARKSO()
        ElseIf sender Is Donate Then
            Dim webAddress As String = "https://www.paypal.me/officialcracky/5"
            Process.Start(webAddress)
        ElseIf sender Is SCMDexePathButton Then
            SteamCMDPathLoc()
        ElseIf sender Is GenerMess Then
            My.Computer.Clipboard.SetText("Hey! Join me on my server powered by ARKSO at " & IPIs.Text)
        ElseIf sender Is Steam Then
            Dim webAddress As String = "http://store.steampowered.com/"
            Process.Start(webAddress)
        ElseIf sender Is ARK Then
            Dim webAddress As String = "http://www.playark.com/"
            Process.Start(webAddress)
        ElseIf sender Is TurnON Then
            StartMyServer()
        ElseIf sender Is TurnOFF Then
            StopMyServer()
        ElseIf sender Is UpdateServer Then
            UpdateMyServer()
        ElseIf sender Is BackupServer Then
            BackupMyServer()
        ElseIf sender Is item Then
            SaveSettings()
            Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
            If SGS.Length = 0 Then
                Application.Exit()
            End If
        ElseIf sender Is item2 Then
            Me.Show()
            NI.Visible = False
        ElseIf sender Is MEditButton Then
            Dim path As String = My.Settings.SteamCMDPath
            Dim pathis As String = path.Remove(path.Length - 13)
            If MEdit.Text = "Game.ini" Then
                Dim GameINI As String = pathis & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\GameUserSettings.ini"
                If System.IO.File.Exists(GameINI) = True Then
                    Process.Start(GameINI)
                End If
            ElseIf MEdit.Text = "GameUserSettings.ini" Then
                Dim GameUserSettingsINI As String = pathis & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\GameUserSettings.ini"
                If System.IO.File.Exists(GameUserSettingsINI) = True Then
                    Process.Start(GameUserSettingsINI)
                End If
            Else
            End If
        End If
    End Sub
    Private Overloads Sub OnMouseEnter(sender As Object, e As EventArgs)
        If sender Is Steam Then
            Dim newFont1 As New Font(Steam.Font.Name, Steam.Font.Size, FontStyle.Underline)
            sender.Font = newFont1
            Cursor = Cursors.Hand
        ElseIf sender Is ARK Then
            Dim newFont2 As New Font(ARK.Font.Name, ARK.Font.Size, FontStyle.Underline)
            sender.Font = newFont2
            Cursor = Cursors.Hand
        End If
    End Sub
    Private Overloads Sub OnMouseLeave(sender As Object, e As EventArgs)
        If sender Is Steam Then
            Dim newFont3 As New Font(Steam.Font.Name, Steam.Font.Size, FontStyle.Regular)
            sender.Font = newFont3
            Cursor = Cursors.Arrow
        ElseIf sender Is ARK Then
            Dim newFont4 As New Font(ARK.Font.Name, ARK.Font.Size, FontStyle.Regular)
            sender.Font = newFont4
            Cursor = Cursors.Arrow
        End If
    End Sub
    Sub CheckForUpdate()
        Web.Navigate("https://github.com/CrackyStudio/ARKSO/blob/master/CURRENT%20VERSION.txt")
        WaitForPageLoad()
        Dim str As String = "Version 4.1"
        If Web.DocumentText.Contains(str) Then
            If My.Settings.FirstLaunch = True Then
                Controls.Clear()
                SteamCMD_Install()
            Else
                Controls.Clear()
                ARKSO()
            End If
        Else
            Controls.Clear()
            UpdateAvailable()
        End If
    End Sub
    Private Sub WaitForPageLoad()
        AddHandler Web.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not PageIsReady
            Application.DoEvents()
        End While
        PageIsReady = False
    End Sub
    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If Web.ReadyState = WebBrowserReadyState.Complete Then
            PageIsReady = True
            RemoveHandler Web.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub
    Private Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function
    Private Sub CountFiles(InFolder As String, ByRef Result As Integer)
        Result += IO.Directory.GetFiles(InFolder).Count
        For Each f As String In IO.Directory.GetDirectories(InFolder)
            CountFiles(f, Result)
        Next
    End Sub
    Sub UpdateARKSO()
        Dim remoteUri As String = "https://github.com/CrackyStudio/ARKSO/raw/master/ARK%20Server%20Organiser.exe"
        Dim fileName As String = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads\") & "ARK Server Organiser.exe"
        Using client = New WebClient()
            client.DownloadFile(remoteUri, fileName)
        End Using
        Dim ARKSOVer As String = GetFileVersionInfo(fileName).ToString
        Dim finalFile As String = "ARK Server Organiser " & ARKSOVer & ".exe"
        My.Computer.FileSystem.RenameFile(fileName, finalFile)
        Dim LastVARKSO As String = (Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads\") & "ARK Server Organiser " & ARKSOVer & ".exe").ToString
        Process.Start(LastVARKSO)
        Dim DeleteOutdated As New ProcessStartInfo()
        DeleteOutdated.Arguments = "/C ping 1.1.1.1 -n 1 -w 1 > Nul & Del " & ControlChars.Quote & Application.ExecutablePath & ControlChars.Quote
        DeleteOutdated.WindowStyle = ProcessWindowStyle.Hidden
        DeleteOutdated.CreateNoWindow = True
        DeleteOutdated.FileName = "cmd.exe"
        Process.Start(DeleteOutdated)
        Application.ExitThread()
    End Sub
    Sub NoUpdateARKSO()
        If My.Settings.FirstLaunch = True Then
            Controls.Clear()
            SteamCMD_Install()
        Else
            Controls.Clear()
            ARKSO()
        End If
    End Sub
    Sub InstallSteamCMD()
        Dim FolderBrowDiag As New FolderBrowserDialog
        Dim dlgResult As DialogResult
        With FolderBrowDiag
            .ShowNewFolderButton = False
            .Description = "Choose where to install SteamCMD:"
            dlgResult = .ShowDialog()
        End With
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Dim myAppDataFolder = FolderBrowDiag.SelectedPath & "\SteamCMD\"
            If My.Computer.FileSystem.DirectoryExists(myAppDataFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(myAppDataFolder)
            End If
            My.Computer.FileSystem.WriteAllBytes(myAppDataFolder & "steamcmd.exe", My.Resources.steamcmd, False)
            Me.Hide()
            Dim SCMDInstall As System.Diagnostics.Process
            SCMDInstall = New System.Diagnostics.Process()
            SCMDInstall.StartInfo.FileName = myAppDataFolder & "steamcmd.exe"
            SCMDInstall.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            SCMDInstall.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
            SCMDInstall.Start()
            SCMDInstall.WaitForExit()
            SCMDInstall.Close()
            Controls.Clear()
            ARKSO()
            Me.Show()
            Me.BringToFront()
            SteamCMDPath = myAppDataFolder & "steamcmd.exe"
            SteamCMDexePath.Text = SteamCMDPath
        ElseIf dlgResult = Windows.Forms.DialogResult.Cancel Then
            Controls.Clear()
            SteamCMD_Install()
        End If
    End Sub
    Sub SteamCMDPathLoc()
        Dim OpenFileDiag As New OpenFileDialog
        With OpenFileDiag
            .Title = "Select steamcmd.exe location"
            .Filter = "Applications (*.exe)|*.exe"
        End With
        If (OpenFileDiag.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Dim myAppDataFolder = OpenFileDiag.FileName
            SteamCMDexePath.Text = myAppDataFolder
        End If
    End Sub
    Protected Function GetIPAddress() As String
        Dim IP As [String] = ""
        Dim rqst As WebRequest = WebRequest.Create("http://checkip.dyndns.org/")
        Using rep As WebResponse = rqst.GetResponse()
            Using strm As New StreamReader(rep.GetResponseStream())
                IP = strm.ReadToEnd()
            End Using
        End Using
        Return IP
    End Function
    Function Between(Val As String, a As String, b As String) As String
        Dim P1 As Integer = Val.IndexOf(a)
        Dim P2 As Integer = Val.LastIndexOf(b)
        If P1 = -1 Then
            Return ""
        End If
        If P2 = -1 Then
            Return ""
        End If
        Dim AP1 As Integer = P1 + a.Length
        If AP1 >= P2 Then
            Return ""
        End If
        Return Val.Substring(AP1, P2 - AP1)
    End Function
    Sub MyIPIs()
        IPIs.Text = Between(IPAdress, "Address: ", "</body") & ":" & PortIs.Text
        IPAd = Between(IPAdress, "Address: ", "</body")
    End Sub
    Private Sub MyTimerTick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim targetServer As New IPEndPoint(IPAddress.Parse(IPAd), PortIs.Text)
            Using client As New UdpClient
                client.Client.ReceiveTimeout = 100
                Dim request() As Byte = New Byte() {255, 255, 255, 255, CByte(Asc("V")), 255, 255, 255, 255}
                Dim sWatch As Stopwatch = Stopwatch.StartNew
                client.Send(request, request.Length, targetServer)
                Dim response() As Byte = client.Receive(targetServer)
                sWatch.Stop()
                StatusIs.Text = "ONLINE"
                StatusIs.ForeColor = Color.Lime
                PINGIs.Text = sWatch.ElapsedMilliseconds & " ms"
                If sWatch.ElapsedMilliseconds < 60 Then
                    PINGIs.ForeColor = Color.Lime
                ElseIf sWatch.ElapsedMilliseconds > 60 AndAlso sWatch.ElapsedMilliseconds < 80 Then
                    PINGIs.ForeColor = Color.Yellow
                ElseIf sWatch.ElapsedMilliseconds > 80 AndAlso sWatch.ElapsedMilliseconds < 120 Then
                    PINGIs.ForeColor = Color.Orange
                ElseIf sWatch.ElapsedMilliseconds > 120 Then
                    PINGIs.ForeColor = Color.Red
                End If
                STimer.Interval = 1000
                If GenerMess.Enabled = False Then
                    GenerMess.Enabled = True
                End If
            End Using
        Catch ex As Exception
            Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
            If SGS.Length <> 0 Then
                StatusIs.Text = "STARTING"
                StatusIs.ForeColor = Color.Yellow
                PINGIs.Text = ""
                STimer.Interval = 10000
            ElseIf SGS.Length = 0 Then
                Dim socketEx As SocketException = TryCast(ex, SocketException)
                If socketEx IsNot Nothing AndAlso socketEx.SocketErrorCode = SocketError.TimedOut Then
                    StatusIs.Text = "OFFLINE"
                    StatusIs.ForeColor = Color.Red
                    PINGIs.Text = ""
                    GenerMess.Enabled = False
                    STimer.Enabled = False
                End If
            End If
        End Try
    End Sub
    Private Sub MyTimerTick2(ByVal sender As Object, ByVal e As EventArgs)
        If TimeString = DateTimePicker.Text & ":00" Then
            STimer.Enabled = False
            SaveSettings()
            Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
            If SGS.Length <> 0 Then
                StopMyServer()
            End If
            UpdateMyServer()
            AutoBackupMyServer()
        End If
    End Sub
    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If AutoUpdateNBackup.Checked = True Then
            AUBTimer.Enabled = True
        Else
            AUBTimer.Enabled = False
        End If
    End Sub
    Sub LoadSettings()
        SteamCMDexePath.Text = My.Settings.SteamCMDPath
        ServerNameIs.Text = My.Settings.ServerName
        MapIs.Text = My.Settings.Map
        PlayersIs.Value = My.Settings.Players
        VACIs.Text = My.Settings.VAC
        BattlEyeIs.Text = My.Settings.BattlEye
        PasswordIs.Text = My.Settings.Pass
        AdminPassIs.Text = My.Settings.AdminPass
        PortIs.Text = My.Settings.Port
        QueryPortIs.Text = My.Settings.QueryPort
        ArgumentsIs.Text = My.Settings.Arguments
        OptionsIs.Text = My.Settings.Options
        AutoUpdateNBackup.Checked = My.Settings.AutoUpBack
        HideServerWindow.Checked = My.Settings.HideServWin
        DateTimePicker.Text = My.Settings.Time2UpNBack
        MEdit.Text = My.Settings.MEdit
    End Sub
    Sub SaveSettings()
        My.Settings.SteamCMDPath = SteamCMDexePath.Text
        My.Settings.ServerName = ServerNameIs.Text
        My.Settings.Map = MapIs.Text
        My.Settings.Players = PlayersIs.Value
        My.Settings.VAC = VACIs.Text
        My.Settings.BattlEye = BattlEyeIs.Text
        My.Settings.Pass = PasswordIs.Text
        My.Settings.AdminPass = AdminPassIs.Text
        My.Settings.Port = PortIs.Text
        My.Settings.QueryPort = QueryPortIs.Text
        My.Settings.Arguments = ArgumentsIs.Text
        My.Settings.Options = OptionsIs.Text
        My.Settings.AutoUpBack = AutoUpdateNBackup.Checked
        My.Settings.HideServWin = HideServerWindow.Checked
        My.Settings.Time2UpNBack = DateTimePicker.Text
        My.Settings.MEdit = MEdit.Text
        If My.Settings.FirstLaunch = True Then
            My.Settings.FirstLaunch = False
        End If
        My.Settings.Save()
    End Sub
    Sub StartMyServer()
        TurnON.Enabled = False
        TurnOFF.Enabled = True
        BackupServer.Enabled = False
        UpdateServer.Enabled = False
        SteamCMDexePath.Enabled = False
        ServerNameIs.Enabled = False
        MapIs.Enabled = False
        PlayersIs.Enabled = False
        VACIs.Enabled = False
        BattlEyeIs.Enabled = False
        PasswordIs.Enabled = False
        AdminPassIs.Enabled = False
        PortIs.Enabled = False
        QueryPortIs.Enabled = False
        ArgumentsIs.Enabled = False
        OptionsIs.Enabled = False
        AutoUpdateNBackup.Enabled = False
        HideServerWindow.Enabled = False
        DateTimePicker.Enabled = False
        SaveSettings()
        PowerSaveOff()
        MyIPIs()
        STimer.Enabled = True
        Dim ARKSO_Launch As System.Diagnostics.Process
        Dim path As String = My.Settings.SteamCMDPath
        Dim pathis As String = path.Remove(path.Length - 13)
        Try
            ARKSO_Launch = New System.Diagnostics.Process()
            ARKSO_Launch.StartInfo.FileName = pathis & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Binaries\Win64\ShooterGameServer.exe"
            If HideServerWindow.Checked = True Then
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            End If
            ARKSO_Launch.StartInfo.Arguments = Chr(34) & MapIs.Text & "?listen?SessionName=" & ServerNameIs.Text & "?ServerAdminPassword=" & AdminPassIs.Text & "?ServerPassword=" & PasswordIs.Text & "?Port=" & PortIs.Text & "?QueryPort=" & QueryPortIs.Text & "?MaxPlayers=" & PlayersIs.Value & OptionsIs.Text & Chr(34) & " -" & VACIs.Text & " -" & BattlEyeIs.Text & " " & ArgumentsIs.Text
            ARKSO_Launch.Start()
        Catch
        End Try
    End Sub
    Sub StopMyServer()
        TurnON.Enabled = True
        TurnOFF.Enabled = False
        BackupServer.Enabled = True
        UpdateServer.Enabled = True
        SteamCMDexePath.Enabled = True
        ServerNameIs.Enabled = True
        MapIs.Enabled = True
        PlayersIs.Enabled = True
        VACIs.Enabled = True
        BattlEyeIs.Enabled = True
        PasswordIs.Enabled = True
        AdminPassIs.Enabled = True
        PortIs.Enabled = True
        QueryPortIs.Enabled = True
        ArgumentsIs.Enabled = True
        OptionsIs.Enabled = True
        AutoUpdateNBackup.Enabled = True
        HideServerWindow.Enabled = True
        DateTimePicker.Enabled = True
        SaveSettings()
        PowerSaveOn()
        Dim ARKSO_Stop As System.Diagnostics.Process
        Try
            ARKSO_Stop = New System.Diagnostics.Process()
            ARKSO_Stop.StartInfo.FileName = "cmd.exe"
            ARKSO_Stop.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSO_Stop.StartInfo.Arguments = "cmd.exe" & String.Format("/k {0} & {1}", "TASKKILL /IM ShooterGameServer.exe", "exit")
            ARKSO_Stop.Start()
            ARKSO_Stop.WaitForExit()
        Catch
        End Try
    End Sub
    Sub UpdateMyServer()
        TurnON.Enabled = False
        TurnOFF.Enabled = False
        BackupServer.Enabled = False
        UpdateServer.Enabled = False
        SaveSettings()
        StatusIs.Text = "UPDATE"
        StatusIs.ForeColor = Color.RoyalBlue
        StatusIs.Refresh()
        Dim ARKSO_Update As System.Diagnostics.Process
        Try
            ARKSO_Update = New System.Diagnostics.Process()
            ARKSO_Update.StartInfo.FileName = My.Settings.SteamCMDPath
            ARKSO_Update.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSO_Update.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
            ARKSO_Update.Start()
            ARKSO_Update.WaitForExit()
        Catch
        End Try
        TurnON.Enabled = True
        TurnOFF.Enabled = True
        BackupServer.Enabled = True
        UpdateServer.Enabled = True
        If StatusIs.ForeColor = Color.RoyalBlue Then
            StatusIs.Text = "OFFLINE"
            StatusIs.ForeColor = Color.Red
        End If
    End Sub
    Sub BackupMyServer()
        TurnON.Enabled = False
        TurnOFF.Enabled = False
        BackupServer.Enabled = False
        UpdateServer.Enabled = False
        SaveSettings()
        Dim pathwas As String = My.Settings.SteamCMDPath
        Dim pathis As String = pathwas.Remove(pathwas.Length - 13)
        Dim DSavePath As String = pathis & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\"
        Dim CurrDate As String = DateTime.Now.ToString("yyyy.MM.dd - HH.mm")
        Dim newDirectory As String = pathis & "\ARKSO - Server Backup\" & CurrDate & "\"
        If Not (Directory.Exists(newDirectory)) Then
            Directory.CreateDirectory(newDirectory)
        End If
        StatusIs.Text = "BACKUP"
        StatusIs.ForeColor = Color.RoyalBlue
        StatusIs.Refresh()
        If StatusIs.ForeColor = Color.RoyalBlue Then
            Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(DSavePath, newDirectory)
            StatusIs.Text = "OFFLINE"
            StatusIs.ForeColor = Color.Red
            TurnON.Enabled = True
            TurnOFF.Enabled = True
            BackupServer.Enabled = True
            UpdateServer.Enabled = True
        End If
    End Sub
    Sub AutoBackupMyServer()
        BackupMyServer()
        If StatusIs.ForeColor = Color.Red Then
            StartMyServer()
        End If
    End Sub
End Class
'
'___________               .___ _____                ________.______________
'\_   _____/___   ____   __| _//     \   ____       /  _____/|   \_   _____/
' |    __)/ __ \_/ __ \ / __ |/  \ /  \_/ __ \     /   \  ___|   ||    __)  
' |     \\  ___/\  ___// /_/ /    Y    \  ___/     \    \_\  \   ||     \   
' \___  / \___  >\___  >____ \____|__  /\___  >  /\ \______  /___|\___  /   
'     \/      \/     \/     \/       \/     \/   \/        \/         \/  
' Original .GIF Creator is unknow. Thanks to this unknow person!
' Original .GIF Found on Giphy : https://gph.is/VwAqRR
' Translucent BackColor added by Cracky with Ezgif.com : https://ezgif.com/
'  _________ __
' /   _____//  |_  ____ _____    _____  
' \_____  \\   __\/ __ \\__  \  /     \ 
' /        \|  | \  ___/ / __ \|  Y Y  \
'/_______  /|__|  \___  >____  /__|_|  /
'        \/           \/     \/      \/      
'http://store.steampowered.com/
'Powered by Steam
'   _____ __________ ____  __.
'  /  _  \\______   \    |/ _|
' /  /_\  \|       _/      <  
'/    |    \    |   \    |  \ 
'\____|__  /____|_  /____|__ \
'        \/       \/        \/
'http://www.playark.com/
'Used for ARK Survival Evolved
'ARK Server Organiser and Cracky are not affiliated with anyone. All trademarks and registered trademarks are the property of their respective owners. 