'_________                       __
'\_   ___ \____________    ____ |  | _____.__.
'/    \  \/\_  __ \__  \ _/ ___\|  |/ <   |  |
'\     \____|  | \// __ \\  \___|    < \___  |
' \______  /|__|  (____  /\___  >__|_ \/ ____|
'        \/            \/     \/     \/\/  
'This freeware was developed by Cracky
'http://steamcommunity.com/id/officialcracky/
'This code is free to use - If you use it, give credits
Imports System.Timers
Imports System.IO
Imports System.Net
Public Class Form1
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
#Region "Functions"
    Private Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function
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
#End Region
#Region "Graphics"
    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub
    Private Sub MakeItDay()
        Me.BackColor = SystemColors.Control
        PictureBox3.Image = My.Resources.NIGHT
        PictureBox3.BackColor = Color.LightSkyBlue
        PictureBox4.BackColor = Color.LightSkyBlue
        PictureBox5.BackColor = Color.LightSkyBlue
        PictureBox6.BackColor = Color.LightSkyBlue
        PictureBox2.BackColor = Color.LightSkyBlue
        Label14.BackColor = Color.LightSkyBlue
        Label14.ForeColor = SystemColors.ControlText
        Label15.BackColor = Color.LightSkyBlue
        Label15.ForeColor = SystemColors.ControlText
        GroupBox1.ForeColor = SystemColors.Control
        GroupBox2.ForeColor = SystemColors.Control
        GroupBox3.ForeColor = SystemColors.Control
        Label11.ForeColor = SystemColors.ControlText
        Label10.ForeColor = SystemColors.HotTrack
        Label12.ForeColor = SystemColors.HotTrack
        TextBox1.BackColor = SystemColors.Window
        TextBox1.ForeColor = SystemColors.WindowText
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        ComboBox4.BackColor = SystemColors.Window
        ComboBox4.ForeColor = SystemColors.WindowText
        TextBox2.BackColor = SystemColors.Window
        TextBox2.ForeColor = SystemColors.WindowText
        ComboBox1.BackColor = SystemColors.Window
        ComboBox1.ForeColor = SystemColors.WindowText
        ComboBox2.BackColor = SystemColors.Window
        ComboBox2.ForeColor = SystemColors.WindowText
        ComboBox3.BackColor = SystemColors.Window
        ComboBox3.ForeColor = SystemColors.WindowText
        TextBox3.BackColor = SystemColors.Window
        TextBox3.ForeColor = SystemColors.WindowText
        TextBox4.BackColor = SystemColors.Window
        TextBox4.ForeColor = SystemColors.WindowText
        TextBox5.BackColor = SystemColors.Window
        TextBox5.ForeColor = SystemColors.WindowText
        TextBox6.BackColor = SystemColors.Window
        TextBox6.ForeColor = SystemColors.WindowText
        GroupBox1.ForeColor = SystemColors.WindowText
        GroupBox2.ForeColor = SystemColors.WindowText
        GroupBox3.ForeColor = SystemColors.WindowText
        Button1.ForeColor = SystemColors.WindowText
        Button2.ForeColor = SystemColors.WindowText
        Button3.ForeColor = SystemColors.WindowText
        Button4.ForeColor = SystemColors.WindowText
        Button5.ForeColor = SystemColors.WindowText
        ContextMenuStrip1.BackColor = SystemColors.Control
        ContextMenuStrip1.ForeColor = SystemColors.ControlText
        ContextMenuStrip2.BackColor = SystemColors.Control
        ContextMenuStrip2.ForeColor = SystemColors.ControlText
        TextBox7.BackColor = SystemColors.Window
        TextBox7.ForeColor = SystemColors.WindowText
        TextBox8.BackColor = SystemColors.Window
        TextBox8.ForeColor = SystemColors.WindowText
        Label16.ForeColor = SystemColors.ControlText
        Label17.ForeColor = SystemColors.ControlText
        Label18.ForeColor = Color.Red
        PictureBox7.BackColor = SystemColors.Control
        PictureBox8.BackColor = SystemColors.Control
        My.Settings.Eyes = "DAY"
    End Sub
    Private Sub MakeItNight()
        Me.BackColor = Color.FromArgb(25, 40, 56)
        PictureBox3.Image = My.Resources.DAY
        PictureBox3.BackColor = Color.FromArgb(15, 21, 30)
        PictureBox4.BackColor = Color.FromArgb(15, 21, 30)
        PictureBox5.BackColor = Color.FromArgb(15, 21, 30)
        PictureBox6.BackColor = Color.FromArgb(15, 21, 30)
        PictureBox2.BackColor = Color.FromArgb(15, 21, 30)
        Label14.BackColor = Color.FromArgb(15, 21, 30)
        Label14.ForeColor = Color.FromArgb(178, 191, 191)
        Label15.BackColor = Color.FromArgb(15, 21, 30)
        Label15.ForeColor = Color.FromArgb(178, 191, 191)
        GroupBox1.ForeColor = Color.FromArgb(178, 191, 191)
        GroupBox2.ForeColor = Color.FromArgb(178, 191, 191)
        GroupBox3.ForeColor = Color.FromArgb(178, 191, 191)
        Label11.ForeColor = Color.FromArgb(178, 191, 191)
        Label10.ForeColor = SystemColors.MenuHighlight
        Label12.ForeColor = SystemColors.MenuHighlight
        TextBox1.BackColor = Color.FromArgb(15, 21, 30)
        TextBox1.ForeColor = Color.FromArgb(178, 191, 191)
        Button1.BackColor = Color.FromArgb(15, 21, 30)
        Button2.BackColor = Color.FromArgb(15, 21, 30)
        Button3.BackColor = Color.FromArgb(15, 21, 30)
        Button4.BackColor = Color.FromArgb(15, 21, 30)
        Button5.BackColor = Color.FromArgb(15, 21, 30)
        ComboBox4.BackColor = Color.FromArgb(15, 21, 30)
        ComboBox4.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox2.BackColor = Color.FromArgb(15, 21, 30)
        TextBox2.ForeColor = Color.FromArgb(178, 191, 191)
        ComboBox1.BackColor = Color.FromArgb(15, 21, 30)
        ComboBox1.ForeColor = Color.FromArgb(178, 191, 191)
        ComboBox2.BackColor = Color.FromArgb(15, 21, 30)
        ComboBox2.ForeColor = Color.FromArgb(178, 191, 191)
        ComboBox3.BackColor = Color.FromArgb(15, 21, 30)
        ComboBox3.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox3.BackColor = Color.FromArgb(15, 21, 30)
        TextBox3.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox4.BackColor = Color.FromArgb(15, 21, 30)
        TextBox4.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox5.BackColor = Color.FromArgb(15, 21, 30)
        TextBox5.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox6.BackColor = Color.FromArgb(15, 21, 30)
        TextBox6.ForeColor = Color.FromArgb(178, 191, 191)
        Button1.ForeColor = Color.FromArgb(178, 191, 191)
        Button2.ForeColor = Color.FromArgb(178, 191, 191)
        Button3.ForeColor = Color.FromArgb(178, 191, 191)
        Button4.ForeColor = Color.FromArgb(178, 191, 191)
        Button5.ForeColor = Color.FromArgb(178, 191, 191)
        ContextMenuStrip1.BackColor = Color.FromArgb(15, 21, 30)
        ContextMenuStrip1.ForeColor = Color.FromArgb(178, 191, 191)
        ContextMenuStrip2.BackColor = Color.FromArgb(15, 21, 30)
        ContextMenuStrip2.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox7.BackColor = Color.FromArgb(15, 21, 30)
        TextBox7.ForeColor = Color.FromArgb(178, 191, 191)
        TextBox8.BackColor = Color.FromArgb(15, 21, 30)
        TextBox8.ForeColor = Color.FromArgb(178, 191, 191)
        Label16.ForeColor = Color.FromArgb(178, 191, 191)
        Label17.ForeColor = Color.FromArgb(178, 191, 191)
        Label18.ForeColor = Color.Red
        PictureBox7.BackColor = Color.FromArgb(25, 40, 56)
        PictureBox8.BackColor = Color.FromArgb(25, 40, 56)
        My.Settings.Eyes = "NIGHT"
    End Sub
