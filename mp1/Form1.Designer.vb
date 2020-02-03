
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UcAssembly1 = New mp.ucAssembly()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(639, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 37)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UcAssembly1
        '
        Me.UcAssembly1.absolute_url = Nothing
        Me.UcAssembly1.access_token = Nothing
        Me.UcAssembly1.cache_url = Nothing
        Me.UcAssembly1.CurrentForm = Nothing
        Me.UcAssembly1.Location = New System.Drawing.Point(10, 12)
        Me.UcAssembly1.Name = "UcAssembly1"
        Me.UcAssembly1.ParentObjectName = Nothing
        Me.UcAssembly1.Size = New System.Drawing.Size(604, 332)
        Me.UcAssembly1.TabIndex = 2
        Me.UcAssembly1.url = Nothing
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 467)
        Me.Controls.Add(Me.UcAssembly1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "I am Back"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents UcAssembly1 As ucAssembly
End Class
