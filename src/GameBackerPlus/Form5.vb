Imports System.IO
Imports System.IO.Compression
Public Class Form5

    'Declare the shell object
    Dim shObj As Object = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"))

    ' Browse output folder
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            TextBox1.Clear()
            TextBox1.ForeColor = Color.Black
            TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8, FontStyle.Regular)

            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ' x close, open form4
    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Form4.Location = New Point(Me.Location.X, Me.Location.Y)

            Form4.Show()
            e.Cancel = False
        End If
    End Sub

    ' Unzip file
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.TextLength = 0 Then
            MessageBox.Show("Select a output!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            'Declare the folder where the items will be extracted.
            Dim output As Object = shObj.NameSpace((TextBox1.Text))

            'Declare the input zip file.
            Dim input As Object = shObj.NameSpace((TextBox2.Text))

            'Extract the items from the zip file.
            output.CopyHere((input.Items), 16)

            Form4.Location = New Point(Me.Location.X, Me.Location.Y)

            Form4.Show()
            Me.Close()
        End If
    End Sub

End Class