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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Player))
        Me.BSwitch = New System.Windows.Forms.PictureBox()
        Me.BExit = New System.Windows.Forms.PictureBox()
        Me.Play = New System.ComponentModel.BackgroundWorker()
        Me.VolumeBar = New System.Windows.Forms.ProgressBar()
        Me.NP = New System.Windows.Forms.Label()
        Me.NowPlayingUpdater = New System.ComponentModel.BackgroundWorker()
        Me.BMin = New System.Windows.Forms.PictureBox()
        Me.UpdateChecker = New System.ComponentModel.BackgroundWorker()
        Me.UpdateLink = New System.Windows.Forms.LinkLabel()
        CType(Me.BSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BExit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BExit.BackColor = System.Drawing.Color.Transparent
        Me.BExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BExit.Location = New System.Drawing.Point(374, -1)
        Me.BExit.Name = "BExit"
        Me.BExit.Size = New System.Drawing.Size(24, 24)
        Me.BExit.TabIndex = 1
        Me.BExit.TabStop = False
        '
        'Play
        '
        '
        'VolumeBar
        '
        Me.VolumeBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.VolumeBar.Location = New System.Drawing.Point(31, 73)
        Me.VolumeBar.Margin = New System.Windows.Forms.Padding(0)
        Me.VolumeBar.MarqueeAnimationSpeed = 0
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Size = New System.Drawing.Size(130, 10)
        Me.VolumeBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.VolumeBar.TabIndex = 3
        '
        'NP
        '
        Me.NP.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NP.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NP.Location = New System.Drawing.Point(30, 39)
        Me.NP.Name = "NP"
        Me.NP.Size = New System.Drawing.Size(340, 20)
        Me.NP.TabIndex = 5
        Me.NP.Text = "Loading..."
        Me.NP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'NowPlayingUpdater
        '
        '
        'BMin
        '
        Me.BMin.BackColor = System.Drawing.Color.Transparent
        Me.BMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BMin.Location = New System.Drawing.Point(348, -1)
        Me.BMin.Name = "BMin"
        Me.BMin.Size = New System.Drawing.Size(24, 24)
        Me.BMin.TabIndex = 1
        Me.BMin.TabStop = False
        '
        'UpdateChecker
        '
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
        'Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(398, 595)
        Me.ControlBox = False
        Me.Controls.Add(Me.UpdateLink)
        Me.Controls.Add(Me.NP)
        Me.Controls.Add(Me.VolumeBar)
        Me.Controls.Add(Me.BMin)
        Me.Controls.Add(Me.BExit)
        Me.Controls.Add(Me.BSwitch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Player"
        Me.Text = "Form1"
        CType(Me.BSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BSwitch As System.Windows.Forms.PictureBox
    Friend WithEvents BExit As System.Windows.Forms.PictureBox
    Friend WithEvents Play As System.ComponentModel.BackgroundWorker
    Friend WithEvents VolumeBar As System.Windows.Forms.ProgressBar
    Friend WithEvents NP As System.Windows.Forms.Label
    Friend WithEvents NowPlayingUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents BMin As System.Windows.Forms.PictureBox
    Friend WithEvents UpdateChecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents UpdateLink As System.Windows.Forms.LinkLabel

End Class
