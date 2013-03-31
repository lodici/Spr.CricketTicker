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
            Me.components = New System.ComponentModel.Container()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.TopMostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.DefaultColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.DesktopColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TitlebarColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.OpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.ReverseScoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(295, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "TTTT:000 TTTT:000/00 OV:00.0 RR:00.0/00.0"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TopMostToolStripMenuItem, Me.ColorToolStripMenuItem, Me.OpacityToolStripMenuItem, Me.ToolStripSeparator2, Me.ReverseScoreToolStripMenuItem, Me.ToolStripSeparator1, Me.CloseToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(147, 126)
            '
            'TopMostToolStripMenuItem
            '
            Me.TopMostToolStripMenuItem.Name = "TopMostToolStripMenuItem"
            Me.TopMostToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.TopMostToolStripMenuItem.Text = "Keep on Top"
            '
            'ColorToolStripMenuItem
            '
            Me.ColorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultColorToolStripMenuItem, Me.DesktopColorToolStripMenuItem, Me.TitlebarColorToolStripMenuItem})
            Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
            Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.ColorToolStripMenuItem.Text = "Colour"
            '
            'DefaultColorToolStripMenuItem
            '
            Me.DefaultColorToolStripMenuItem.Name = "DefaultColorToolStripMenuItem"
            Me.DefaultColorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
            Me.DefaultColorToolStripMenuItem.Text = "Default"
            '
            'DesktopColorToolStripMenuItem
            '
            Me.DesktopColorToolStripMenuItem.Name = "DesktopColorToolStripMenuItem"
            Me.DesktopColorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
            Me.DesktopColorToolStripMenuItem.Text = "Desktop"
            '
            'TitlebarColorToolStripMenuItem
            '
            Me.TitlebarColorToolStripMenuItem.Name = "TitlebarColorToolStripMenuItem"
            Me.TitlebarColorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
            Me.TitlebarColorToolStripMenuItem.Text = "Window Titlebar"
            '
            'OpacityToolStripMenuItem
            '
            Me.OpacityToolStripMenuItem.Name = "OpacityToolStripMenuItem"
            Me.OpacityToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.OpacityToolStripMenuItem.Text = "Opacity..."
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(143, 6)
            '
            'ReverseScoreToolStripMenuItem
            '
            Me.ReverseScoreToolStripMenuItem.Name = "ReverseScoreToolStripMenuItem"
            Me.ReverseScoreToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.ReverseScoreToolStripMenuItem.Text = "Reverse Score"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(143, 6)
            '
            'CloseToolStripMenuItem
            '
            Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
            Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.CloseToolStripMenuItem.Text = "Close"
            '
            'CricketTicker
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(295, 16)
            Me.ContextMenuStrip = Me.ContextMenuStrip1
            Me.ControlBox = False
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MaximizeBox = False
            Me.MaximumSize = New System.Drawing.Size(412, 218)
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(272, 18)
            Me.Name = "CricketTicker"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.TopMost = True
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ReverseScoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DefaultColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DesktopColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TitlebarColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents OpacityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TopMostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    End Class
End Namespace