Imports System.Timers
Public Class Form1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ARKSU_Update As System.Diagnostics.Process
        Try
            ARKSU_Update = New System.Diagnostics.Process()
            ARKSU_Update.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamcmd.exe"
            ARKSU_Update.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSU_Update.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
            ARKSU_Update.Start()
            My.Settings.Button3 = "Update " & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
            Button3.Text = "Update " & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
        Catch
            MessageBox.Show("Could not start process " & "SteamCMD", "Error")
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.SteamCMDPath = TextBox1.Text
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        My.Settings.Minimized = False
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.Minimized = True Then
            Dim sgs As Process() = Process.GetProcessesByName("ShooterGame")
            If sgs.Length = 0 Then
                Application.Exit()
                'ca marche pas ShooterGame et ShooteGameServer
            Else
                MessageBox.Show("Server is still running!" & Chr(10) & "Turn it off and retry", "Error")
            End If
        Else
            e.Cancel = True
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
            NotifyIcon1.Visible = True
            My.Settings.Minimized = True
            Me.Visible = False
            NotifyIcon1.ShowBalloonTip(3000, "The app is still active", "Right click and 'exit' to close", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ARKSU_Stop As System.Diagnostics.Process
        Try
            ARKSU_Stop = New System.Diagnostics.Process()
            ARKSU_Stop.StartInfo.FileName = "cmd.exe"
            ARKSU_Stop.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSU_Stop.StartInfo.Arguments = "cmd.exe" & String.Format("/k {0} & {1}", "TASKKILL /IM ShooterGameServer.exe", "exit")
            ARKSU_Stop.Start()
        Catch
            MessageBox.Show("Could not stop process " & "ShooterGame.exe", "Error")
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
        Dim ARKSU_Launch As System.Diagnostics.Process
        Try
            ARKSU_Launch = New System.Diagnostics.Process()
            ARKSU_Launch.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Binaries\Win64\ShooterGameServer.exe"
            If CheckBox2.Checked = True Then
                ARKSU_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                ARKSU_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            End If
            ARKSU_Launch.StartInfo.Arguments = Chr(34) & ComboBox1.Text & "?listen?SessionName=" & TextBox2.Text & "?ServerAdminPassword=" & TextBox4.Text & "?ServerPassword=" & TextBox3.Text & "?Port=" & TextBox5.Text & "?QueryPort=" & TextBox6.Text & "?MaxPlayers=" & NumericUpDown1.Value & Chr(34) & " -" & ComboBox2.Text & " -" & ComboBox3.Text
            ARKSU_Launch.Start()
        Catch
            MessageBox.Show("Could not start process " & "ShooterGameServer.exe", "Error")
        End Try
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
            For Each Process In Diagnostics.Process.GetProcesses()
                If Process.ProcessName = "ShooterGameServer" Then
                    Dim ARKSU_Stop As System.Diagnostics.Process
                    ARKSU_Stop = New System.Diagnostics.Process()
                    ARKSU_Stop.StartInfo.FileName = "cmd.exe"
                    ARKSU_Stop.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    ARKSU_Stop.StartInfo.Arguments = "cmd.exe" & String.Format("/k {0} & {1}", "TASKKILL /IM ShooterGameServer.exe", "exit")
                    ARKSU_Stop.Start()
                End If
            Next
            Dim ARKSU_Update As System.Diagnostics.Process
            ARKSU_Update = New System.Diagnostics.Process()
            ARKSU_Update.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamcmd.exe"
            ARKSU_Update.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ARKSU_Update.StartInfo.Arguments = "+login anonymous +app_update 376030 +quit"
            ARKSU_Update.Start()
            My.Settings.Button3 = "Update" & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
            Button3.Text = "Update " & "(Last: " & DateTime.Now.ToString("yyyy/MM/dd HH:mm") & ")"
            Dim ARKSU_Launch As System.Diagnostics.Process
            ARKSU_Launch = New System.Diagnostics.Process()
            ARKSU_Launch.StartInfo.FileName = My.Settings.SteamCMDPath & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Binaries\Win64\ShooterGameServer.exe"
            If CheckBox2.Checked = True Then
                ARKSU_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                ARKSU_Launch.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            End If
            ARKSU_Launch.StartInfo.Arguments = Chr(34) & ComboBox1.Text & "?listen?SessionName=" & TextBox2.Text & "?ServerAdminPassword=" & TextBox4.Text & "?ServerPassword=" & TextBox3.Text & "?Port=" & TextBox5.Text & "?QueryPort=" & TextBox6.Text & "?MaxPlayers=" & NumericUpDown1.Value & Chr(34) & " -" & ComboBox2.Text & " -" & ComboBox3.Text
            ARKSU_Launch.Start()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim sgs As Process() = Process.GetProcessesByName("ShooterGameServer")
        For Each Process In Diagnostics.Process.GetProcesses()
            If Process.ProcessName = "ShooterGameServer" Then
                Button1.Enabled = True
                Button4.Enabled = False
                Button3.Enabled = False
                PictureBox1.Image = My.Resources._ON
            ElseIf sgs.Length = 0 Then
                Button1.Enabled = False
                Button4.Enabled = True
                Button3.Enabled = True
                PictureBox1.Image = My.Resources.OFF
            End If
        Next
    End Sub
    Private Sub NumericUpDown_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumericUpDown1.TextChanged
        Dim value As Integer = CInt(NumericUpDown1.Text)
        If value < NumericUpDown1.Minimum Then
            NumericUpDown1.Value = NumericUpDown1.Minimum
        ElseIf value > NumericUpDown1.Maximum Then
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
End Class