#End Region
#Region "Settings"
    Sub LoadSettings()
        Me.TextBox1.Text = My.Settings.SteamCMDPath
        Me.Button3.Text = My.Settings.Button3
        Me.TextBox2.Text = My.Settings.Textbox2
        Me.TextBox3.Text = My.Settings.Textbox3
        Me.TextBox4.Text = My.Settings.Textbox4
        Me.TextBox5.Text = My.Settings.Textbox5
        Me.TextBox6.Text = My.Settings.Textbox6
        Me.TextBox7.Text = My.Settings.Textbox7
        Me.TextBox8.Text = My.Settings.Textbox8
        Me.ComboBox1.Text = My.Settings.Combobox1
        Me.ComboBox2.Text = My.Settings.Combobox2
        Me.ComboBox3.Text = My.Settings.Combobox3
        Me.NumericUpDown1.Value = My.Settings.NumericUpAndDown1
        CheckBox1.Checked = My.Settings.Checkbox1
        CheckBox2.Checked = My.Settings.Checkbox2
        DateTimePicker1.Text = My.Settings.DateTimePicker1
    End Sub
    Sub SaveSettings()
        My.Settings.SteamCMDPath = TextBox1.Text
        My.Settings.Button3 = Button3.Text
        My.Settings.Textbox2 = TextBox2.Text
        My.Settings.Textbox3 = TextBox3.Text
        My.Settings.Textbox4 = TextBox4.Text
        My.Settings.Textbox5 = TextBox5.Text
        My.Settings.Textbox6 = TextBox6.Text
        My.Settings.Textbox7 = TextBox7.Text
        My.Settings.Textbox8 = TextBox8.Text
        My.Settings.Combobox1 = ComboBox1.Text
        My.Settings.Combobox2 = ComboBox2.Text
        My.Settings.Combobox3 = ComboBox3.Text
        My.Settings.NumericUpAndDown1 = NumericUpDown1.Value
        My.Settings.Checkbox1 = CheckBox1.Checked
        My.Settings.Checkbox2 = CheckBox2.Checked
        My.Settings.DateTimePicker1 = DateTimePicker1.Text
    End Sub
