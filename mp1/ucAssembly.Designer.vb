<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAssembly
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAssemblyProfile = New System.Windows.Forms.ComboBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.dgProfile = New System.Windows.Forms.DataGridView()
        Me.lblDatecode = New System.Windows.Forms.Label()
        Me.txtDatecode = New System.Windows.Forms.TextBox()
        Me.txtLotcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSupplycode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPartSerial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assembly Profile"
        '
        'cbAssemblyProfile
        '
        Me.cbAssemblyProfile.FormattingEnabled = True
        Me.cbAssemblyProfile.Location = New System.Drawing.Point(93, 8)
        Me.cbAssemblyProfile.Name = "cbAssemblyProfile"
        Me.cbAssemblyProfile.Size = New System.Drawing.Size(257, 21)
        Me.cbAssemblyProfile.TabIndex = 1
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(355, 2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 31)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(449, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(88, 31)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'dgProfile
        '
        Me.dgProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProfile.Location = New System.Drawing.Point(14, 48)
        Me.dgProfile.Name = "dgProfile"
        Me.dgProfile.Size = New System.Drawing.Size(252, 274)
        Me.dgProfile.TabIndex = 4
        '
        'lblDatecode
        '
        Me.lblDatecode.AutoSize = True
        Me.lblDatecode.Location = New System.Drawing.Point(280, 55)
        Me.lblDatecode.Name = "lblDatecode"
        Me.lblDatecode.Size = New System.Drawing.Size(54, 13)
        Me.lblDatecode.TabIndex = 5
        Me.lblDatecode.Text = "Datecode"
        '
        'txtDatecode
        '
        Me.txtDatecode.Location = New System.Drawing.Point(354, 52)
        Me.txtDatecode.Name = "txtDatecode"
        Me.txtDatecode.Size = New System.Drawing.Size(195, 20)
        Me.txtDatecode.TabIndex = 6
        '
        'txtLotcode
        '
        Me.txtLotcode.Location = New System.Drawing.Point(354, 78)
        Me.txtLotcode.Name = "txtLotcode"
        Me.txtLotcode.Size = New System.Drawing.Size(195, 20)
        Me.txtLotcode.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lotcode"
        '
        'txtSupplycode
        '
        Me.txtSupplycode.Location = New System.Drawing.Point(354, 104)
        Me.txtSupplycode.Name = "txtSupplycode"
        Me.txtSupplycode.Size = New System.Drawing.Size(195, 20)
        Me.txtSupplycode.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(280, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Supply code"
        '
        'txtPartSerial
        '
        Me.txtPartSerial.Location = New System.Drawing.Point(354, 130)
        Me.txtPartSerial.Name = "txtPartSerial"
        Me.txtPartSerial.Size = New System.Drawing.Size(195, 20)
        Me.txtPartSerial.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(280, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Serial number"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(354, 156)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(195, 60)
        Me.txtNote.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Note"
        '
        'ucAssembly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPartSerial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSupplycode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLotcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDatecode)
        Me.Controls.Add(Me.lblDatecode)
        Me.Controls.Add(Me.dgProfile)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.cbAssemblyProfile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucAssembly"
        Me.Size = New System.Drawing.Size(597, 383)
        CType(Me.dgProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbAssemblyProfile As ComboBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents dgProfile As DataGridView
    Friend WithEvents lblDatecode As Label
    Friend WithEvents txtDatecode As TextBox
    Friend WithEvents txtLotcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSupplycode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPartSerial As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents Label5 As Label
End Class
