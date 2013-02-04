<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Player
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Player))
        Me.BSwitch = New System.Windows.Forms.PictureBox()
        Me.BExit = New System.Windows.Forms.PictureBox()
        Me.Play = New System.ComponentModel.BackgroundWorker()
        Me.NP = New System.Windows.Forms.Label()
        Me.NowPlayingUpdater = New System.ComponentModel.BackgroundWorker()
        Me.BSettings = New System.Windows.Forms.PictureBox()
        Me.UpdateChecker = New System.ComponentModel.BackgroundWorker()
        Me.UpdateLink = New System.Windows.Forms.LinkLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ListenersLabel = New System.Windows.Forms.Label()
        Me.LiveUpdater = New System.Windows.Forms.Timer(Me.components)
        Me.VisTimer = New System.Windows.Forms.Timer(Me.components)
        Me.VisBox = New System.Windows.Forms.PictureBox()
        Me.BMin = New System.Windows.Forms.PictureBox()
        Me.VolumeBar2 = New AHRadio.SmoothProgressBar()
        CType(Me.BSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BSwitch
        '
        Me.BSwitch.BackColor = System.Drawing.Color.Transparent
        Me.BSwitch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BSwitch.Location = New System.Drawing.Point(129, 194)
        Me.BSwitch.Name = "BSwitch"
        Me.BSwitch.Size = New System.Drawing.Size(130, 130)
        Me.BSwitch.TabIndex = 0
        Me.BSwitch.TabStop = False
        '
        'BExit
        '
        Me.BExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BExit.BackColor = System.Drawing.Color.Transparent
        Me.BExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BExit.Location = New System.Drawing.Point(371, 2)
        Me.BExit.Name = "BExit"
        Me.BExit.Size = New System.Drawing.Size(24, 24)
        Me.BExit.TabIndex = 1
        Me.BExit.TabStop = False
        '
        'Play
        '
        Me.Play.WorkerSupportsCancellation = True
        '
        'NP
        '
        Me.NP.BackColor = System.Drawing.Color.Black
        Me.NP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NP.Location = New System.Drawing.Point(30, 41)
        Me.NP.Name = "NP"
        Me.NP.Size = New System.Drawing.Size(340, 18)
        Me.NP.TabIndex = 5
        Me.NP.Text = "Loading..."
        Me.NP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'NowPlayingUpdater
        '
        Me.NowPlayingUpdater.WorkerReportsProgress = True
        '
        'BSettings
        '
        Me.BSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSettings.BackColor = System.Drawing.Color.Transparent
        Me.BSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BSettings.Location = New System.Drawing.Point(319, 2)
        Me.BSettings.Name = "BSettings"
        Me.BSettings.Size = New System.Drawing.Size(24, 24)
        Me.BSettings.TabIndex = 1
        Me.BSettings.TabStop = False
        '
        'UpdateChecker
        '
        Me.UpdateChecker.WorkerReportsProgress = True
        '
        'UpdateLink
        '
        Me.UpdateLink.BackColor = System.Drawing.Color.Transparent
        Me.UpdateLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateLink.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UpdateLink.Location = New System.Drawing.Point(278, 573)
        Me.UpdateLink.Name = "UpdateLink"
        Me.UpdateLink.Size = New System.Drawing.Size(120, 23)
        Me.UpdateLink.TabIndex = 6
        Me.UpdateLink.TabStop = True
        Me.UpdateLink.Text = "Update available!"
        Me.UpdateLink.Visible = False
        '
        'ListenersLabel
        '
        Me.ListenersLabel.BackColor = System.Drawing.Color.Transparent
        Me.ListenersLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListenersLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ListenersLabel.Location = New System.Drawing.Point(1, 573)
        Me.ListenersLabel.Name = "ListenersLabel"
        Me.ListenersLabel.Size = New System.Drawing.Size(114, 23)
        Me.ListenersLabel.TabIndex = 7
        '
        'LiveUpdater
        '
        Me.LiveUpdater.Enabled = True
        Me.LiveUpdater.Interval = 30000
        '
        'VisTimer
        '
        Me.VisTimer.Interval = 50
        '
        'VisBox
        '
        Me.VisBox.BackColor = System.Drawing.Color.Transparent
        Me.VisBox.Location = New System.Drawing.Point(166, 67)
        Me.VisBox.Name = "VisBox"
        Me.VisBox.Size = New System.Drawing.Size(16, 14)
        Me.VisBox.TabIndex = 8
        Me.VisBox.TabStop = False
        '
        'BMin
        '
        Me.BMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BMin.BackColor = System.Drawing.Color.Transparent
        Me.BMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BMin.Location = New System.Drawing.Point(345, 2)
        Me.BMin.Name = "BMin"
        Me.BMin.Size = New System.Drawing.Size(24, 24)
        Me.BMin.TabIndex = 1
        Me.BMin.TabStop = False
        '
        'VolumeBar2
        '
        Me.VolumeBar2.BackColor1 = System.Drawing.Color.White
        Me.VolumeBar2.BackColor2 = System.Drawing.Color.White
        Me.VolumeBar2.BarColor1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.VolumeBar2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VolumeBar2.Location = New System.Drawing.Point(31, 73)
        Me.VolumeBar2.Margin = New System.Windows.Forms.Padding(0)
        Me.VolumeBar2.Name = "VolumeBar2"
        Me.VolumeBar2.Size = New System.Drawing.Size(130, 6)
        Me.VolumeBar2.TabIndex = 3
        '
        'Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(398, 595)
        Me.ControlBox = False
        Me.Controls.Add(Me.VisBox)
        Me.Controls.Add(Me.ListenersLabel)
        Me.Controls.Add(Me.UpdateLink)
        Me.Controls.Add(Me.NP)
        Me.Controls.Add(Me.VolumeBar2)
        Me.Controls.Add(Me.BMin)
        Me.Controls.Add(Me.BSettings)
        Me.Controls.Add(Me.BExit)
        Me.Controls.Add(Me.BSwitch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Player"
        Me.Text = "After Hours Radio"
        CType(Me.BSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BSwitch As System.Windows.Forms.PictureBox
    Friend WithEvents BExit As System.Windows.Forms.PictureBox
    Friend WithEvents Play As System.ComponentModel.BackgroundWorker
    Friend WithEvents VolumeBar2 As SmoothProgressBar
    Friend WithEvents NP As System.Windows.Forms.Label
    Friend WithEvents NowPlayingUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents BSettings As System.Windows.Forms.PictureBox
    Friend WithEvents UpdateChecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents UpdateLink As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ListenersLabel As System.Windows.Forms.Label
    Friend WithEvents LiveUpdater As System.Windows.Forms.Timer
    Friend WithEvents VisTimer As System.Windows.Forms.Timer
    Friend WithEvents VisBox As System.Windows.Forms.PictureBox
    Friend WithEvents BMin As System.Windows.Forms.PictureBox

End Class