#End Region
#Region "Process"
    Sub StartServer()
        SaveSettings()
        PowerSaveOff()
        Dim ARKSO_Launch As System.Diagnostics.Process
        Try
            ARKSO_Launch = New System.Diagnostics.Process()
            ARKSO_Launch.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Binaries\Win64\ShooterGameServer.exe"
            If CheckBox2.Checked = True Then
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            End If
            ARKSO_Launch.StartInfo.Arguments = Chr(34) & ComboBox1.Text & "?listen?SessionName=" & TextBox2.Text & "?ServerAdminPassword=" & TextBox4.Text & "?ServerPassword=" & TextBox3.Text & "?Port=" & TextBox5.Text & "?QueryPort=" & TextBox6.Text & "?MaxPlayers=" & NumericUpDown1.Value & TextBox8.Text & Chr(34) & " -" & ComboBox2.Text & " -" & ComboBox3.Text & " " & TextBox7.Text
            ARKSO_Launch.Start()
        Catch
            Form3.Label3.Text = "ARK Server Organiser - Error 438"
            Form3.Label1.Text = "Could not start process ShooterGameServer.exe"
            Form3.Show()
        End Try
    End Sub
    Sub StopServer()
        PowerSaveOn()
        Dim ARKSO_Stop As System.Diagnostics.Process
        Try
            ARKSO_Stop = New System.Diagnostics.Process()
            ARKSO_Stop.StartInfo.FileName = "cmd.exe"
            ARKSO_Stop.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSO_Stop.StartInfo.Arguments = "cmd.exe" & String.Format("/k {0} & {1}", "TASKKILL /IM ShooterGameServer.exe", "exit")
            ARKSO_Stop.Start()
        Catch
            Form3.Label3.Text = "ARK Server Organiser - Error 540"
            Form3.Label1.Text = "Could not stop process ShooterGameServer.exe"
            Form3.Show()
        End Try
    End Sub
    Sub UpdateServer()
        Dim ARKSO_Update As System.Diagnostics.Process
        Try
            ARKSO_Update = New System.Diagnostics.Process()
            ARKSO_Update.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamcmd.exe"
            ARKSO_Update.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSO_Update.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
            ARKSO_Update.Start()
            My.Settings.Button3 = "Update " & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
            Button3.Text = "Update " & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
        Catch
            Form3.Label3.Text = "ARK Server Organiser - Error 652"
            Form3.Label1.Text = "Could not start process SteamCMD.exe"
            Form3.Show()
        End Try
    End Sub
