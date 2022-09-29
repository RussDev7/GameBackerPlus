Imports System.IO
Imports System.IO.Compression
Imports IWshRuntimeLibrary
Imports System.Security.Principal
Imports Microsoft.Win32

Public Class Form1

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function GetAsyncKeyState(ByVal vkey As System.Windows.Forms.Keys) As Short
    End Function

    'Declare the shell object
    Dim shObj As Object = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"))

    ' Dims
    Dim Press As Integer
    Dim Time As Integer
    Dim hotkey As Boolean

    Dim Timer0 As New Timer
    Dim TimerS As New Timer
    Dim TimerS2 As New Timer

    Dim GO As Integer
    Dim SU As Boolean = True
    Dim RunGO As Boolean = False

    Dim identity = WindowsIdentity.GetCurrent()
    Dim principal = New WindowsPrincipal(identity)
    Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

    ' For the 'looking for game, replay
    Dim Lock As Integer
    Dim Lock2 As Integer
    Dim Lock3 As Integer
    Dim Lock4 As Integer
    Dim Lock5 As Integer
    Dim Lock6 As Integer
    Dim Lock7 As Integer
    Dim Lock8 As Integer
    Dim Lock9 As Integer
    Dim Lock10 As Integer

    Dim Lock11 As Integer
    Dim Lock12 As Integer
    Dim Lock13 As Integer
    Dim Lock14 As Integer
    Dim Lock15 As Integer
    Dim Lock16 As Integer
    Dim Lock17 As Integer
    Dim Lock18 As Integer
    Dim Lock19 As Integer
    Dim Lock20 As Integer

    ' Open Add dialog
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Location = New Point(Me.Location.X, Me.Location.Y)

        My.Forms.Form2.Text = "Add Game:"
        My.Forms.Form2.Show()
    End Sub

    ' Hide the form
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim style = MsgBoxStyle.Information

        MsgBox("Press Windows + F12 To Unhide", style)
        Me.Visible = False
    End Sub

    ' Unhide the form
    Private Sub Timer10_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Press = 0 Then
            hotkey = GetAsyncKeyState(Keys.LWin) And GetAsyncKeyState(Keys.F12)
            If hotkey = True Then
                Me.Visible = True
            Else
            End If
        End If
    End Sub

    ' Confirm upon x close
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim msgboxresponse As MsgBoxResult
        If e.CloseReason = CloseReason.UserClosing Then
            msgboxresponse = MsgBox("Are you sure you want to terminate?",
                            MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text)
            If msgboxresponse <> MsgBoxResult.Yes Then
                e.Cancel = True
                Return
            End If
        End If

    End Sub

    ' Action when minimized
    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then

            Me.Visible = False

        End If
    End Sub

    ' Remove game
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ListView1.SelectedItems.Count > 0 Then
            For i As Integer = ListView1.Items.Count - 1 To 0 Step -1
                If ListView1.Items(i).Selected Then ListView1.Items.RemoveAt(i)
            Next
        Else
            MessageBox.Show("First make a selection!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ' Show the form from taskbar icon
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Me.Visible = True

        Me.WindowState = FormWindowState.Normal
        Me.CenterToScreen()

    End Sub

    ' Contents
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If ListView1.SelectedItems.Count > 0 Then

            Dim FOLDER As String
            Dim EXE As String

            FOLDER = ListView1.SelectedItems.Item(0).SubItems(0).Text
            EXE = ListView1.SelectedItems.Item(0).SubItems(1).Text

            MessageBox.Show("Game: " & FOLDER & vbCrLf & vbCrLf & "location of coverage: " & EXE, "Contents:")
        Else
            MessageBox.Show("First make a selection!", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "C:\GameBackerPlus"
        TextBox1.ForeColor = Color.Gray

        ' Center form to center when loaded
        Me.CenterToScreen()

    End Sub

    ' Timer for radiobuttons
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer0.Tick, AddressOf Timer0_Tick
            Timer0.Interval = 1
            Timer0.Start()

        Else
            RemoveHandler Timer0.Tick, AddressOf Timer0_Tick
            Timer0.Stop()
        End If
    End Sub

    ' Clock function
    Private Sub Timer0_Tick(sender As Object, e As EventArgs)



        ' Reload Feature
        ' If Label6.Text = "-" Then
        ' Label6.Text = "Disabled"
        ' Label6.ForeColor = Color.DarkRed
        ' End If

    End Sub

    ' Set regs
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If Label6.Text = "Enabled" Then
            Label6.Text = "Disabled"
            Label6.ForeColor = Color.DarkRed

            If Label6.Text = "Disabled" Then ' Remove Reg

                Dim regKey As RegistryKey
                regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.DeleteValue(Application.ProductName)
                regKey.Close()
            End If

        ElseIf Label6.Text = "Disabled" Then
            Label6.Text = "Enabled"
            Label6.ForeColor = Color.DarkGreen

            If Label6.Text = "Enabled" Then ' Add Reg

                Dim location As String = System.Environment.GetCommandLineArgs()(0)
                Dim appName As String = System.IO.Path.GetFileName(location)

                Dim regKey As RegistryKey
                regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.SetValue(Application.ProductName, Application.ExecutablePath)
                regKey.Close()
            End If

        End If

    End Sub


    ' Browse save location
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            TextBox1.Clear()
            TextBox1.ForeColor = Color.Black
            TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8, FontStyle.Regular)

            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ' Backups tabs
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Visible = False

        Form4.Location = New Point(Me.Location.X, Me.Location.Y)

        My.Forms.Form4.Text = "Restore:"
        My.Forms.Form4.Show()
    End Sub

    ' Time befor delete backups (Clock)
    Dim Timer02 As New Timer
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer0.Tick, AddressOf Timer02_Tick
            Timer02.Interval = 1
            Timer02.Start()

        Else
            RemoveHandler Timer02.Tick, AddressOf Timer02_Tick
            Timer02.Stop()
        End If
    End Sub

    ' Time before delete backups
    Private Sub Timer02_Tick(sender As Object, e As EventArgs)

        ' 20 Game Limit (Linching of this timer)
        If ListView1.Items.Count > 19 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        ' Add Dirr
        If (Not System.IO.Directory.Exists(TextBox1.Text)) Then
            System.IO.Directory.CreateDirectory(TextBox1.Text)
        End If

        If (Not System.IO.Directory.Exists(TextBox1.Text)) Then
            System.IO.File.Create(TextBox1.Text + "\DO NOT DELETE.txt")
        End If

        ' delete backups
        If Form4.CheckBox1.Checked = False Then
            Dim directory As New IO.DirectoryInfo(TextBox1.Text)

            For Each file As IO.FileInfo In directory.GetFiles
                If file.Extension.Equals(".zip") AndAlso (Now - file.CreationTime).Days > Form4.NumericUpDown1.Text Then
                    file.Delete()
                End If
            Next
        End If
    End Sub

    ' Save settings form1 (Clock)
    Private Sub Form35_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Run As Integer
        If Run = 0 Then
            AddHandler TimerS.Tick, AddressOf TimerS_Tick
            TimerS.Interval = 1
            TimerS.Start()

        Else
            RemoveHandler TimerS.Tick, AddressOf TimerS_Tick
            TimerS.Stop()
        End If
    End Sub

    ' Save settings (ALWAYS)
    Private testfile As String = "\DO NOT DELETE.txt"

    Private Sub TimerS_Tick(sender As Object, e As EventArgs)

        My.Settings.CheckBox1Form1 = Me.CheckBox1.Checked
        My.Settings.Textbox1 = Me.TextBox1.Text

        ' Save listbox
        If (System.IO.Directory.Exists(TextBox1.Text)) Then
            Dim myWriter As New IO.StreamWriter(TextBox1.Text + testfile)
            For Each myItem As ListViewItem In ListView1.Items
                myWriter.WriteLine(myItem.Text & "#" & myItem.SubItems(1).Text)
            Next
            myWriter.Close()
        Else
        End If
    End Sub

    ' Load settings
    Private Sub Form36_load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Visible = False

        Me.CheckBox1.Checked = My.Settings.CheckBox1Form1
        Me.TextBox1.Text = My.Settings.Textbox1

        ' load listbox
        If (System.IO.Directory.Exists(TextBox1.Text)) Then
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(TextBox1.Text + testfile)
            For Each line As String In myCoolFileLines
                Dim lineArray() As String = line.Split("#")
                Dim newItem As New ListViewItem(lineArray(0))
                newItem.SubItems.Add(lineArray(1))
                ListView1.Items.Add(newItem)
            Next
        Else
        End If

        ' Add tooltips
        ToolTip1.SetToolTip(Me.Button1, "Add a new game.")
        ToolTip1.SetToolTip(Me.Button2, "Remove selected game.")
        ToolTip1.SetToolTip(Me.Button3, "Get basic information about selected game.")
        ToolTip1.SetToolTip(Me.Button4, "Hide GameBackerPlus.")
        ToolTip1.SetToolTip(Me.Button5, "Browse for a backup location.")
        ToolTip1.SetToolTip(Me.Button6, "Restore selected game from backup.")
        ToolTip1.SetToolTip(Me.Button7, "Toggle full-time protection. Add/Remove from startup.")
        ToolTip1.SetToolTip(Me.CheckBox1, "Turn On/Off backup notifications.")

        ToolTip1.SetToolTip(Form2.Button1, "Browse for game process.")
        ToolTip1.SetToolTip(Form2.Button2, "Browse for save folder to backup.")
        ToolTip1.SetToolTip(Form2.Button3, "Cancel operation.")
        ToolTip1.SetToolTip(Form2.Button4, "Confirm new profile.")

        ToolTip1.SetToolTip(Form3.Button2, "Cancel operation.")
        ToolTip1.SetToolTip(Form3.Button1, "Confirm new process.")

        ToolTip1.SetToolTip(Form4.Button1, "Recover selected backup from list.")
        ToolTip1.SetToolTip(Form4.Button2, "Delete selected backup from list.")
        ToolTip1.SetToolTip(Form4.Button3, "Go back to menu.")
        ToolTip1.SetToolTip(Form4.CheckBox1, "Never delete backups.")

        ToolTip1.SetToolTip(Form5.Button1, "Browse for restore save location.")
        ToolTip1.SetToolTip(Form5.Button2, "Confirm restore location.")

    End Sub

    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)

        ' Enable/Disable reg lable
        ' Check if it exists
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Nothing) Is Nothing Then

            ' Set labels
            Label6.Text = "Disabled"
            Label6.ForeColor = Color.DarkRed
        Else

            ' Set labels
            Label6.Text = "Enabled"
            Label6.ForeColor = Color.DarkGreen
        End If

        ' Timer for Hide on startup
        If Label6.Text = "Enabled" Then

            If Not Me.IsHandleCreated Then
                Me.CreateHandle()
                value = False
            End If
            MyBase.SetVisibleCore(value)

        ElseIf Label6.Text = "Disabled" Then

            If Not Me.IsHandleCreated Then
                Me.CreateHandle()
                value = True
            End If
            MyBase.SetVisibleCore(value)

        End If

    End Sub

    ' Sub start

    ' Look for game start/exit, Save to dirr (Clock) #1
    Dim Timer03 As New Timer
    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer03.Tick, AddressOf Timer03_Tick
            Timer03.Interval = 1
            Timer03.Start()

        Else
            RemoveHandler Timer03.Tick, AddressOf Timer03_Tick
            Timer03.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #1
    Private Sub Timer03_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p() As Process

        If ListView1.Items.Count > 0 Then

            Dim PRO1 As String ' Name
            PRO1 = ListView1.Items.Item(0).SubItems(0).Text

            Dim LOC1 As String ' Location
            LOC1 = ListView1.Items.Item(0).SubItems(1).Text

            Dim zipPath As String = TextBox1.Text + "\" + PRO1 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p = Process.GetProcessesByName(PRO1)
            If p.Count > 0 Then ' Running

                If Lock = 0 Then

                    Lock = 1

                    ZipFile.CreateFromDirectory(LOC1, zipPath, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO1 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            ElseIf p.Count < 1 Then

                If p.Count > 0 Then

                    If Lock = 1 Then
                        Lock = 0
                    End If

                Else
                    If Lock = 1 Then
                        Lock = 0

                        ZipFile.CreateFromDirectory(LOC1, zipPath, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO1 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else
            End If

        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #2
    Dim Timer04 As New Timer
    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer0.Tick, AddressOf Timer04_Tick
            Timer04.Interval = 1
            Timer04.Start()

        Else
            RemoveHandler Timer03.Tick, AddressOf Timer04_Tick
            Timer04.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #2
    Private Sub Timer04_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p2() As Process

        If ListView1.Items.Count > 1 Then

            Dim PRO2 As String ' Name
            PRO2 = ListView1.Items.Item(1).SubItems(0).Text

            Dim LOC2 As String ' Location
            LOC2 = ListView1.Items.Item(1).SubItems(1).Text

            Dim zipPath2 As String = TextBox1.Text + "\" + PRO2 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p2 = Process.GetProcessesByName(PRO2)
            If p2.Count < 1 Then ' Running

                If p2.Count > 0 Then

                    If Lock2 = 1 Then
                        Lock2 = 0
                    End If

                Else
                    If Lock2 = 1 Then
                        Lock2 = 0

                        ZipFile.CreateFromDirectory(LOC2, zipPath2, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO2 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock2 = 0 Then
                    Lock2 = 1

                    ZipFile.CreateFromDirectory(LOC2, zipPath2, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO2 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #3
    Dim Timer05 As New Timer
    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer05.Tick, AddressOf Timer05_Tick
            Timer05.Interval = 1
            Timer05.Start()

        Else
            RemoveHandler Timer05.Tick, AddressOf Timer05_Tick
            Timer05.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #3
    Private Sub Timer05_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p3() As Process

        If ListView1.Items.Count > 2 Then

            Dim PRO3 As String ' Name
            PRO3 = ListView1.Items.Item(2).SubItems(0).Text

            Dim LOC3 As String ' Location
            LOC3 = ListView1.Items.Item(2).SubItems(1).Text

            Dim zipPath3 As String = TextBox1.Text + "\" + PRO3 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p3 = Process.GetProcessesByName(PRO3)
            If p3.Count < 1 Then ' Running

                If p3.Count > 0 Then

                    If Lock3 = 1 Then
                        Lock3 = 0
                    End If

                Else
                    If Lock3 = 1 Then
                        Lock3 = 0

                        ZipFile.CreateFromDirectory(LOC3, zipPath3, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO3 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock3 = 0 Then
                    Lock3 = 1

                    ZipFile.CreateFromDirectory(LOC3, zipPath3, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO3 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #4
    Dim Timer06 As New Timer
    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer06.Tick, AddressOf Timer06_Tick
            Timer06.Interval = 1
            Timer06.Start()

        Else
            RemoveHandler Timer06.Tick, AddressOf Timer06_Tick
            Timer06.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #4
    Private Sub Timer06_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p4() As Process

        If ListView1.Items.Count > 3 Then

            Dim PRO4 As String ' Name
            PRO4 = ListView1.Items.Item(3).SubItems(0).Text

            Dim LOC4 As String ' Location
            LOC4 = ListView1.Items.Item(3).SubItems(1).Text

            Dim zipPath4 As String = TextBox1.Text + "\" + PRO4 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p4 = Process.GetProcessesByName(PRO4)
            If p4.Count < 1 Then ' Running

                If p4.Count > 0 Then

                    If Lock4 = 1 Then
                        Lock4 = 0
                    End If

                Else
                    If Lock4 = 1 Then
                        Lock4 = 0

                        ZipFile.CreateFromDirectory(LOC4, zipPath4, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO4 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock4 = 0 Then
                    Lock4 = 1

                    ZipFile.CreateFromDirectory(LOC4, zipPath4, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO4 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #5
    Dim Timer07 As New Timer
    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer07.Tick, AddressOf Timer07_Tick
            Timer07.Interval = 1
            Timer07.Start()

        Else
            RemoveHandler Timer07.Tick, AddressOf Timer07_Tick
            Timer07.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #5
    Private Sub Timer07_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p5() As Process

        If ListView1.Items.Count > 4 Then

            Dim PRO5 As String ' Name
            PRO5 = ListView1.Items.Item(4).SubItems(0).Text

            Dim LOC5 As String ' Location
            LOC5 = ListView1.Items.Item(4).SubItems(1).Text

            Dim zipPath5 As String = TextBox1.Text + "\" + PRO5 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p5 = Process.GetProcessesByName(PRO5)
            If p5.Count < 1 Then ' Running

                If p5.Count > 0 Then

                    If Lock5 = 1 Then
                        Lock5 = 0
                    End If

                Else
                    If Lock5 = 1 Then
                        Lock5 = 0

                        ZipFile.CreateFromDirectory(LOC5, zipPath5, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO5 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock5 = 0 Then
                    Lock5 = 1

                    ZipFile.CreateFromDirectory(LOC5, zipPath5, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO5 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #6
    Dim Timer08 As New Timer
    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer08.Tick, AddressOf Timer08_Tick
            Timer08.Interval = 1
            Timer08.Start()

        Else
            RemoveHandler Timer08.Tick, AddressOf Timer08_Tick
            Timer08.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #6
    Private Sub Timer08_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p6() As Process

        If ListView1.Items.Count > 5 Then

            Dim PRO6 As String ' Name
            PRO6 = ListView1.Items.Item(5).SubItems(0).Text

            Dim LOC6 As String ' Location
            LOC6 = ListView1.Items.Item(5).SubItems(1).Text

            Dim zipPath6 As String = TextBox1.Text + "\" + PRO6 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p6 = Process.GetProcessesByName(PRO6)
            If p6.Count < 1 Then ' Running

                If p6.Count > 0 Then

                    If Lock6 = 1 Then
                        Lock6 = 0
                    End If

                Else
                    If Lock6 = 1 Then
                        Lock6 = 0

                        ZipFile.CreateFromDirectory(LOC6, zipPath6, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO6 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock6 = 0 Then
                    Lock6 = 1

                    ZipFile.CreateFromDirectory(LOC6, zipPath6, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO6 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #7
    Dim Timer09 As New Timer
    Private Sub Form21_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer09.Tick, AddressOf Timer09_Tick
            Timer09.Interval = 1
            Timer09.Start()

        Else
            RemoveHandler Timer09.Tick, AddressOf Timer09_Tick
            Timer09.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #7
    Private Sub Timer09_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p7() As Process

        If ListView1.Items.Count > 6 Then

            Dim PRO7 As String ' Name
            PRO7 = ListView1.Items.Item(6).SubItems(0).Text

            Dim LOC7 As String ' Location
            LOC7 = ListView1.Items.Item(6).SubItems(1).Text

            Dim zipPath7 As String = TextBox1.Text + "\" + PRO7 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p7 = Process.GetProcessesByName(PRO7)
            If p7.Count < 1 Then ' Running

                If p7.Count > 0 Then

                    If Lock7 = 1 Then
                        Lock7 = 0
                    End If

                Else
                    If Lock7 = 1 Then
                        Lock7 = 0

                        ZipFile.CreateFromDirectory(LOC7, zipPath7, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO7 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock7 = 0 Then
                    Lock7 = 1

                    ZipFile.CreateFromDirectory(LOC7, zipPath7, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO7 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #8
    Dim Timer010 As New Timer
    Private Sub Form22_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer010.Tick, AddressOf Timer010_Tick
            Timer010.Interval = 1
            Timer010.Start()

        Else
            RemoveHandler Timer010.Tick, AddressOf Timer010_Tick
            Timer010.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #8
    Private Sub Timer010_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p8() As Process

        If ListView1.Items.Count > 7 Then

            Dim PRO8 As String ' Name
            PRO8 = ListView1.Items.Item(7).SubItems(0).Text

            Dim LOC8 As String ' Location
            LOC8 = ListView1.Items.Item(7).SubItems(1).Text

            Dim zipPath8 As String = TextBox1.Text + "\" + PRO8 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p8 = Process.GetProcessesByName(PRO8)
            If p8.Count < 1 Then ' Running

                If p8.Count > 0 Then

                    If Lock8 = 1 Then
                        Lock8 = 0
                    End If

                Else
                    If Lock8 = 1 Then
                        Lock8 = 0

                        ZipFile.CreateFromDirectory(LOC8, zipPath8, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO8 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock8 = 0 Then
                    Lock8 = 1

                    ZipFile.CreateFromDirectory(LOC8, zipPath8, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO8 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #9
    Dim Timer011 As New Timer
    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer011.Tick, AddressOf Timer011_Tick
            Timer011.Interval = 1
            Timer011.Start()

        Else
            RemoveHandler Timer011.Tick, AddressOf Timer011_Tick
            Timer011.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #9
    Private Sub Timer011_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p9() As Process

        If ListView1.Items.Count > 8 Then

            Dim PRO9 As String ' Name
            PRO9 = ListView1.Items.Item(8).SubItems(0).Text

            Dim LOC9 As String ' Location
            LOC9 = ListView1.Items.Item(8).SubItems(1).Text

            Dim zipPath9 As String = TextBox1.Text + "\" + PRO9 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p9 = Process.GetProcessesByName(PRO9)
            If p9.Count < 1 Then ' Running

                If p9.Count > 0 Then

                    If Lock9 = 1 Then
                        Lock9 = 0
                    End If

                Else
                    If Lock9 = 1 Then
                        Lock9 = 0

                        ZipFile.CreateFromDirectory(LOC9, zipPath9, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO9 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock9 = 0 Then
                    Lock9 = 1

                    ZipFile.CreateFromDirectory(LOC9, zipPath9, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO9 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #10
    Dim Timer012 As New Timer
    Private Sub Form24_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer012.Tick, AddressOf Timer012_Tick
            Timer012.Interval = 1
            Timer012.Start()

        Else
            RemoveHandler Timer012.Tick, AddressOf Timer012_Tick
            Timer012.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #10
    Private Sub Timer012_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p10() As Process

        If ListView1.Items.Count > 9 Then

            Dim PRO10 As String ' Name
            PRO10 = ListView1.Items.Item(9).SubItems(0).Text

            Dim LOC10 As String ' Location
            LOC10 = ListView1.Items.Item(9).SubItems(1).Text

            Dim zipPath10 As String = TextBox1.Text + "\" + PRO10 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p10 = Process.GetProcessesByName(PRO10)
            If p10.Count < 1 Then ' Running

                If p10.Count > 0 Then

                    If Lock10 = 1 Then
                        Lock10 = 0
                    End If

                Else
                    If Lock10 = 1 Then
                        Lock10 = 0

                        ZipFile.CreateFromDirectory(LOC10, zipPath10, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO10 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock10 = 0 Then
                    Lock10 = 1

                    ZipFile.CreateFromDirectory(LOC10, zipPath10, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO10 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #11
    Dim Timer013 As New Timer
    Private Sub Form25_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer013.Tick, AddressOf Timer013_Tick
            Timer013.Interval = 1
            Timer013.Start()

        Else
            RemoveHandler Timer013.Tick, AddressOf Timer013_Tick
            Timer013.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #11
    Private Sub Timer013_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p11() As Process

        If ListView1.Items.Count > 10 Then

            Dim PRO11 As String ' Name
            PRO11 = ListView1.Items.Item(10).SubItems(0).Text

            Dim LOC11 As String ' Location
            LOC11 = ListView1.Items.Item(10).SubItems(1).Text

            Dim zipPath11 As String = TextBox1.Text + "\" + PRO11 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p11 = Process.GetProcessesByName(PRO11)
            If p11.Count < 1 Then ' Running

                If p11.Count > 0 Then

                    If Lock11 = 1 Then
                        Lock11 = 0
                    End If

                Else
                    If Lock11 = 1 Then
                        Lock11 = 0

                        ZipFile.CreateFromDirectory(LOC11, zipPath11, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO11 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock11 = 0 Then
                    Lock11 = 1

                    ZipFile.CreateFromDirectory(LOC11, zipPath11, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO11 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #12
    Dim Timer014 As New Timer
    Private Sub Form26_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer014.Tick, AddressOf Timer014_Tick
            Timer014.Interval = 1
            Timer014.Start()

        Else
            RemoveHandler Timer014.Tick, AddressOf Timer014_Tick
            Timer014.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #12
    Private Sub Timer014_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p12() As Process

        If ListView1.Items.Count > 11 Then

            Dim PRO12 As String ' Name
            PRO12 = ListView1.Items.Item(11).SubItems(0).Text

            Dim LOC12 As String ' Location
            LOC12 = ListView1.Items.Item(11).SubItems(1).Text

            Dim zipPath12 As String = TextBox1.Text + "\" + PRO12 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p12 = Process.GetProcessesByName(PRO12)
            If p12.Count < 1 Then ' Running

                If p12.Count > 0 Then

                    If Lock12 = 1 Then
                        Lock12 = 0
                    End If

                Else
                    If Lock12 = 1 Then
                        Lock12 = 0

                        ZipFile.CreateFromDirectory(LOC12, zipPath12, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO12 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock12 = 0 Then
                    Lock12 = 1

                    ZipFile.CreateFromDirectory(LOC12, zipPath12, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO12 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #13
    Dim Timer015 As New Timer
    Private Sub Form27_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer015.Tick, AddressOf Timer015_Tick
            Timer015.Interval = 1
            Timer015.Start()

        Else
            RemoveHandler Timer015.Tick, AddressOf Timer015_Tick
            Timer015.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #13
    Private Sub Timer015_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p13() As Process

        If ListView1.Items.Count > 12 Then

            Dim PRO13 As String ' Name
            PRO13 = ListView1.Items.Item(12).SubItems(0).Text

            Dim LOC13 As String ' Location
            LOC13 = ListView1.Items.Item(12).SubItems(1).Text

            Dim zipPath13 As String = TextBox1.Text + "\" + PRO13 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p13 = Process.GetProcessesByName(PRO13)
            If p13.Count < 1 Then ' Running

                If p13.Count > 0 Then

                    If Lock13 = 1 Then
                        Lock13 = 0
                    End If

                Else
                    If Lock13 = 1 Then
                        Lock13 = 0

                        ZipFile.CreateFromDirectory(LOC13, zipPath13, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO13 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock13 = 0 Then
                    Lock13 = 1

                    ZipFile.CreateFromDirectory(LOC13, zipPath13, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO13 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #14
    Dim Timer016 As New Timer
    Private Sub Form28_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer016.Tick, AddressOf Timer016_Tick
            Timer016.Interval = 1
            Timer016.Start()

        Else
            RemoveHandler Timer016.Tick, AddressOf Timer016_Tick
            Timer016.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #14
    Private Sub Timer016_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p14() As Process

        If ListView1.Items.Count > 13 Then

            Dim PRO14 As String ' Name
            PRO14 = ListView1.Items.Item(13).SubItems(0).Text

            Dim LOC14 As String ' Location
            LOC14 = ListView1.Items.Item(13).SubItems(1).Text

            Dim zipPath14 As String = TextBox1.Text + "\" + PRO14 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p14 = Process.GetProcessesByName(PRO14)
            If p14.Count < 1 Then ' Running

                If p14.Count > 0 Then

                    If Lock14 = 1 Then
                        Lock14 = 0
                    End If

                Else
                    If Lock14 = 1 Then
                        Lock14 = 0

                        ZipFile.CreateFromDirectory(LOC14, zipPath14, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO14 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock14 = 0 Then
                    Lock14 = 1

                    ZipFile.CreateFromDirectory(LOC14, zipPath14, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO14 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #15
    Dim Timer017 As New Timer
    Private Sub Form29_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer017.Tick, AddressOf Timer017_Tick
            Timer017.Interval = 1
            Timer017.Start()

        Else
            RemoveHandler Timer017.Tick, AddressOf Timer017_Tick
            Timer017.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #15
    Private Sub Timer017_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p15() As Process

        If ListView1.Items.Count > 14 Then

            Dim PRO15 As String ' Name
            PRO15 = ListView1.Items.Item(14).SubItems(0).Text

            Dim LOC15 As String ' Location
            LOC15 = ListView1.Items.Item(14).SubItems(1).Text

            Dim zipPath15 As String = TextBox1.Text + "\" + PRO15 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p15 = Process.GetProcessesByName(PRO15)
            If p15.Count < 1 Then ' Running

                If p15.Count > 0 Then

                    If Lock15 = 1 Then
                        Lock15 = 0
                    End If

                Else
                    If Lock15 = 1 Then
                        Lock15 = 0

                        ZipFile.CreateFromDirectory(LOC15, zipPath15, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO15 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock15 = 0 Then
                    Lock15 = 1

                    ZipFile.CreateFromDirectory(LOC15, zipPath15, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO15 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #16
    Dim Timer018 As New Timer
    Private Sub Form30_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer018.Tick, AddressOf Timer018_Tick
            Timer018.Interval = 1
            Timer018.Start()

        Else
            RemoveHandler Timer018.Tick, AddressOf Timer018_Tick
            Timer018.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #16
    Private Sub Timer018_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p16() As Process

        If ListView1.Items.Count > 15 Then

            Dim PRO16 As String ' Name
            PRO16 = ListView1.Items.Item(15).SubItems(0).Text

            Dim LOC16 As String ' Location
            LOC16 = ListView1.Items.Item(15).SubItems(1).Text

            Dim zipPath16 As String = TextBox1.Text + "\" + PRO16 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p16 = Process.GetProcessesByName(PRO16)
            If p16.Count < 1 Then ' Running

                If p16.Count > 0 Then

                    If Lock16 = 1 Then
                        Lock16 = 0
                    End If

                Else
                    If Lock16 = 1 Then
                        Lock16 = 0

                        ZipFile.CreateFromDirectory(LOC16, zipPath16, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO16 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock16 = 0 Then
                    Lock16 = 1

                    ZipFile.CreateFromDirectory(LOC16, zipPath16, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO16 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #17
    Dim Timer019 As New Timer
    Private Sub Form31_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer019.Tick, AddressOf Timer019_Tick
            Timer019.Interval = 1
            Timer019.Start()

        Else
            RemoveHandler Timer019.Tick, AddressOf Timer019_Tick
            Timer019.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #17
    Private Sub Timer019_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p17() As Process

        If ListView1.Items.Count > 16 Then

            Dim PRO17 As String ' Name
            PRO17 = ListView1.Items.Item(16).SubItems(0).Text

            Dim LOC17 As String ' Location
            LOC17 = ListView1.Items.Item(16).SubItems(1).Text

            Dim zipPath17 As String = TextBox1.Text + "\" + PRO17 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p17 = Process.GetProcessesByName(PRO17)
            If p17.Count < 1 Then ' Running

                If p17.Count > 0 Then

                    If Lock17 = 1 Then
                        Lock17 = 0
                    End If

                Else
                    If Lock17 = 1 Then
                        Lock17 = 0

                        ZipFile.CreateFromDirectory(LOC17, zipPath17, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO17 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock17 = 0 Then
                    Lock17 = 1

                    ZipFile.CreateFromDirectory(LOC17, zipPath17, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO17 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #18
    Dim Timer020 As New Timer
    Private Sub Form32_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer020.Tick, AddressOf Timer020_Tick
            Timer020.Interval = 1
            Timer020.Start()

        Else
            RemoveHandler Timer020.Tick, AddressOf Timer020_Tick
            Timer020.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #18
    Private Sub Timer020_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p18() As Process

        If ListView1.Items.Count > 17 Then

            Dim PRO18 As String ' Name
            PRO18 = ListView1.Items.Item(17).SubItems(0).Text

            Dim LOC18 As String ' Location
            LOC18 = ListView1.Items.Item(17).SubItems(1).Text

            Dim zipPath18 As String = TextBox1.Text + "\" + PRO18 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p18 = Process.GetProcessesByName(PRO18)
            If p18.Count < 1 Then ' Running

                If p18.Count > 0 Then

                    If Lock18 = 1 Then
                        Lock18 = 0
                    End If

                Else
                    If Lock18 = 1 Then
                        Lock18 = 0

                        ZipFile.CreateFromDirectory(LOC18, zipPath18, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO18 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock18 = 0 Then
                    Lock18 = 1

                    ZipFile.CreateFromDirectory(LOC18, zipPath18, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO18 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #19
    Dim Timer021 As New Timer
    Private Sub Form33_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer021.Tick, AddressOf Timer021_Tick
            Timer021.Interval = 1
            Timer021.Start()

        Else
            RemoveHandler Timer021.Tick, AddressOf Timer021_Tick
            Timer021.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #19
    Private Sub Timer021_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p19() As Process

        If ListView1.Items.Count > 18 Then

            Dim PRO19 As String ' Name
            PRO19 = ListView1.Items.Item(18).SubItems(0).Text

            Dim LOC19 As String ' Location
            LOC19 = ListView1.Items.Item(18).SubItems(1).Text

            Dim zipPath19 As String = TextBox1.Text + "\" + PRO19 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p19 = Process.GetProcessesByName(PRO19)
            If p19.Count < 1 Then ' Running

                If p19.Count > 0 Then

                    If Lock19 = 1 Then
                        Lock19 = 0
                    End If

                Else
                    If Lock19 = 1 Then
                        Lock19 = 0

                        ZipFile.CreateFromDirectory(LOC19, zipPath19, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO19 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock19 = 0 Then
                    Lock19 = 1

                    ZipFile.CreateFromDirectory(LOC19, zipPath19, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO19 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    ' Look for game start/exit, Save to dirr (Clock) #20
    Dim Timer022 As New Timer
    Private Sub Form34_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Check if Process running
        Dim Run As Integer
        If Run = 0 Then
            AddHandler Timer022.Tick, AddressOf Timer022_Tick
            Timer022.Interval = 1
            Timer022.Start()

        Else
            RemoveHandler Timer022.Tick, AddressOf Timer022_Tick
            Timer022.Stop()
        End If
    End Sub

    ' Look for game start/exit, Save to dirr #20
    Private Sub Timer022_Tick(sender As Object, e As EventArgs)

        ' Start Code

        Dim p20() As Process

        If ListView1.Items.Count > 19 Then

            Dim PRO20 As String ' Name
            PRO20 = ListView1.Items.Item(19).SubItems(0).Text

            Dim LOC20 As String ' Location
            LOC20 = ListView1.Items.Item(19).SubItems(1).Text

            Dim zipPath20 As String = TextBox1.Text + "\" + PRO20 + "                               - " + Date.Now.ToString("ddMMyy-hhmmss.fff") + ".zip"


            ' Code begining
            p20 = Process.GetProcessesByName(PRO20)
            If p20.Count < 1 Then ' Running

                If p20.Count > 0 Then

                    If Lock20 = 1 Then
                        Lock20 = 0
                    End If

                Else
                    If Lock20 = 1 Then
                        Lock20 = 0

                        ZipFile.CreateFromDirectory(LOC20, zipPath20, CompressionLevel.Fastest, True)

                        ' Notify Backup
                        If CheckBox1.Checked = True Then

                            NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO20 + """" + " Backup In Progress.", ToolTipIcon.Info)

                        Else
                        End If

                    End If
                End If

            Else ' Not running

                If Lock20 = 0 Then
                    Lock20 = 1

                    ZipFile.CreateFromDirectory(LOC20, zipPath20, CompressionLevel.Fastest, True)

                    ' Notify Backup
                    If CheckBox1.Checked = True Then

                        NotifyIcon1.ShowBalloonTip(250, "GameBackerPlus", """" + PRO20 + """" + " Backup In Progress.", ToolTipIcon.Info)

                    Else
                    End If

                End If

            End If
        Else
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Me.Visible = False
    End Sub
End Class
