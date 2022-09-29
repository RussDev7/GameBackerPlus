Imports System.IO
Imports Microsoft.Win32
Public Class Form4

    'Dims
    'Dim TimerS2 As New Timer

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Display GAME

        Dim directory = Form1.TextBox1.Text
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(directory)

        files = dirinfo.GetFiles("*.zip")

        For Each file In files
            Dim List1 As ListViewItem
            List1 = Me.ListView1.Items.Add(file.Name)

            Dim infoReader As System.IO.FileInfo
            Dim fileLocation As System.IO.FileInfo
            infoReader = file
            fileLocation = file

            List1.SubItems.Add("" & infoReader.LastWriteTime)
            List1.SubItems.Add("" & fileLocation.DirectoryName)
        Next

    End Sub

    ' Close
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Location = New Point(Me.Location.X, Me.Location.Y)

        Form1.Show()
        Me.Close()
    End Sub

    ' Remove item
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ListView1.SelectedItems.Count > 0 Then
            For i As Integer = ListView1.Items.Count - 1 To 0 Step -1
                If ListView1.Items(i).Selected Then

                    Dim FOLDER2 As String
                    FOLDER2 = ListView1.SelectedItems.Item(0).SubItems(2).Text + "\" + ListView1.SelectedItems.Item(0).SubItems(0).Text

                    My.Computer.FileSystem.DeleteFile(FOLDER2)

                    ListView1.Items.RemoveAt(i)
                    ListView1.Refresh()

                End If
            Next
        Else
            MessageBox.Show("First make a selection!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ' x close, open form1
    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Form1.Location = New Point(Me.Location.X, Me.Location.Y)

            Form1.Show()
            e.Cancel = False
        End If
    End Sub

    ' Add Folder Dirr to Form5 Textbox2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim FOLDER As String
            Dim NAME As String
            FOLDER = ListView1.SelectedItems.Item(0).SubItems(2).Text
            NAME = ListView1.SelectedItems.Item(0).SubItems(0).Text

            For i As Integer = ListView1.Items.Count - 1 To 0 Step -1
                If ListView1.Items(i).Selected Then Form5.TextBox2.Text = (FOLDER + "\" + NAME)
            Next

            Form5.Location = New Point(Me.Location.X, Me.Location.Y)
            Form5.Show()
            My.Forms.Form5.Text = "Select a output:"
        Else
            MessageBox.Show("First make a selection!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ' Disable numricupdown when checked NEVER
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            NumericUpDown1.Enabled = False
        Else
            NumericUpDown1.Enabled = True
        End If
    End Sub

    ' Save settings form1 (Clock)
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Run As Integer
        If Run = 0 Then
            AddHandler TimerS2.Tick, AddressOf TimerS2_Tick
            TimerS2.Interval = 1
            TimerS2.Start()

        Else
            RemoveHandler TimerS2.Tick, AddressOf TimerS2_Tick
            TimerS2.Stop()
        End If
    End Sub

    ' Save settings (ALWAYS)
    Private Sub TimerS2_Tick(sender As Object, e As EventArgs)
        My.Settings.Numric1Form4 = NumericUpDown1.Value
        My.Settings.CheckBox1Form4 = CheckBox1.Checked

    End Sub

    ' Load settings
    Private Sub Form36_load(sender As Object, e As EventArgs) Handles MyBase.Load

        NumericUpDown1.Value = My.Settings.Numric1Form4
        CheckBox1.Checked = My.Settings.CheckBox1Form4

    End Sub
End Class