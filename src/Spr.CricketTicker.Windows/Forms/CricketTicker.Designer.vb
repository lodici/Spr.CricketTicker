Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CricketTicker
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(314, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "TTTT:000 TTTT:000/00 OV:00.0 RR:00.0/00.0"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TextBox1
            '
            Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBox1.Location = New System.Drawing.Point(1, 43)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBox1.Size = New System.Drawing.Size(313, 0)
            Me.TextBox1.TabIndex = 1
            '
            'Button1
            '
            Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Button1.Location = New System.Drawing.Point(296, 0)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(17, 16)
            Me.Button1.TabIndex = 2
            Me.Button1.UseVisualStyleBackColor = False
            '
            'CricketTicker
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.Button1
            Me.ClientSize = New System.Drawing.Size(314, 16)
            Me.ControlBox = False
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MaximizeBox = False
            Me.MaximumSize = New System.Drawing.Size(412, 18)
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(272, 18)
            Me.Name = "CricketTicker"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class
End Namespace