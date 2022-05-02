Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces

Public Class Form1
    Private WithEvents TextForm As New Form
    Private WithEvents TextForm2 As New Form

    Public showText As Boolean
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Short
    Public Const MOUSEEVENTF_MOVE = &H1


    <DllImport("user32.dll", EntryPoint:="mouse_event")>
    Private Shared Sub mouse_event(dwFlags As UInteger, dx As Integer, dy As Integer, dwData As UInteger,
                                   dwExtraInfo As Integer)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Dim colors As Color
    Private Sub TextForm_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles TextForm.Paint
        Dim x = My.Computer.Screen.Bounds.Size.Width / 2
        Dim y = My.Computer.Screen.Bounds.Size.Height / 2
        e.Graphics.DrawString("x", New Font(New FontFamily("Bahnschrift"), 20), New SolidBrush(Color.Red), x - 800, y)


    End Sub
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)

    Public Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Long, ByVal wMapType As Long) As Byte


    <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall,
           CharSet:=CharSet.Unicode, EntryPoint:="keybd_event",
           ExactSpelling:=True, SetLastError:=True)>
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte,
                                  ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    End Sub

    Private Sub TextForm2_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles TextForm2.Paint
        Dim x = My.Computer.Screen.Bounds.Size.Width / 2
        Dim y = My.Computer.Screen.Bounds.Size.Height / 2
        If CheckBox1.Checked Then
            e.Graphics.DrawString("x", New Font(New FontFamily("Bahnschrift"), 20), New SolidBrush(Color.Red), x - 17, y - 400)
        Else
            TextForm2.Hide()
        End If

    End Sub

    Sub dodrag()
        While (CheckBox1.Checked)

            If (GetAsyncKeyState(Keys.E)) Then
                Dim steps As Integer = 6
                For a = 0 To 440 Step steps
                    mouse_event(MOUSEEVENTF_MOVE, 0, -steps, 0, 0)

                Next
                If CheckBox4.Checked Then
                    Thread.Sleep(60)
                    mouse_event(&H2, 0, 0, 0, 0)
                    mouse_event(&H4, 0, 0, 0, 0)
                End If
                Thread.Sleep(30)
                If (BackToTheSamePoint.Checked) Then
                    mouse_event(MOUSEEVENTF_MOVE, 0, 440, 0, 0)

                End If





                Thread.Sleep(1000)
            End If

        End While
    End Sub
    Sub dothreesixty()
        While (CheckBox5.Checked)
            If GetAsyncKeyState(Keys.XButton1) <> 0 Then
                For a = 0 To 11909 Step 30
                    mouse_event(MOUSEEVENTF_MOVE, -30, 0, 0, 0)
                Next
                If CheckBox4.Checked Then
                    Thread.Sleep(20)
                    mouse_event(&H2, 0, 0, 0, 0)
                    mouse_event(&H4, 0, 0, 0, 0)
                End If
                Thread.Sleep(300)



            End If
        End While

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox6.Checked And CheckBox1.Checked Then
            My.Computer.Audio.Play(My.Resources.ddragshot, AudioPlayMode.Background)
        ElseIf CheckBox6.Checked And CheckBox1.Checked = False Then
            My.Computer.Audio.Play(My.Resources.disdrag, AudioPlayMode.Background)
        End If
        Dim thread As New Thread(AddressOf dodrag) : thread.Start()
        With TextForm2
            .BackColor = Color.DimGray
            .TransparencyKey = Color.DimGray
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Opacity = 0.99
            .TopMost = True
            .Hide()
        End With
        TextForm2.Show(Me)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
        With TextForm2
            .BackColor = Color.DimGray
            .TransparencyKey = Color.DimGray
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Opacity = 0.99
            .TopMost = True
            .Hide()
        End With
        TextForm2.Show(Me)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox6.Checked And CheckBox5.Checked Then
            My.Computer.Audio.Play(My.Resources._3360, AudioPlayMode.Background)
        ElseIf CheckBox6.Checked And CheckBox5.Checked = False Then
            My.Computer.Audio.Play(My.Resources._33336660, AudioPlayMode.Background)
        End If
        Dim thread As New Thread(AddressOf dothreesixty) : thread.Start()
    End Sub




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub ValleyButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox3_CheckedChanged_1(sender As Object, e As EventArgs) Handles BackToTheSamePoint.CheckedChanged

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)

    End Sub


    Sub autoclicker()
        My.Computer.FileSystem.WriteAllBytes("cihlclicker.exe", My.Resources.c, False)
        If IO.File.Exists("cihlclicker.exe") = True Then
            Try
                System.Diagnostics.Process.Start("cihlclicker.exe")
            Catch ex As Exception

            End Try

        End If








        'While GetAsyncKeyState(Keys.LButton)
        '    mouse_event(&H2, 0, 0, 0, 0)
        '    mouse_event(&H4, 0, 0, 0, 0)
        'End While
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox6.Checked And CheckBox2.Checked Then
            My.Computer.Audio.Play(My.Resources.autoclick, AudioPlayMode.Background)
        ElseIf CheckBox6.Checked And CheckBox2.Checked = False Then
            My.Computer.Audio.Play(My.Resources.ttsMP3_com_VoiceText_2022_4_21_15_57_44, AudioPlayMode.Background)
        End If
        If CheckBox2.Checked = False Then
            Dim thread As New Thread(Sub()

                                         Dim objProcess As New System.Diagnostics.Process()
                                         objProcess.StartInfo.FileName = "powershell.exe"
                                         objProcess.StartInfo.Arguments = "taskkill /IM ""cihlclicker.exe"" /F"
                                         objProcess.StartInfo.UseShellExecute = False
                                         objProcess.StartInfo.CreateNoWindow = True
                                         objProcess.Start()
                                     End Sub) : thread.Start()


        Else
            Dim thread As New Thread(AddressOf autoclicker) : thread.Start()
        End If
        Dim threadd As New Thread(Sub()
                                      CheckBox2.Enabled = False
                                      Thread.Sleep(1000)
                                      CheckBox2.Enabled = True
                                  End Sub) : threadd.Start()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox6.Checked And CheckBox4.Checked Then
            My.Computer.Audio.Play(My.Resources.autofire, AudioPlayMode.Background)
        ElseIf CheckBox6.Checked And CheckBox4.Checked = False Then
            My.Computer.Audio.Play(My.Resources.autofiredis, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label17.ForeColor = ColorDialog1.Color
            Label16.BackColor = ColorDialog1.Color
            Label15.BackColor = ColorDialog1.Color
            CheckBox1.ForeColor = ColorDialog1.Color
            CheckBox2.ForeColor = ColorDialog1.Color
            CheckBox4.ForeColor = ColorDialog1.Color
            CheckBox5.ForeColor = ColorDialog1.Color
            CheckBox6.ForeColor = ColorDialog1.Color
            PictureBox1.BackColor = ColorDialog1.Color
            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            Label3.ForeColor = ColorDialog1.Color
            Label5.ForeColor = ColorDialog1.Color
            Label4.ForeColor = ColorDialog1.Color
            Label6.ForeColor = ColorDialog1.Color
            Label7.ForeColor = ColorDialog1.Color
            Label8.ForeColor = ColorDialog1.Color
            Label9.ForeColor = ColorDialog1.Color
            Label10.ForeColor = ColorDialog1.Color
            Label11.ForeColor = ColorDialog1.Color
            Label12.ForeColor = ColorDialog1.Color
            Label13.ForeColor = ColorDialog1.Color
            Label14.ForeColor = ColorDialog1.Color
            BackToTheSamePoint.ForeColor = ColorDialog1.Color
            TextBox1.ForeColor = ColorDialog1.Color
            Button1.ForeColor = ColorDialog1.Color
            Button2.ForeColor = ColorDialog1.Color

        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Bytes As Byte() = New System.Text.UTF8Encoding().GetBytes("{
  ""content"": null,
  ""embeds"": [
    {
      ""description"": """ + TextBox1.Text + """,
      ""color"": 49919,
      ""author"": {
        ""name"": ""MW Tool""
      }
    }
  ],
  ""attachments"": []
}")
        Dim Request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("https://discord.com/api/v10/webhooks/966686517944811580/N2_Ow7c_vfnSJktVCx7U3QyX1zGAMuGKoPogep23vVdJOPiGQTOV8wgTaoVI05t68aO_?wait=true"), System.Net.HttpWebRequest)
        Request.Method = "POST"
        Request.Accept = "application/json"
        Request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36"
        Request.ContentType = "application/json"
        Request.Referer = "https://discohook.org/"
        Request.Headers.Add("accept-language", "en")
        Request.Headers.Add("origin", "https://discohook.org")
        Request.Headers.Add("sec-ch-ua", """ Not A;Brand"";v=""99"", ""Chromium"";v=""100"", ""Google Chrome"";v=""100""")
        Request.Headers.Add("sec-ch-ua-mobile", "?0")
        Request.Headers.Add("sec-ch-ua-platform", """Windows""")
        Request.Headers.Add("sec-fetch-dest", "empty")
        Request.Headers.Add("sec-fetch-mode", "cors")
        Request.Headers.Add("sec-fetch-site", "cross-site")
        Request.ContentLength = Bytes.Length
        Dim Stream As System.IO.Stream = Request.GetRequestStream()
        Stream.Write(Bytes, 0, Bytes.Length)
        Stream.Dispose()
        Stream.Close()
        Dim Response As System.Net.HttpWebResponse
        Try
            Response = DirectCast(Request.GetResponse, System.Net.HttpWebResponse)
        Catch ex As System.Net.WebException
            Response = DirectCast(ex.Response, System.Net.HttpWebResponse)
        End Try
        Dim StreamReader As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
        Dim Result As String = StreamReader.ReadToEnd().ToString
        StreamReader.Dispose()
        StreamReader.Close()

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Dim thread As New Thread(Sub()
                                     For Each prog As Process In Process.GetProcesses
                                         If prog.ProcessName = "cihlclicker" Then
                                             prog.Kill()
                                         End If
                                     Next
                                 End Sub) : thread.Start()
        Application.ExitThread()
        Application.Exit()
        End


    End Sub

    Dim pos As Point

    Private Sub form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            Me.pos = e.Location
        End If
    End Sub

    Private Sub form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            MyBase.Location += CType((e.Location - CType(Me.pos, Size)), Size)
        End If
    End Sub

    Dim po As Point

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            Me.po = e.Location
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            MyBase.Location += CType((e.Location - CType(Me.po, Size)), Size)
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim thread As New Thread(Sub()
                                     For Each prog As Process In Process.GetProcesses
                                         If prog.ProcessName = "cihlclicker" Then
                                             prog.Kill()
                                         End If
                                     Next
                                 End Sub) : thread.Start()
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim thread As New Thread(Sub()
                                     For Each prog As Process In Process.GetProcesses
                                         If prog.ProcessName = "cihlclicker" Then
                                             prog.Kill()
                                         End If
                                     Next
                                 End Sub) : thread.Start()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        While True

            If (GetAsyncKeyState(Keys.F3)) Then
                CheckBox1.Checked = Not CheckBox1.Checked
            End If
            If (GetAsyncKeyState(Keys.F4)) Then
                CheckBox5.Checked = Not CheckBox5.Checked
            End If
            If (GetAsyncKeyState(Keys.F5)) Then
                CheckBox2.Checked = Not CheckBox2.Checked
            End If
            If (GetAsyncKeyState(Keys.F6)) Then
                CheckBox4.Checked = Not CheckBox4.Checked
            End If
            Thread.Sleep(500)
        End While

    End Sub
End Class