#End Region
#Region "Buttons"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StopServer()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.SteamCMDPath = TextBox1.Text
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UpdateServer()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        StartServer()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text <> "" Then
            If ComboBox4.Text = "GameUserSettings.ini" Then
                Dim GameUserSettings As String = TextBox1.Text & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\GameUserSettings.ini"
                If System.IO.File.Exists(GameUserSettings) = True Then
                    Process.Start(GameUserSettings)
                Else
                    Form3.Label3.Text = "ARK Server Organiser - Error 214"
                    Form3.Label1.Text = "File is not found. SteamCMD Path is probably badly filled"
                    Form3.Show()
                End If
            ElseIf ComboBox4.Text = "Game.ini" Then
                Dim Game As String = TextBox1.Text & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\Game.ini"
                If System.IO.File.Exists(Game) = True Then
                    Process.Start(Game)
                Else
                    Form3.Label3.Text = "ARK Server Organiser - Error 326"
                    Form3.Label1.Text = "File is not found. SteamCMD Path is probably badly filled"
                    Form3.Show()
                End If
            End If
        Else
            Form3.Label3.Text = "ARK Server Organiser - Error 102"
            Form3.Label1.Text = "You must set the SteamCMD Path before"
            Form3.Show()
        End If
    End Sub
#End Region
#Region "Timers"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TimeString = DateTimePicker1.Text & ":00" Then
            SaveSettings()
            For Each Process In Diagnostics.Process.GetProcesses()
                If Process.ProcessName = "ShooterGameServer" Then
                    StopServer()
                End If
            Next
            Form2.ShowDialog()
            UpdateServer()
            StartServer()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
        For Each Process In Diagnostics.Process.GetProcesses()
            If Process.ProcessName = "ShooterGameServer" Then
                Button1.Enabled = True
                ToolStripMenuItem6.Enabled = True
                Button4.Enabled = False
                Button3.Enabled = False
                ToolStripMenuItem5.Enabled = False
                PictureBox1.Image = My.Resources._ON
            ElseIf SGS.Length = 0 Then
                Button1.Enabled = False
                ToolStripMenuItem6.Enabled = False
                Button4.Enabled = True
                Button3.Enabled = True
                ToolStripMenuItem5.Enabled = True
                PictureBox1.Image = My.Resources.OFF
            End If
        Next
    End Sub
