Public Class Settings

#Region "Draggable window"
    Private drag As Boolean
    Private mousex As Integer
    Private mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Logo.MouseDown, BitrateLabel.MouseDown, VisLabel.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, Logo.MouseMove, BitrateLabel.MouseMove, VisLabel.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, Logo.MouseUp, BitrateLabel.MouseUp, VisLabel.MouseUp
        Dim rightSpace As Integer = My.Computer.Screen.WorkingArea.Width - Me.Width - Me.Left
        Dim bottomSpace As Integer = My.Computer.Screen.WorkingArea.Height - Me.Height - 40 - Me.Top

        If Me.Left < 0 Then
            Me.Left = 0
        End If
        If Me.Top < 0 Then
            Me.Top = 0
        End If
        If bottomSpace < 0 Then
            Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height - 41
        End If
        If rightSpace < 0 Then
            Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Width - 1
        End If
        drag = False
    End Sub
#End Region

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Player.bitrate = 192 Then
            BitrateSelector.SelectedIndex = 0
        ElseIf Player.bitrate = 96 Then
            BitrateSelector.SelectedIndex = 1
        ElseIf Player.bitrate = 48 Then
            BitrateSelector.SelectedIndex = 2
        Else
            BitrateSelector.SelectedIndex = 0
        End If

        If Player.visOn Then
            VisCheck.Checked = True
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim newbitrate As Integer

        If BitrateSelector.SelectedIndex = 0 Then
            newbitrate = 192
        ElseIf BitrateSelector.SelectedIndex = 1 Then
            newbitrate = 96
        ElseIf BitrateSelector.SelectedIndex = 2 Then
            newbitrate = 48
        End If


        If VisCheck.Checked = Player.visOn = False Then
            Player.visOn = VisCheck.Checked
            If VisCheck.Checked Then
                Player.VisTimer.Start()
            Else
                Player.VisTimer.Stop()
                Player.VisBox.Image = Nothing
            End If
        End If

        If Player.bitrate = newbitrate = False Then
            Player.bitrate = newbitrate
            Player.Urls.Clear()
            If Player.playing Then
                Player.BSwitch_Click()
                Player.BSwitch_Click()
            End If
        End If
        Me.Close()
    End Sub
End Class