Imports Un4seen.Bass

Public Class Player

    Public version As Integer = 1

    Public image As Integer = 0
    Public playing As Boolean = False
    Public Urls As New List(Of String)
    Public stream As Integer
    Public volval As Integer = 100
    Public server As Integer = 0
    Public nowplaying As String

    Public img_play = My.Resources.play
    Public imgf_play = My.Resources.play_fade
    Public img_pause = My.Resources.pause
    Public imgf_pause = My.Resources.pause_fade

    Private Sub Player_Load() Handles MyBase.Load
        BExit.Image = My.Resources.close
        BMin.Image = My.Resources.min
        BSwitch.Image = img_play
        VolumeBar.Value = volval
        image = 2

        NowPlayingUpdater.RunWorkerAsync()
        UpdateChecker.RunWorkerAsync()

        ' Register audio device
        If Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Me.Handle, Nothing) = False Then
            If Bass.BASS_ErrorGetCode = 23 Then
                MsgBox("No audio devices available.")
            Else
                MsgBox("The application can't start due to the error number " & Bass.BASS_ErrorGetCode)
            End If
        End If
    End Sub

#Region "Play/pause"
    Private Sub BSwitch_Click() Handles BSwitch.Click, BSwitch.DoubleClick
        If playing Then
            playing = False
            image = 3
            BSwitch.Image = imgf_play
            Play.CancelAsync()
            Bass.BASS_StreamFree(stream)
        Else
            playing = True
            image = 1
            BSwitch.Image = imgf_pause
            Play.RunWorkerAsync()
        End If
    End Sub

    Private Sub BSwitch_MouseEnter() Handles BSwitch.MouseEnter
        If image = 0 Then
            BSwitch.Image = imgf_pause
            image = 1
        ElseIf image = 2 Then
            BSwitch.Image = imgf_play
            image = 3
        End If
    End Sub

    Private Sub BSwitch_MouseLeave() Handles BSwitch.MouseLeave
        If image = 1 Then
            BSwitch.Image = img_pause
            image = 0
        ElseIf image = 3 Then
            BSwitch.Image = img_play
            image = 2
        End If
    End Sub
#End Region
#Region "Background workers"
    Private Sub startPlaying() Handles Play.DoWork
        Play.WorkerSupportsCancellation = True
        If Urls.Count = 0 Then
            Dim wc As New Net.WebClient
            Dim splitter = Split(wc.DownloadString("http://www.ah.fm/192k.m3u"), vbLf)
            Dim v As String
            For Each v In splitter
                If v.Contains("#") = False Then
                    Urls.Add(v)
                End If
            Next
        End If
again:
        stream = Bass.BASS_StreamCreateURL(Urls(server), 2, BASSFlag.BASS_STREAM_AUTOFREE Or BASSFlag.BASS_STREAM_PRESCAN, Nothing, Nothing)
        If stream <> 0 Then
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volval / 100)
            Bass.BASS_ChannelPlay(stream, False)
            playing = True
        Else
            If Urls.Count - 1 > server Then
                server += 1
                GoTo again
            Else
                playing = False
                MsgBox("Couldn't connect, sorry :(")
            End If
        End If
    End Sub

    Private Sub NowPlayingUpdater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles NowPlayingUpdater.DoWork
        NowPlayingUpdater.WorkerReportsProgress = True
        Dim wc As New Net.WebClient
        Dim xmlDoc As New System.Xml.XmlDataDocument
        xmlDoc.LoadXml(wc.DownloadString("http://www.ah.fm/stats/bannercurrent.xml"))
        nowplaying = xmlDoc.SelectSingleNode("//content/now_playing").InnerText
        NowPlayingUpdater.ReportProgress(1)
    End Sub

    Private Sub NowPlayingUpdater_ProgressChanged() Handles NowPlayingUpdater.ProgressChanged
        NP.Text = nowplaying
    End Sub

    Private Sub UpdateChecker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles UpdateChecker.DoWork
        UpdateChecker.WorkerReportsProgress = True
        Dim wc As New Net.WebClient
        If wc.DownloadString("http://tobiass.eu/ahversion.txt") > version Then
            UpdateChecker.ReportProgress(1)
        End If
    End Sub

    Private Sub UpdateChecker_ProgressChanged() Handles UpdateChecker.ProgressChanged
        UpdateLink.Visible = True
    End Sub

#End Region
#Region "Draggable window"
    Private drag As Boolean
    Private mousex As Integer
    Private mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
#End Region
#Region "Volume control"

    Public volumedragging As Boolean = False

    Private Sub VolumeBar_MouseDown(sender As Object, e As MouseEventArgs) Handles VolumeBar.MouseDown
        volumedragging = True
        VolumeBar.Value = e.X / VolumeBar.Width * 100
        volval = VolumeBar.Value
        If playing Then
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volval / 100)
        End If
    End Sub

    Private Sub VolumeBar_MouseMove(sender As Object, e As MouseEventArgs) Handles VolumeBar.MouseMove
        If volumedragging Then
            If (e.X / VolumeBar.Width * 100) > 100 Then
                VolumeBar.Value = 100
            ElseIf (e.X / VolumeBar.Width * 100) < 0 Then
                VolumeBar.Value = 0
            Else
                VolumeBar.Value = e.X / VolumeBar.Width * 100
            End If
            volval = VolumeBar.Value
            If playing Then
                Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volval / 100)
            End If
        End If
    End Sub

    Private Sub VolumeBar_MouseUp(sender As Object, e As MouseEventArgs) Handles VolumeBar.MouseUp
        volumedragging = False
    End Sub

    Private Sub VolumeBar_MouseLeave(sender As Object, e As EventArgs) Handles VolumeBar.MouseLeave
        volumedragging = False
    End Sub

#End Region
#Region "Button bindings"
    Private Sub BExit_Click(sender As Object, e As EventArgs) Handles BExit.Click
        Application.Exit()
    End Sub

    Private Sub BMin_Click(sender As Object, e As EventArgs) Handles BMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub UpdateLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles UpdateLink.LinkClicked
        Process.Start("http://tobiass.eu/ahradio")
    End Sub
#End Region
End Class