#End Region
#Region "UpdateApp & LoadSettings"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Minimized = False
        Dim SVS As String = New System.Net.WebClient().DownloadString("https://docs.google.com/document/d/1znylRqw4jDDR-X8QLLxItMGh6MhN5eCRkAHzOt2EL98")
        Dim Loc As String
        Loc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        My.Computer.FileSystem.WriteAllText(Loc & "\ARKSO_SVS.txt", SVS, False)
        For Each VV As String In IO.File.ReadLines(Loc & "\ARKSO_SVS.txt")
            If VV.Contains("Version 3.2") Then
                If My.Settings.FirstLaunch = True Then
                    Form4.Show()
                    Form4.TopMost = True
                    My.Settings.FirstLaunch = False
                    My.Settings.Save()
                    Exit Sub
                End If
                LoadSettings()
                If My.Settings.CustomCom = True Then
                    TextBox7.Enabled = True
                    TextBox8.Enabled = True
                End If
                Exit Sub
            Else
                Dim NV1 As String = VV
                Dim NV2 As String = Between(NV1, "property=""og:description"" content=", "><meta name=""google""").Replace(Chr(34), "")
                Dim AV As String = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
                Dim NVMBR As Integer = MessageBox.Show(Me, "A new version is available, would you like to update?" & Chr(10) & Chr(10) & "Actual: Version " & AV & Chr(10) & "New: " & NV2, "ARK Server Organiser: Outdated", MessageBoxButtons.YesNo)
                If NVMBR = DialogResult.No Then
                    LoadSettings()
                    If My.Settings.CustomCom = True Then
                        TextBox7.Enabled = True
                        TextBox8.Enabled = True
                    End If
                    Exit Sub
                ElseIf NVMBR = DialogResult.Yes Then
                    If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser")) Then
                        System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser")
                    End If
                    Dim SDLLS As String = New System.Net.WebClient().DownloadString("https://drive.google.com/open?id=11aj3P3dN0DNihL6N3b_31D8ZPnI4SKjG9Y2EeUfkx5A")
                    Dim SDLLFP As String
                    SDLLFP = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser"
                    My.Computer.FileSystem.WriteAllText(SDLLFP & "\SDLLS.txt", SDLLS, False)
                    For Each V As String In IO.File.ReadLines(SDLLFP & "\SDLLS.txt")
                        If V.Contains("property=""og:description"" content=") Then
                            Dim V1 As String = V
                            Dim V2 As String = Between(V1, "property=""og:description"" content=", "><meta name=""google""").Replace(Chr(34), "")
                            Dim DLL As String = V2.Replace("&amp;", "&")
                            Dim DLLFL As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser" & "\" & "ARKSO.exe"
                            Dim DLLWC As New System.Net.WebClient()
                            System.IO.File.WriteAllBytes(DLLFL, DLLWC.DownloadData(DLL))
                            Dim ARKSOVer As String = GetFileVersionInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser" & "\" & "ARKSO.exe").ToString
                            My.Computer.FileSystem.RenameFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser" & "\" & "ARKSO.exe", "ARKSO" & " " & ARKSOVer & ".exe")
                            Dim FLN As String = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ARK Server Organiser" & "\" & "ARKSO" & " " & ARKSOVer & ".exe").ToString
                            Process.Start(FLN)
                        End If
                    Next
                    My.Computer.FileSystem.DeleteFile(SDLLFP & "\SDLLS.txt")
                    Application.Exit()
                    Me.Close()
                End If
                Exit Sub
            End If
        Next
    End Sub
