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
    Sub LoadSettings()
        Me.TextBox1.Text = My.Settings.SteamCMDPath
        Me.Button3.Text = My.Settings.Button3
        Me.TextBox2.Text = My.Settings.Textbox2
        Me.TextBox3.Text = My.Settings.Textbox3
        Me.TextBox4.Text = My.Settings.Textbox4
        Me.TextBox5.Text = My.Settings.Textbox5
        Me.TextBox6.Text = My.Settings.Textbox6
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
        My.Settings.Combobox1 = ComboBox1.Text
        My.Settings.Combobox2 = ComboBox2.Text
        My.Settings.Combobox3 = ComboBox3.Text
        My.Settings.NumericUpAndDown1 = NumericUpDown1.Value
        My.Settings.Checkbox1 = CheckBox1.Checked
        My.Settings.Checkbox2 = CheckBox2.Checked
        My.Settings.DateTimePicker1 = DateTimePicker1.Text
    End Sub
    Sub StartServer()
        SaveSettings()
        Dim ARKSO_Launch As System.Diagnostics.Process
        Try
            ARKSO_Launch = New System.Diagnostics.Process()
            ARKSO_Launch.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Binaries\Win64\ShooterGameServer.exe"
            If CheckBox2.Checked = True Then
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                ARKSO_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            End If
            ARKSO_Launch.StartInfo.Arguments = Chr(34) & ComboBox1.Text & "?listen?SessionName=" & TextBox2.Text & "?ServerAdminPassword=" & TextBox4.Text & "?ServerPassword=" & TextBox3.Text & "?Port=" & TextBox5.Text & "?QueryPort=" & TextBox6.Text & "?MaxPlayers=" & NumericUpDown1.Value & Chr(34) & " -" & ComboBox2.Text & " -" & ComboBox3.Text
            ARKSO_Launch.Start()
        Catch
            MessageBox.Show("Could not start process " & "ShooterGameServer.exe", "Error")
        End Try
    End Sub
    Sub StopServer()
        Dim ARKSO_Stop As System.Diagnostics.Process
        Try
            ARKSO_Stop = New System.Diagnostics.Process()
            ARKSO_Stop.StartInfo.FileName = "cmd.exe"
            ARKSO_Stop.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSO_Stop.StartInfo.Arguments = "cmd.exe" & String.Format("/k {0} & {1}", "TASKKILL /IM ShooterGameServer.exe", "exit")
            ARKSO_Stop.Start()
        Catch
            MessageBox.Show("Could not stop process " & "ShooterGame.exe", "Error")
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
            MessageBox.Show("Could not start process " & "SteamCMD", "Error")
        End Try
    End Sub
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
                    MessageBox.Show(Me, "File is not found. SteamCMD Path is probably badly filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf ComboBox4.Text = "Game.ini" Then
                Dim Game As String = TextBox1.Text & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\Game.ini"
                If System.IO.File.Exists(Game) = True Then
                    Process.Start(Game)
                Else
                    MessageBox.Show(Me, "File is not found. SteamCMD Path is probably badly filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show(Me, "You must set the SteamCMD Path before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Minimized = False
        Dim SVS As String = New System.Net.WebClient().DownloadString("https://docs.google.com/document/d/1znylRqw4jDDR-X8QLLxItMGh6MhN5eCRkAHzOt2EL98")
        Dim Loc As String
        Loc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        My.Computer.FileSystem.WriteAllText(Loc & "\ARKSO_SVS.txt", SVS, False)
        For Each VV As String In IO.File.ReadLines(Loc & "\ARKSO_SVS.txt")
            If VV.Contains("Version 2.2") Then
                If My.Settings.Firstlaunch = True Then
                    MessageBox.Show("What's new in Version 2.2?" & Chr(10) & Chr(10) & "Data loading fixed. You have no more longer to fill parameters everytime!" & Chr(10) & Chr(10) & "Thanks to Blazer34.", "Changelog")
                    My.Settings.Firstlaunch = False
                End If
                LoadSettings()
                Exit Sub
            Else
                Dim NV1 As String = VV
                Dim NV2 As String = Between(NV1, "property=""og:description"" content=", "><meta name=""google""").Replace(Chr(34), "")
                Dim AV As String = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
                Dim NVMBR As Integer = MessageBox.Show(Me, "A new version is available, would you like to update?" & Chr(10) & Chr(10) & "Actual: Version " & AV & Chr(10) & "New: " & NV2, "ARK Server Organiser: Outdated", MessageBoxButtons.YesNo)
                If NVMBR = DialogResult.No Then
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
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.Minimized = True Then
            Dim SGS As Process() = Process.GetProcessesByName("ShooterGameServer")
            If SGS.Length = 1 Then
                MessageBox.Show("Server is still running!" & Chr(10) & "Turn it off and retry", "Error")
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
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TimeString = DateTimePicker1.Text & ":00" Then
            SaveSettings()
            For Each Process In Diagnostics.Process.GetProcesses()
                If Process.ProcessName = "ShooterGameServer" Then
                    StopServer()
                End If
            Next
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
    Private Sub NumericUpDown_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumericUpDown1.TextChanged
        If NumericUpDown1.Value < NumericUpDown1.Minimum Then
            NumericUpDown1.Value = NumericUpDown1.Minimum
        ElseIf NumericUpDown1.Value > NumericUpDown1.Maximum Then
            NumericUpDown1.Value = NumericUpDown1.Maximum
        End If
    End Sub
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
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim ipAddress As String = GetIPAddress()
        Dim ipmb As Integer = MessageBox.Show(Me, "IP Address: " & Between(ipAddress, "Address: ", "</body") & ":" & TextBox5.Text & Chr(10) & Chr(10) & "Would you like to copy to Clipboard?", "Server Public IP Address", MessageBoxButtons.YesNo)
        If ipmb = DialogResult.No Then
            Exit Sub
        ElseIf ipmb = DialogResult.Yes Then
            My.Computer.Clipboard.SetText(Between(ipAddress, "Address: ", "</body") & ":" & TextBox5.Text)
        End If
    End Sub
    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        StartServer()
    End Sub
    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        StopServer()
    End Sub
End Class
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