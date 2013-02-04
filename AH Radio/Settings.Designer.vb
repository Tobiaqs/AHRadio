<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.BitrateSelector = New System.Windows.Forms.ComboBox()
        Me.BitrateLabel = New System.Windows.Forms.Label()
        Me.BClose = New System.Windows.Forms.Button()
        Me.BSave = New System.Windows.Forms.Button()
        Me.VisLabel = New System.Windows.Forms.Label()
        Me.VisCheck = New System.Windows.Forms.CheckBox()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Logo
        '
        Me.Logo.Image = Global.AHRadio.My.Resources.Resources.header
        Me.Logo.Location = New System.Drawing.Point(39, 12)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(260, 98)
        Me.Logo.TabIndex = 0
        Me.Logo.TabStop = False
        '
        'BitrateSelector
        '
        Me.BitrateSelector.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.BitrateSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BitrateSelector.ForeColor = System.Drawing.Color.White
        Me.BitrateSelector.FormattingEnabled = True
        Me.BitrateSelector.Items.AddRange(New Object() {"192kbps", "96kbps", "48kbps"})
        Me.BitrateSelector.Location = New System.Drawing.Point(178, 141)
        Me.BitrateSelector.MaxDropDownItems = 3
        Me.BitrateSelector.Name = "BitrateSelector"
        Me.BitrateSelector.Size = New System.Drawing.Size(121, 21)
        Me.BitrateSelector.TabIndex = 1
        '
        'BitrateLabel
        '
        Me.BitrateLabel.AutoSize = True
        Me.BitrateLabel.ForeColor = System.Drawing.Color.White
        Me.BitrateLabel.Location = New System.Drawing.Point(36, 146)
        Me.BitrateLabel.Name = "BitrateLabel"
        Me.BitrateLabel.Size = New System.Drawing.Size(86, 13)
        Me.BitrateLabel.TabIndex = 2
        Me.BitrateLabel.Text = "Streaming bitrate"
        '
        'BClose
        '
        Me.BClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BClose.ForeColor = System.Drawing.Color.White
        Me.BClose.Location = New System.Drawing.Point(259, 228)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(75, 23)
        Me.BClose.TabIndex = 4
        Me.BClose.Text = "Close"
        Me.BClose.UseVisualStyleBackColor = True
        '
        'BSave
        '
        Me.BSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSave.ForeColor = System.Drawing.Color.White
        Me.BSave.Location = New System.Drawing.Point(178, 228)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 4
        Me.BSave.Text = "Save"
        Me.BSave.UseVisualStyleBackColor = True
        '
        'VisLabel
        '
        Me.VisLabel.AutoSize = True
        Me.VisLabel.ForeColor = System.Drawing.Color.White
        Me.VisLabel.Location = New System.Drawing.Point(36, 176)
        Me.VisLabel.Name = "VisLabel"
        Me.VisLabel.Size = New System.Drawing.Size(65, 13)
        Me.VisLabel.TabIndex = 2
        Me.VisLabel.Text = "Visualization"
        '
        'VisCheck
        '
        Me.VisCheck.AutoSize = True
        Me.VisCheck.Location = New System.Drawing.Point(178, 177)
        Me.VisCheck.Name = "VisCheck"
        Me.VisCheck.Size = New System.Drawing.Size(15, 14)
        Me.VisCheck.TabIndex = 5
        Me.VisCheck.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(337, 255)
        Me.Controls.Add(Me.VisCheck)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.BClose)
        Me.Controls.Add(Me.VisLabel)
        Me.Controls.Add(Me.BitrateLabel)
        Me.Controls.Add(Me.BitrateSelector)
        Me.Controls.Add(Me.Logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.Text = "Settings"
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Friend WithEvents BitrateSelector As System.Windows.Forms.ComboBox
    Friend WithEvents BitrateLabel As System.Windows.Forms.Label
    Friend WithEvents BClose As System.Windows.Forms.Button
    Friend WithEvents BSave As System.Windows.Forms.Button
    Friend WithEvents VisLabel As System.Windows.Forms.Label
    Friend WithEvents VisCheck As System.Windows.Forms.CheckBox
End Class