#End Region
#Region "Close"
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.Minimized = True Then
            Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
            If SGS.Length = 1 Then
                Form3.Label3.Text = "ARK Server Organiser - Error 876"
                Form3.Label1.Text = "Server is still running! Turn it off and retry"
                Form3.Show()
                e.Cancel = True
                Exit Sub
            Else
                Application.Exit()
            End If
        Else
            e.Cancel = True
            SaveSettings()
            NotifyIcon1.Visible = True
            My.Settings.Minimized = True
            Me.Visible = False
            NotifyIcon1.ShowBalloonTip(3000, "The app is still active", "Right click and 'exit' to close", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Me.Close()
    End Sub
#End Region
#Region "AutoUpdate"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub NumericUpDown_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumericUpDown1.TextChanged
        If NumericUpDown1.Value < NumericUpDown1.Minimum Then
            NumericUpDown1.Value = NumericUpDown1.Minimum
        ElseIf NumericUpDown1.Value > NumericUpDown1.Maximum Then
            NumericUpDown1.Value = NumericUpDown1.Maximum
        End If
    End Sub
#End Region
#Region "NotifyIcon Area"
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        My.Settings.Minimized = False
        NotifyIcon1.Visible = False
        Me.Visible = True
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        My.Settings.SteamCMDPath = TextBox1.Text
        My.Settings.Button3 = Button3.Text
        My.Settings.Textbox2 = TextBox2.Text
        My.Settings.Textbox3 = TextBox3.Text
        My.Settings.Textbox4 = TextBox4.Text
        My.Settings.Textbox5 = TextBox5.Text
        My.Settings.Textbox6 = TextBox6.Text
        My.Settings.Textbox7 = TextBox7.Text
        My.Settings.Textbox8 = TextBox8.Text
        My.Settings.Combobox1 = ComboBox1.Text
        My.Settings.Combobox2 = ComboBox2.Text
        My.Settings.Combobox3 = ComboBox3.Text
        My.Settings.NumericUpAndDown1 = NumericUpDown1.Value
        My.Settings.Checkbox1 = CheckBox1.Checked
        My.Settings.Checkbox2 = CheckBox2.Checked
        My.Settings.DateTimePicker1 = DateTimePicker1.Text
        Me.Close()
    End Sub
    Private Sub NotifyIcon1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDown
        If e.Button = MouseButtons.Left Then
            My.Settings.Minimized = False
            NotifyIcon1.Visible = False
            Me.Visible = True
        End If
    End Sub
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim ipAddress As String = GetIPAddress()
        My.Computer.Clipboard.SetText(Between(ipAddress, "Address: ", "</body") & ":" & TextBox5.Text)
        Form3.Label3.Text = "ARK Server Organiser - Server IP Address: " & Between(ipAddress, "Address: ", "</body") & ":" & TextBox5.Text
        Form3.Label1.Text = "Server IP Address had been copied to clipboard"
        Form3.Show()
        My.Computer.Clipboard.SetText(Between(ipAddress, "Address: ", "</body") & ":" & TextBox5.Text)
    End Sub
    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        StartServer()
    End Sub
    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        StopServer()
    End Sub
#End Region
#Region "PictureBox Functions"
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If My.Settings.Eyes = "DAY" Then
            MakeItNight()
            Exit Sub
        ElseIf My.Settings.Eyes = "NIGHT" Then
            MakeItDay()
            Exit Sub
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Form2.Show()
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Dim myAppDataFolder = FolderBrowserDialog1.SelectedPath & "\SteamCMD\"
            If My.Computer.FileSystem.DirectoryExists(myAppDataFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(myAppDataFolder)
            End If
            My.Computer.FileSystem.WriteAllBytes(myAppDataFolder & "steamcmd.exe", My.Resources.steamcmd, False)
            Dim SCMDInstall As System.Diagnostics.Process
            Try
                SCMDInstall = New System.Diagnostics.Process()
                SCMDInstall.StartInfo.FileName = myAppDataFolder & "steamcmd.exe"
                SCMDInstall.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                SCMDInstall.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
                SCMDInstall.Start()
            Catch
                Form3.Label3.Text = "ARK Server Organiser - Error 764"
                Form3.Label1.Text = "Could not install SteamCMD"
                Form3.Show()
            End Try
        End If
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Form4.Show()
        Me.Hide()
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If TextBox7.Enabled = True And TextBox8.Enabled = True Then
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            My.Settings.CustomCom = False
        ElseIf TextBox7.Enabled = False And TextBox8.Enabled = False Then
            TextBox7.Enabled = True
            TextBox8.Enabled = True
            My.Settings.CustomCom = True
        End If
    End Sub
#End Region
#Region "External Credits"
    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim webAddress As String = "http://store.steampowered.com/"
        Process.Start(webAddress)
    End Sub
    Private Sub LabelMouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.MouseEnter
        Dim newFont As New Font(Label10.Font.Name, Label10.Font.Size, FontStyle.Underline)
        Label10.Font = newFont
    End Sub
    Private Sub LabelMouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.MouseLeave
        Dim newFont2 As New Font(Label10.Font.Name, Label10.Font.Size, FontStyle.Regular)
        Label10.Font = newFont2
    End Sub
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim webAddress2 As String = "http://www.playark.com/"
        Process.Start(webAddress2)
    End Sub
    Private Sub LabelMouseEnter2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.MouseEnter
        Dim newFont3 As New Font(Label12.Font.Name, Label12.Font.Size, FontStyle.Underline)
        Label12.Font = newFont3
    End Sub
    Private Sub LabelMouseLeave2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.MouseLeave
        Dim newFont4 As New Font(Label12.Font.Name, Label12.Font.Size, FontStyle.Regular)
        Label12.Font = newFont4
    End Sub
#End Region
#Region "Donations"
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label18.Enabled = True
        Timer4.Enabled = True
        Timer3.Enabled = False
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Label18.Enabled = False
        Timer3.Enabled = True
        Timer4.Enabled = False
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = "https://www.paypal.me/officialcracky/5"
        Process.Start(webAddress)
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim webAddress As String = "https://www.paypal.me/officialcracky/5"
        Process.Start(webAddress)
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Dim webAddress As String = "https://www.paypal.me/officialcracky/5"
        Process.Start(webAddress)
    End Sub
#End Region
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