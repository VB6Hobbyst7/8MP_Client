
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSnippet
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtReturn = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblSuccess = New System.Windows.Forms.Label()
        Me.rtScriptBox = New System.Windows.Forms.RichTextBox()
        Me.lineTextBox = New System.Windows.Forms.Label()
        Me.timerExp = New System.Windows.Forms.Timer(Me.components)
        Me.lblExpToken = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(337, 382)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Run Script"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtReturn
        '
        Me.txtReturn.Location = New System.Drawing.Point(31, 389)
        Me.txtReturn.Name = "txtReturn"
        Me.txtReturn.Size = New System.Drawing.Size(300, 20)
        Me.txtReturn.TabIndex = 6
        Me.txtReturn.Text = "ssdssx"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(28, 435)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(85, 13)
        Me.lblMsg.TabIndex = 11
        Me.lblMsg.Text = "Return Message"
        '
        'lblSuccess
        '
        Me.lblSuccess.AutoSize = True
        Me.lblSuccess.Location = New System.Drawing.Point(28, 412)
        Me.lblSuccess.Name = "lblSuccess"
        Me.lblSuccess.Size = New System.Drawing.Size(48, 13)
        Me.lblSuccess.TabIndex = 12
        Me.lblSuccess.Text = "Success"
        '
        'rtScriptBox
        '
        Me.rtScriptBox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtScriptBox.Location = New System.Drawing.Point(31, 3)
        Me.rtScriptBox.Name = "rtScriptBox"
        Me.rtScriptBox.Size = New System.Drawing.Size(450, 380)
        Me.rtScriptBox.TabIndex = 13
        Me.rtScriptBox.Text = "return ""OK"""
        '
        'lineTextBox
        '
        Me.lineTextBox.AutoSize = True
        Me.lineTextBox.Location = New System.Drawing.Point(-1, 7)
        Me.lineTextBox.Name = "lineTextBox"
        Me.lineTextBox.Size = New System.Drawing.Size(13, 13)
        Me.lineTextBox.TabIndex = 14
        Me.lineTextBox.Text = "1"
        '
        'timerExp
        '
        Me.timerExp.Interval = 1000
        '
        'lblExpToken
        '
        Me.lblExpToken.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExpToken.AutoSize = True
        Me.lblExpToken.Location = New System.Drawing.Point(458, 435)
        Me.lblExpToken.Name = "lblExpToken"
        Me.lblExpToken.Size = New System.Drawing.Size(16, 13)
        Me.lblExpToken.TabIndex = 25
        Me.lblExpToken.Text = "..."
        '
        'frmSnippet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 455)
        Me.Controls.Add(Me.lblExpToken)
        Me.Controls.Add(Me.lineTextBox)
        Me.Controls.Add(Me.rtScriptBox)
        Me.Controls.Add(Me.lblSuccess)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtReturn)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmSnippet"
        Me.Text = "Snippet Code Testing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtReturn As TextBox
    Friend WithEvents lblMsg As Label
    Friend WithEvents lblSuccess As Label
    Friend WithEvents rtScriptBox As RichTextBox
    Friend WithEvents lineTextBox As Label
    Friend WithEvents timerExp As Timer
    Friend WithEvents lblExpToken As Label
End Class
