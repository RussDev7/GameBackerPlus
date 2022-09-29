Public Class Form2

    ' Dialog 1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form3.Location = New Point(Me.Location.X, Me.Location.Y)

        My.Forms.Form3.Text = "Running Processes:"
        My.Forms.Form3.Show()
    End Sub
    ' Dialog 2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            TextBox2.Clear()
            TextBox2.ForeColor = Color.Black
            TextBox2.Font = New Font(TextBox2.Font.FontFamily, 8, FontStyle.Regular)

            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ' TextBox 1
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "-" Then
            TextBox1.Clear()
            TextBox1.ForeColor = Color.Black
            TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8)
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "-"
            TextBox1.ForeColor = Color.Gray
            TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8, FontStyle.Italic)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "-"
        TextBox1.ForeColor = Color.Gray
        TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8, FontStyle.Italic)
    End Sub

    ' TextBox 2
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If TextBox2.Text = "-" Then
            TextBox2.Clear()
            TextBox2.ForeColor = Color.Black
            TextBox2.Font = New Font(TextBox2.Font.FontFamily, 8)
        End If
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" Then
            TextBox2.Text = "-"
            TextBox2.ForeColor = Color.Gray
            TextBox2.Font = New Font(TextBox2.Font.FontFamily, 8, FontStyle.Italic)
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = "-"
        TextBox2.ForeColor = Color.Gray
        TextBox2.Font = New Font(TextBox2.Font.FontFamily, 8, FontStyle.Italic)
    End Sub
    ' Exit
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    ' x close, open form1
    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = False
        End If
    End Sub

    ' Ok button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Start needed precess.
        Dim add As New ListViewItem(TextBox1.Text$)

        If TextBox1.Text = "-" Then
            MessageBox.Show("Select a process!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf TextBox2.Text = "-" Then
            MessageBox.Show("Select a folder location!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            add.SubItems.Add(TextBox2.Text$)
            Form1.ListView1.Items.Add(add)
            TextBox1.Clear()
            TextBox2.Clear()

            Me.Close()
        End If

    End Sub
End Class