Public Class Form3

    ' Show Processes
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each proc In Process.GetProcesses
            ListBox1.Items.Add(proc.ProcessName)
        Next
    End Sub

    ' Add
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Me.ListBox1.SelectedIndex >= 0 Then
            Form2.Show()

            Form2.TextBox1.Clear()
            Form2.TextBox1.ForeColor = Color.Black
            Form2.TextBox1.Font = New Font(Form2.TextBox1.Font.FontFamily, 8, FontStyle.Regular)

            Dim add As String = ListBox1.Text
            Form2.TextBox1.Text = add

            Form2.Location = New Point(Me.Location.X, Me.Location.Y)
            Me.Close()
        Else
            MessageBox.Show("First make a selection!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ' Cancle
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Location = New Point(Me.Location.X, Me.Location.Y)

        Form2.Show()
        Me.Close()
    End Sub

End Class