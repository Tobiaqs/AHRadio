' Version 0.2

Imports Un4seen.Bass
Imports Un4seen.Bass.Misc

Public Class Player

    Public version As Integer = 5

    Public drawing As New Visuals

    Public image As Integer = 0
    Public playing As Boolean = False
    Public Urls As New List(Of String)
    Public stream As Integer
    Public vol As Integer = 80
    Public server As Integer = 0

    Public bitrate As Integer = 192
    Public visOn As Boolean = True

    Public listeners As Integer
    Public nowplaying As String
    Public urllink As String = ""

    Public img_play = My.Resources.play
    Public imgf_play = My.Resources.play_fade
    Public img_pause = My.Resources.pause
    Public imgf_pause = My.Resources.pause_fade

    Private Sub Player_Load() Handles MyBase.Load
        BExit.Image = My.Resources.close
        BMin.Image = My.Resources.min
        BSettings.Image = My.Resources.settings
        BSwitch.Image = img_play
        VolumeBar2.Value = vol
        image = 2

        NowPlayingUpdater.RunWorkerAsync()
        UpdateChecker.RunWorkerAsync()
    End Sub
#Region "Play/pause"
    Public Sub BSwitch_Click() Handles BSwitch.Click, BSwitch.DoubleClick
        If playing Then
            playing = False
            image = 3
            BSwitch.Image = imgf_play
            VisTimer.Stop()
            VisBox.Image = Nothing
            Play.CancelAsync()
            Bass.BASS_StreamFree(stream)
        Else
            playing = True
            image = 1
            BSwitch.Image = imgf_pause
            If visOn Then
                VisTimer.Start()
            End If
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

        If Urls.Count = 0 Then
            Dim wc As New Net.WebClient
            Dim splitter = Split(wc.DownloadString("http://www.ah.fm/" & bitrate & "k.m3u"), vbLf)
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
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, vol / 100)
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

    Private Sub NowPlayingUpdater_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles NowPlayingUpdater.DoWork
        Dim wc As New Net.WebClient
        Dim str As String
        Dim xmlDoc As New System.Xml.XmlDataDocument
        Try
            str = wc.DownloadString("http://www.ah.fm/stats/bannercurrent.xml")
            wc.Dispose()
        Catch ex As Exception
            MsgBox("Couldn't connect to AH.fm, sorry :(" & vbNewLine & vbNewLine & ex.Message)
            Exit Sub
        End Try

        Try
            xmlDoc.LoadXml(str)
        Catch ex As Exception
            MsgBox("Couldn't read AH.fm's data, sorry :(" & vbNewLine & vbNewLine & ex.Message)
        End Try
        nowplaying = xmlDoc.SelectSingleNode("//content/now_playing").InnerText.Replace(" on AH.FM", Nothing)
        urllink = xmlDoc.SelectSingleNode("//content/url_link").InnerText
        listeners = xmlDoc.SelectSingleNode("//content/listeners").InnerText.Replace("+", Nothing)
        LiveUpdater.Start()
        NowPlayingUpdater.ReportProgress(1)
    End Sub

    Private Sub NowPlayingUpdater_ProgressChanged() Handles NowPlayingUpdater.ProgressChanged
        NP.Text = nowplaying
        ToolTip.SetToolTip(NP, nowplaying & vbNewLine & "Click to open forum thread")
        ListenersLabel.Text = listeners & "+ listeners"
    End Sub

    Private Sub UpdateChecker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles UpdateChecker.DoWork
        Dim wc As New Net.WebClient
        If wc.DownloadString("http://afterhours.tobiass.eu/version") > version Then
            UpdateChecker.ReportProgress(1)
        End If
    End Sub

    Private Sub UpdateChecker_ProgressChanged() Handles UpdateChecker.ProgressChanged
        UpdateLink.Visible = True
    End Sub

    Private Sub ListenersUpdater_Tick() Handles LiveUpdater.Tick
        NowPlayingUpdater.RunWorkerAsync()
    End Sub

    Private Sub VisTimer_Tick(sender As Object, e As EventArgs) Handles VisTimer.Tick
        Dim SpectrumImage As Image = New Bitmap(VisBox.Width, VisBox.Height)
        Dim SpectrumRectangle As New Rectangle(VisBox.Location.X, VisBox.Location.Y, VisBox.Width, VisBox.Height)
        Using g As Graphics = Graphics.FromImage(SpectrumImage)
            Try
                VisBox.Image.Dispose()
            Catch
            End Try

            drawing.CreateSpectrumLine(stream, g, SpectrumRectangle, Color.FromArgb(-1), Color.FromArgb(-1), Color.Transparent, 2.8, 2, False, False, False)
            VisBox.Image = SpectrumImage
        End Using
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
        Dim rightSpace As Integer = Screen.PrimaryScreen.Bounds.Width - Me.Width - Me.Left
        Dim bottomSpace As Integer = Screen.PrimaryScreen.Bounds.Height - Me.Height - 40 - Me.Top

        If Me.Left < 0 Then
            Me.Left = 0
        End If
        If Me.Top < 0 Then
            Me.Top = 0
        End If
        If bottomSpace < 0 Then
            Me.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height - 41
        End If
        If rightSpace < 0 Then
            Me.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width - 1
        End If
        drag = False
    End Sub
#End Region
#Region "Volume control"

    Public volumedragging As Boolean = False

    Private Sub VolumeBar2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VolumeBar2.MouseDown
        volumedragging = True
        VolumeBar2.Value = e.X / VolumeBar2.Width * 100
        vol = VolumeBar2.Value
        If playing Then
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, vol / 100)
        End If
    End Sub

    Private Sub VolumeBar2_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VolumeBar2.MouseMove
        If volumedragging Then
            If (e.X / VolumeBar2.Width * 100) > 100 Then
                VolumeBar2.Value = 100
            ElseIf (e.X / VolumeBar2.Width * 100) < 0 Then
                VolumeBar2.Value = 0
            Else
                VolumeBar2.Value = e.X / VolumeBar2.Width * 100
            End If
            vol = VolumeBar2.Value
            If playing Then
                Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, vol / 100)
            End If
        End If
    End Sub

    Private Sub VolumeBar2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VolumeBar2.MouseUp
        volumedragging = False
    End Sub

    Private Sub VolumeBar2_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles VolumeBar2.MouseLeave
        volumedragging = False
    End Sub

#End Region
#Region "Button bindings"
    Private Sub BExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BExit.Click
        Application.Exit()
    End Sub

    Private Sub BMin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BMin.Click
        Me.WindowState = 1
    End Sub

    Private Sub BSettings_Click(sender As Object, e As EventArgs) Handles BSettings.Click
        If Settings.Visible = False Then
            Settings.Show()
        End If
        Settings.BringToFront()

        Dim padding As Integer = (Me.Width - Settings.Width) / 2
        Settings.Left = Me.Left + padding
        Settings.Top = Me.Top + (Me.Height - Settings.Height) - 150
    End Sub

    Private Sub UpdateLink_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles UpdateLink.LinkClicked
        Process.Start("http://afterhours.tobiass.eu")
    End Sub

    Private Sub NP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NP.Click
        If urllink.Length > 0 Then
            Process.Start(urllink)
        End If
    End Sub
#End Region
End Class
