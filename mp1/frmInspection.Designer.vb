<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInspection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInspection))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSn = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tts1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.btnFail = New System.Windows.Forms.Button()
        Me.lblCapNextPass = New System.Windows.Forms.Label()
        Me.lblCapNextFail = New System.Windows.Forms.Label()
        Me.lblCapRoute = New System.Windows.Forms.Label()
        Me.lblRouting = New System.Windows.Forms.Label()
        Me.lblNextPass = New System.Windows.Forms.Label()
        Me.lblnextFail = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUnitFormat = New System.Windows.Forms.Label()
        Me.lblExpToken = New System.Windows.Forms.Label()
        Me.timerExp = New System.Windows.Forms.Timer(Me.components)
        Me.btnNew = New System.Windows.Forms.Button()
        Me.lblOperation = New System.Windows.Forms.Label()
        Me.btnSnippet = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(417, 29)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(109, 26)
        Me.btnStart.TabIndex = 0
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Enabled = False
        Me.btnRefresh.Location = New System.Drawing.Point(646, 29)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(109, 26)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unit Serial Number :"
        '
        'txtSn
        '
        Me.txtSn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSn.Location = New System.Drawing.Point(171, 29)
        Me.txtSn.Name = "txtSn"
        Me.txtSn.Size = New System.Drawing.Size(240, 26)
        Me.txtSn.TabIndex = 3
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(171, 85)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(240, 67)
        Me.txtComment.TabIndex = 2
        Me.txtComment.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Comment :"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss1, Me.tts1, Me.tss2, Me.tssSn})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(799, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tss1
        '
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(0, 17)
        '
        'tts1
        '
        Me.tts1.Name = "tts1"
        Me.tts1.Size = New System.Drawing.Size(0, 17)
        '
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(0, 17)
        '
        'tssSn
        '
        Me.tssSn.Name = "tssSn"
        Me.tssSn.Size = New System.Drawing.Size(16, 17)
        Me.tssSn.Text = "..."
        Me.tssSn.ToolTipText = "Click to see detail"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(78, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Operation :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(532, 29)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(109, 26)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPass
        '
        Me.btnPass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPass.Enabled = False
        Me.btnPass.Location = New System.Drawing.Point(678, 500)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(109, 41)
        Me.btnPass.TabIndex = 10
        Me.btnPass.TabStop = False
        Me.btnPass.Text = "Pass"
        Me.btnPass.UseVisualStyleBackColor = True
        '
        'btnFail
        '
        Me.btnFail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFail.Enabled = False
        Me.btnFail.Location = New System.Drawing.Point(563, 500)
        Me.btnFail.Name = "btnFail"
        Me.btnFail.Size = New System.Drawing.Size(109, 41)
        Me.btnFail.TabIndex = 11
        Me.btnFail.TabStop = False
        Me.btnFail.Text = "Fail"
        Me.btnFail.UseVisualStyleBackColor = True
        '
        'lblCapNextPass
        '
        Me.lblCapNextPass.AutoSize = True
        Me.lblCapNextPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapNextPass.Location = New System.Drawing.Point(416, 112)
        Me.lblCapNextPass.Name = "lblCapNextPass"
        Me.lblCapNextPass.Size = New System.Drawing.Size(88, 20)
        Me.lblCapNextPass.TabIndex = 16
        Me.lblCapNextPass.Text = "Next Pass :"
        Me.lblCapNextPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapNextFail
        '
        Me.lblCapNextFail.AutoSize = True
        Me.lblCapNextFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapNextFail.Location = New System.Drawing.Point(422, 132)
        Me.lblCapNextFail.Name = "lblCapNextFail"
        Me.lblCapNextFail.Size = New System.Drawing.Size(82, 20)
        Me.lblCapNextFail.TabIndex = 17
        Me.lblCapNextFail.Text = "Next Fail  :"
        Me.lblCapNextFail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapRoute
        '
        Me.lblCapRoute.AutoSize = True
        Me.lblCapRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapRoute.Location = New System.Drawing.Point(431, 92)
        Me.lblCapRoute.Name = "lblCapRoute"
        Me.lblCapRoute.Size = New System.Drawing.Size(73, 20)
        Me.lblCapRoute.TabIndex = 18
        Me.lblCapRoute.Text = "Routing :"
        Me.lblCapRoute.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRouting
        '
        Me.lblRouting.AutoSize = True
        Me.lblRouting.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRouting.Location = New System.Drawing.Point(501, 92)
        Me.lblRouting.Name = "lblRouting"
        Me.lblRouting.Size = New System.Drawing.Size(21, 20)
        Me.lblRouting.TabIndex = 19
        Me.lblRouting.Text = "..."
        Me.lblRouting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNextPass
        '
        Me.lblNextPass.AutoSize = True
        Me.lblNextPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextPass.Location = New System.Drawing.Point(501, 112)
        Me.lblNextPass.Name = "lblNextPass"
        Me.lblNextPass.Size = New System.Drawing.Size(21, 20)
        Me.lblNextPass.TabIndex = 20
        Me.lblNextPass.Text = "..."
        Me.lblNextPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblnextFail
        '
        Me.lblnextFail.AutoSize = True
        Me.lblnextFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextFail.Location = New System.Drawing.Point(501, 132)
        Me.lblnextFail.Name = "lblnextFail"
        Me.lblnextFail.Size = New System.Drawing.Size(21, 20)
        Me.lblnextFail.TabIndex = 21
        Me.lblnextFail.Text = "..."
        Me.lblnextFail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Unit format :"
        '
        'lblUnitFormat
        '
        Me.lblUnitFormat.AutoSize = True
        Me.lblUnitFormat.Location = New System.Drawing.Point(232, 58)
        Me.lblUnitFormat.Name = "lblUnitFormat"
        Me.lblUnitFormat.Size = New System.Drawing.Size(13, 13)
        Me.lblUnitFormat.TabIndex = 23
        Me.lblUnitFormat.Text = ".."
        '
        'lblExpToken
        '
        Me.lblExpToken.AutoSize = True
        Me.lblExpToken.Location = New System.Drawing.Point(739, 12)
        Me.lblExpToken.Name = "lblExpToken"
        Me.lblExpToken.Size = New System.Drawing.Size(16, 13)
        Me.lblExpToken.TabIndex = 24
        Me.lblExpToken.Text = "..."
        '
        'timerExp
        '
        Me.timerExp.Interval = 1000
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(417, 58)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(109, 26)
        Me.btnNew.TabIndex = 25
        Me.btnNew.TabStop = False
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lblOperation
        '
        Me.lblOperation.AutoSize = True
        Me.lblOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperation.Location = New System.Drawing.Point(167, 5)
        Me.lblOperation.Name = "lblOperation"
        Me.lblOperation.Size = New System.Drawing.Size(87, 20)
        Me.lblOperation.TabIndex = 26
        Me.lblOperation.Text = "Operation :"
        '
        'btnSnippet
        '
        Me.btnSnippet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSnippet.Location = New System.Drawing.Point(779, 3)
        Me.btnSnippet.Name = "btnSnippet"
        Me.btnSnippet.Size = New System.Drawing.Size(20, 22)
        Me.btnSnippet.TabIndex = 27
        Me.btnSnippet.Text = "S"
        Me.btnSnippet.UseVisualStyleBackColor = True
        '
        'frmInspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 566)
        Me.Controls.Add(Me.btnSnippet)
        Me.Controls.Add(Me.lblOperation)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.lblExpToken)
        Me.Controls.Add(Me.lblUnitFormat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblnextFail)
        Me.Controls.Add(Me.lblNextPass)
        Me.Controls.Add(Me.lblRouting)
        Me.Controls.Add(Me.lblCapRoute)
        Me.Controls.Add(Me.lblCapNextFail)
        Me.Controls.Add(Me.lblCapNextPass)
        Me.Controls.Add(Me.btnFail)
        Me.Controls.Add(Me.btnPass)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtSn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInspection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "8MP -- Inspection Module"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSn As TextBox
    Friend WithEvents txtComment As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tss1 As ToolStripStatusLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents tts1 As ToolStripStatusLabel
    Friend WithEvents tss2 As ToolStripStatusLabel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnPass As Button
    Friend WithEvents btnFail As Button
    Friend WithEvents lblCapNextPass As Label
    Friend WithEvents lblCapNextFail As Label
    Friend WithEvents lblCapRoute As Label
    Friend WithEvents lblRouting As Label
    Friend WithEvents lblNextPass As Label
    Friend WithEvents lblnextFail As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblUnitFormat As Label
    Friend WithEvents lblExpToken As Label
    Friend WithEvents timerExp As Timer
    Friend WithEvents btnNew As Button
    Friend WithEvents tssSn As ToolStripStatusLabel
    Friend WithEvents lblOperation As Label
    Friend WithEvents btnSnippet As Button
End Class
