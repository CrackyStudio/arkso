Public Class Form3
    Private Sub Form3_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        If My.Settings.Eyes = "NIGHT" Then
            Me.BackColor = Color.FromArgb(25, 40, 56)
            Label1.BackColor = Color.FromArgb(25, 40, 56)
            Label1.ForeColor = Color.FromArgb(178, 191, 191)
            Label3.BackColor = Color.FromArgb(15, 21, 30)
            Label3.ForeColor = Color.FromArgb(178, 191, 191)
            Button1.BackColor = Color.FromArgb(15, 21, 30)
            Button1.ForeColor = Color.FromArgb(178, 191, 191)
        ElseIf My.Settings.Eyes = "DAY" Then
            Me.BackColor = SystemColors.Control
            Label1.BackColor = SystemColors.Control
            Label1.ForeColor = SystemColors.ControlText
            Label3.BackColor = Color.LightSkyBlue
            Label3.ForeColor = SystemColors.ControlText
            Button1.BackColor = SystemColors.Control
            Button1.ForeColor = SystemColors.WindowText
        End If
    End Sub
End Class