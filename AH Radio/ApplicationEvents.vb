Imports Un4seen.Bass

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub app_Startup() Handles Me.Startup
            If Computer.Network.IsAvailable = False Then
                MsgBox("This application requires an internet connection to run.", MsgBoxStyle.Critical, "Network connection unavailable")
                End
            End If
            ' registration can be obtained here: http://bass.radio42.com/
            Dim BassRegMail As String = ""
            Dim BassRegKey As String = ""
            ' BassNet.Registration(BassRegMail, BassRegKey)
        End Sub

        Private Sub app_NetworkAvailabilityChanged() Handles Me.NetworkAvailabilityChanged
            If Computer.Network.IsAvailable = False Then
                MsgBox("This application requires an internet connection to run.", MsgBoxStyle.Critical, "Network connection unavailable")
                End
            End If
        End Sub

        Private Sub app_StartupNextInstance() Handles Me.StartupNextInstance
            Player.BringToFront()
        End Sub
    End Class


End Namespace

