Public Class Form4
    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Eyes = "NIGHT" Then
            Me.BackColor = Color.FromArgb(25, 40, 56)
            Label14.BackColor = Color.FromArgb(15, 21, 30)
            Label14.ForeColor = Color.FromArgb(178, 191, 191)
            Label15.BackColor = Color.FromArgb(15, 21, 30)
            Label15.ForeColor = Color.FromArgb(178, 191, 191)
            GroupBox1.BackColor = Color.FromArgb(25, 40, 56)
            GroupBox2.BackColor = Color.FromArgb(25, 40, 56)
            GroupBox1.ForeColor = Color.FromArgb(178, 191, 191)
            GroupBox2.ForeColor = Color.FromArgb(178, 191, 191)
            PictureBox1.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox2.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox3.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox4.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox5.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox6.BackColor = Color.FromArgb(25, 40, 56)
            PictureBox7.BackColor = Color.FromArgb(25, 40, 56)
            Label1.BackColor = Color.FromArgb(25, 40, 56)
            Label2.BackColor = Color.FromArgb(25, 40, 56)
            Label3.BackColor = Color.FromArgb(25, 40, 56)
            Label4.BackColor = Color.FromArgb(25, 40, 56)
            Label5.BackColor = Color.FromArgb(25, 40, 56)
            Label6.BackColor = Color.FromArgb(25, 40, 56)
            Label7.BackColor = Color.FromArgb(25, 40, 56)
            Label8.BackColor = Color.FromArgb(25, 40, 56)
            Label1.ForeColor = Color.FromArgb(178, 191, 191)
            Label2.ForeColor = Color.FromArgb(178, 191, 191)
            Label3.ForeColor = Color.FromArgb(178, 191, 191)
            Label4.ForeColor = Color.FromArgb(178, 191, 191)
            Label5.ForeColor = Color.FromArgb(178, 191, 191)
            Label6.ForeColor = Color.FromArgb(178, 191, 191)
            Label7.ForeColor = Color.FromArgb(178, 191, 191)
            Label8.ForeColor = Color.FromArgb(178, 191, 191)
        ElseIf My.Settings.Eyes = "DAY" Then
            Me.BackColor = SystemColors.Control
            Label14.BackColor = Color.LightSkyBlue
            Label14.ForeColor = SystemColors.ControlText
            Label15.BackColor = Color.LightSkyBlue
            Label15.ForeColor = SystemColors.ControlText
            GroupBox1.BackColor = SystemColors.Control
            GroupBox2.BackColor = SystemColors.Control
            GroupBox1.ForeColor = SystemColors.ControlText
            GroupBox2.ForeColor = SystemColors.ControlText
            PictureBox1.BackColor = SystemColors.Control
            PictureBox2.BackColor = SystemColors.Control
            PictureBox3.BackColor = SystemColors.Control
            PictureBox4.BackColor = SystemColors.Control
            PictureBox5.BackColor = SystemColors.Control
            PictureBox6.BackColor = SystemColors.Control
            PictureBox7.BackColor = SystemColors.Control
            Label1.BackColor = SystemColors.Control
            Label2.BackColor = SystemColors.Control
            Label3.BackColor = SystemColors.Control
            Label4.BackColor = SystemColors.Control
            Label5.BackColor = SystemColors.Control
            Label6.BackColor = SystemColors.Control
            Label7.BackColor = SystemColors.Control
            Label8.BackColor = SystemColors.Control
            Label1.ForeColor = SystemColors.ControlText
            Label2.ForeColor = SystemColors.ControlText
            Label3.ForeColor = SystemColors.ControlText
            Label4.ForeColor = SystemColors.ControlText
            Label5.ForeColor = SystemColors.ControlText
            Label6.ForeColor = SystemColors.ControlText
            Label7.ForeColor = SystemColors.ControlText
            Label8.ForeColor = SystemColors.ControlText
        End If
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class