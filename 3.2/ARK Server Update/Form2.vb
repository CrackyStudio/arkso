Imports System.IO
Public Class Form2
    Private Sub Form2_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub
    Private Sub CountFiles(InFolder As String, ByRef Result As Integer)
        Result += IO.Directory.GetFiles(InFolder).Count
        For Each f As String In IO.Directory.GetDirectories(InFolder)
            CountFiles(f, Result)
        Next
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        If My.Settings.Eyes = "NIGHT" Then
            Me.BackColor = Color.FromArgb(25, 40, 56)
            Label1.BackColor = Color.FromArgb(25, 40, 56)
            Label1.ForeColor = Color.FromArgb(178, 191, 191)
        ElseIf My.Settings.Eyes = "DAY" Then
            Me.BackColor = SystemColors.Control
            Label1.BackColor = SystemColors.Control
            Label1.ForeColor = SystemColors.ControlText
        End If
        Dim DSavePath As String = Form1.TextBox1.Text & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\"
        Dim CurrDate As String = DateTime.Now.ToString("yyyy.MM.dd - HH.mm")
        Dim newDirectory As String = System.IO.Path.Combine(Form1.TextBox1.Text, "ARKSO - Server Backup\" & CurrDate & "\" & Path.GetFileName(Path.GetDirectoryName(DSavePath)))
        If Not (Directory.Exists(newDirectory)) Then
            Directory.CreateDirectory(newDirectory)
        End If
        Try
            Timer1.Enabled = True
            Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(DSavePath, newDirectory)
        Catch
            Timer1.Enabled = False
            Me.Close()
            Form3.Label3.Text = "ARK Server Organiser - Error 978"
            Form3.Label1.Text = "Oops, something went wrong :("
            Form3.Show()
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim DSavePath As String = Form1.TextBox1.Text & "\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\"
        Dim FileCount As Integer = 0
        CountFiles(DSavePath, FileCount)
        Dim SourceCount = FileCount.ToString
        ProgressBar1.Maximum = SourceCount
        ProgressBar1.Value = ProgressBar1.Value + 1
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            Form1.Show()
            Me.Close()
        End If
    End Sub
End Class