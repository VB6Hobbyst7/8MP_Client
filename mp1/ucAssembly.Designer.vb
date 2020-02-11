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
        Me.RefDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PN_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDatecode = New System.Windows.Forms.Label()
        Me.txtDatecode = New System.Windows.Forms.TextBox()
        Me.txtLotcode = New System.Windows.Forms.TextBox()
        Me.lblLotcode = New System.Windows.Forms.Label()
        Me.txtSupplycode = New System.Windows.Forms.TextBox()
        Me.lblSupplycode = New System.Windows.Forms.Label()
        Me.txtPartSerial = New System.Windows.Forms.TextBox()
        Me.lblSerialnumber = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.btnAssembly = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblRefDes = New System.Windows.Forms.Label()
        Me.lblRD = New System.Windows.Forms.Label()
        Me.txtPartId = New System.Windows.Forms.TextBox()
        Me.lblPartId = New System.Windows.Forms.Label()
        Me.chkMsd = New System.Windows.Forms.CheckBox()
        Me.lblPN = New System.Windows.Forms.Label()
        CType(Me.dgProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assembly "
        '
        'cbAssemblyProfile
        '
        Me.cbAssemblyProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbAssemblyProfile.FormattingEnabled = True
        Me.cbAssemblyProfile.Location = New System.Drawing.Point(93, 8)
        Me.cbAssemblyProfile.Name = "cbAssemblyProfile"
        Me.cbAssemblyProfile.Size = New System.Drawing.Size(257, 28)
        Me.cbAssemblyProfile.TabIndex = 1
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnStart.Location = New System.Drawing.Point(356, 10)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(109, 26)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnStop.Location = New System.Drawing.Point(471, 10)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(109, 26)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'dgProfile
        '
        Me.dgProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProfile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefDes, Me.PN, Me.PN_TYPE, Me.TITLE})
        Me.dgProfile.Location = New System.Drawing.Point(14, 48)
        Me.dgProfile.Name = "dgProfile"
        Me.dgProfile.Size = New System.Drawing.Size(469, 332)
        Me.dgProfile.TabIndex = 4
        '
        'RefDes
        '
        Me.RefDes.HeaderText = "RefDes"
        Me.RefDes.Name = "RefDes"
        '
        'PN
        '
        Me.PN.HeaderText = "Part Number"
        Me.PN.Name = "PN"
        '
        'PN_TYPE
        '
        Me.PN_TYPE.HeaderText = "Type"
        Me.PN_TYPE.Name = "PN_TYPE"
        '
        'TITLE
        '
        Me.TITLE.HeaderText = "Title"
        Me.TITLE.Name = "TITLE"
        '
        'lblDatecode
        '
        Me.lblDatecode.AutoSize = True
        Me.lblDatecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblDatecode.Location = New System.Drawing.Point(489, 172)
        Me.lblDatecode.Name = "lblDatecode"
        Me.lblDatecode.Size = New System.Drawing.Size(79, 20)
        Me.lblDatecode.TabIndex = 5
        Me.lblDatecode.Text = "Datecode"
        '
        'txtDatecode
        '
        Me.txtDatecode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDatecode.Location = New System.Drawing.Point(599, 169)
        Me.txtDatecode.Name = "txtDatecode"
        Me.txtDatecode.Size = New System.Drawing.Size(195, 26)
        Me.txtDatecode.TabIndex = 8
        '
        'txtLotcode
        '
        Me.txtLotcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLotcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtLotcode.Location = New System.Drawing.Point(599, 198)
        Me.txtLotcode.Name = "txtLotcode"
        Me.txtLotcode.Size = New System.Drawing.Size(195, 26)
        Me.txtLotcode.TabIndex = 9
        '
        'lblLotcode
        '
        Me.lblLotcode.AutoSize = True
        Me.lblLotcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblLotcode.Location = New System.Drawing.Point(489, 204)
        Me.lblLotcode.Name = "lblLotcode"
        Me.lblLotcode.Size = New System.Drawing.Size(67, 20)
        Me.lblLotcode.TabIndex = 7
        Me.lblLotcode.Text = "Lotcode"
        '
        'txtSupplycode
        '
        Me.txtSupplycode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplycode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtSupplycode.Location = New System.Drawing.Point(599, 228)
        Me.txtSupplycode.Name = "txtSupplycode"
        Me.txtSupplycode.Size = New System.Drawing.Size(195, 26)
        Me.txtSupplycode.TabIndex = 10
        '
        'lblSupplycode
        '
        Me.lblSupplycode.AutoSize = True
        Me.lblSupplycode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblSupplycode.Location = New System.Drawing.Point(489, 234)
        Me.lblSupplycode.Name = "lblSupplycode"
        Me.lblSupplycode.Size = New System.Drawing.Size(96, 20)
        Me.lblSupplycode.TabIndex = 9
        Me.lblSupplycode.Text = "Supply code"
        '
        'txtPartSerial
        '
        Me.txtPartSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtPartSerial.Location = New System.Drawing.Point(599, 136)
        Me.txtPartSerial.Name = "txtPartSerial"
        Me.txtPartSerial.Size = New System.Drawing.Size(195, 26)
        Me.txtPartSerial.TabIndex = 7
        '
        'lblSerialnumber
        '
        Me.lblSerialnumber.AutoSize = True
        Me.lblSerialnumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblSerialnumber.Location = New System.Drawing.Point(489, 142)
        Me.lblSerialnumber.Name = "lblSerialnumber"
        Me.lblSerialnumber.Size = New System.Drawing.Size(107, 20)
        Me.lblSerialnumber.TabIndex = 11
        Me.lblSerialnumber.Text = "Serial number"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNote.Location = New System.Drawing.Point(599, 258)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(195, 60)
        Me.txtNote.TabIndex = 11
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblNote.Location = New System.Drawing.Point(489, 261)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(43, 20)
        Me.lblNote.TabIndex = 13
        Me.lblNote.Text = "Note"
        '
        'btnAssembly
        '
        Me.btnAssembly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssembly.Enabled = False
        Me.btnAssembly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnAssembly.Location = New System.Drawing.Point(599, 324)
        Me.btnAssembly.Name = "btnAssembly"
        Me.btnAssembly.Size = New System.Drawing.Size(96, 26)
        Me.btnAssembly.TabIndex = 12
        Me.btnAssembly.Text = "Assembly"
        Me.btnAssembly.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnReset.Location = New System.Drawing.Point(701, 324)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(93, 26)
        Me.btnReset.TabIndex = 13
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblRefDes
        '
        Me.lblRefDes.AutoSize = True
        Me.lblRefDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblRefDes.Location = New System.Drawing.Point(489, 48)
        Me.lblRefDes.Name = "lblRefDes"
        Me.lblRefDes.Size = New System.Drawing.Size(68, 20)
        Me.lblRefDes.TabIndex = 17
        Me.lblRefDes.Text = "RedDes"
        '
        'lblRD
        '
        Me.lblRD.AutoSize = True
        Me.lblRD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblRD.Location = New System.Drawing.Point(595, 48)
        Me.lblRD.Name = "lblRD"
        Me.lblRD.Size = New System.Drawing.Size(21, 20)
        Me.lblRD.TabIndex = 18
        Me.lblRD.Text = "..."
        '
        'txtPartId
        '
        Me.txtPartId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtPartId.Location = New System.Drawing.Point(599, 108)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(195, 26)
        Me.txtPartId.TabIndex = 6
        '
        'lblPartId
        '
        Me.lblPartId.AutoSize = True
        Me.lblPartId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblPartId.Location = New System.Drawing.Point(489, 111)
        Me.lblPartId.Name = "lblPartId"
        Me.lblPartId.Size = New System.Drawing.Size(59, 20)
        Me.lblPartId.TabIndex = 20
        Me.lblPartId.Text = "Part ID"
        '
        'chkMsd
        '
        Me.chkMsd.AutoSize = True
        Me.chkMsd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMsd.Location = New System.Drawing.Point(599, 78)
        Me.chkMsd.Name = "chkMsd"
        Me.chkMsd.Size = New System.Drawing.Size(119, 24)
        Me.chkMsd.TabIndex = 21
        Me.chkMsd.Text = "MSD Control"
        Me.chkMsd.UseVisualStyleBackColor = True
        '
        'lblPN
        '
        Me.lblPN.AutoSize = True
        Me.lblPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPN.Location = New System.Drawing.Point(679, 53)
        Me.lblPN.Name = "lblPN"
        Me.lblPN.Size = New System.Drawing.Size(16, 13)
        Me.lblPN.TabIndex = 22
        Me.lblPN.Text = "..."
        '
        'ucAssembly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPN)
        Me.Controls.Add(Me.chkMsd)
        Me.Controls.Add(Me.lblPartId)
        Me.Controls.Add(Me.txtPartId)
        Me.Controls.Add(Me.lblRD)
        Me.Controls.Add(Me.lblRefDes)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnAssembly)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.txtPartSerial)
        Me.Controls.Add(Me.lblSerialnumber)
        Me.Controls.Add(Me.txtSupplycode)
        Me.Controls.Add(Me.lblSupplycode)
        Me.Controls.Add(Me.txtLotcode)
        Me.Controls.Add(Me.lblLotcode)
        Me.Controls.Add(Me.txtDatecode)
        Me.Controls.Add(Me.lblDatecode)
        Me.Controls.Add(Me.dgProfile)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.cbAssemblyProfile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucAssembly"
        Me.Size = New System.Drawing.Size(809, 392)
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
    Friend WithEvents lblLotcode As Label
    Friend WithEvents txtSupplycode As TextBox
    Friend WithEvents lblSupplycode As Label
    Friend WithEvents txtPartSerial As TextBox
    Friend WithEvents lblSerialnumber As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents lblNote As Label
    Friend WithEvents RefDes As DataGridViewTextBoxColumn
    Friend WithEvents PN As DataGridViewTextBoxColumn
    Friend WithEvents PN_TYPE As DataGridViewTextBoxColumn
    Friend WithEvents TITLE As DataGridViewTextBoxColumn
    Friend WithEvents btnAssembly As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblRefDes As Label
    Friend WithEvents lblRD As Label
    Friend WithEvents txtPartId As TextBox
    Friend WithEvents lblPartId As Label
    Friend WithEvents chkMsd As CheckBox
    Friend WithEvents lblPN As Label
End Class
