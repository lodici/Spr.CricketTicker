Imports Spr.CricketTicker.Library
Imports Spr.CricketTicker.Settings

Namespace Forms

    Public Class CricketTicker
        Implements ICricketTickerView

        Private Delegate Sub UpdateTickerCallback(caption As String)
        Private Delegate Sub UpdateMatchSummaryCallback(details As String)

        Private _presenter As CricketTickerPresenter
        Private _tickerToolTip As ToolTip

        Public Sub New(service As ICricketService, gameId As String)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _presenter = New CricketTickerPresenter(Me, service, gameId)
            SetupGui()
        End Sub

        Private Sub SetupGui()
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            SetTickerColor()
            SetTickerOpacity(UserSettings.TickerOpacity)
            SetTopMostState(UserSettings.TickerOnTop)
            With Label1
                .AutoSize = False
                .AutoEllipsis = True
                .Text = "Requesting score, please wait..."
            End With
            SetupTooltip()
        End Sub

        Private Sub SetupTooltip()
            _tickerToolTip = New ToolTip With {
                .AutoPopDelay = 20000,
                .ToolTipTitle = "Match Summary",
                .ShowAlways = True,
                .InitialDelay = 1500
            }
        End Sub

        Private Sub SetTopMostState(status As Boolean)
            Me.TopMost = status
            TopMostToolStripMenuItem.Checked = status
        End Sub

        Private Sub SetTickerColor()
            Select Case UserSettings.TickerColor
                Case UserSettings.TickerColorTheme.Desktop
                    Me.BackColor = SystemColors.Desktop
                    If IsColorBright(Me.BackColor) Then
                        Me.ForeColor = Color.Black
                    Else
                        Me.ForeColor = Color.White
                    End If
                    DesktopColorToolStripMenuItem.Checked = True
                Case UserSettings.TickerColorTheme.WindowTitleBar
                    Me.BackColor = SystemColors.ActiveCaption
                    Me.ForeColor = SystemColors.ActiveCaptionText
                    TitlebarColorToolStripMenuItem.Checked = True
                Case Else
                    Me.BackColor = SystemColors.Control
                    Me.ForeColor = SystemColors.ControlText
                    DefaultColorToolStripMenuItem.Checked = True
            End Select
        End Sub

        ''' <remarks>
        ''' Why 130? 
        ''' See http://www.nbdtech.com/Blog/archive/2008/04/27/Calculating-the-Perceived-Brightness-of-a-Color.aspx 
        ''' </remarks>
        Private Function IsColorBright(c As Color) As Boolean
            Return BrightnessIndex(c) >= 130
        End Function

        Private Function BrightnessIndex(c As Color) As Integer
            Return CInt(
                Math.Sqrt(
                    CInt(c.R) * CInt(c.R) * 0.241 +
                    CInt(c.G) * CInt(c.G) * 0.691 +
                    CInt(c.B) * CInt(c.B) * 0.068
                    )
                )
        End Function

        Private Sub Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            Me.Refresh()
            _presenter.UpdateTicker()
        End Sub

        Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
            If e.Button = MouseButtons.Left Then
                DragForm()
            End If
        End Sub

        Private Sub DragForm()
            Label1.Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1S
            Const HTCAPTION As Integer = 2
            Dim msg As Message = Message.Create(Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
            DefWndProc(msg)
        End Sub

        Public Sub UpdateTicker(caption As String) Implements ICricketTickerView.UpdateTicker
            If Me.InvokeRequired Then
                Dim d As New UpdateTickerCallback(AddressOf UpdateTicker)
                Me.BeginInvoke(d, New Object() {caption})
            Else
                Label1.Text = caption
            End If
        End Sub

        Public Sub UpdateMatchSummary(details As String) Implements ICricketTickerView.UpdateMatchSummary
            If Me.InvokeRequired Then
                Dim d As New UpdateMatchSummaryCallback(AddressOf UpdateMatchSummary)
                Me.BeginInvoke(d, New Object() {details})
            Else
                _tickerToolTip.SetToolTip(Label1, details)
            End If
        End Sub

        Private Sub CloseToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles CloseToolStripMenuItem.Click
            Close()
        End Sub

        Private Sub ReverseScoreToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles ReverseScoreToolStripMenuItem.Click
            ReverseScoreToolStripMenuItem.Checked = Not ReverseScoreToolStripMenuItem.Checked
            _presenter.SetReverseScoreFormat(ReverseScoreToolStripMenuItem.Checked)
        End Sub

        Public Sub SetReverseScoreDisplayOption(value As Boolean) Implements Library.ICricketTickerView.SetReverseScoreDisplayOption
            ReverseScoreToolStripMenuItem.Checked = value
        End Sub

        Private Sub ColorToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles TitlebarColorToolStripMenuItem.Click, DesktopColorToolStripMenuItem.Click, DefaultColorToolStripMenuItem.Click
            If sender Is DesktopColorToolStripMenuItem Then
                UserSettings.TickerColor = UserSettings.TickerColorTheme.Desktop
            ElseIf sender Is TitlebarColorToolStripMenuItem Then
                UserSettings.TickerColor = UserSettings.TickerColorTheme.WindowTitleBar
            Else
                UserSettings.TickerColor = UserSettings.TickerColorTheme.Default
            End If
            SetTickerColor()
            ToggleColorMenuCheckState(CType(sender, ToolStripMenuItem))
        End Sub

        Private Sub ToggleColorMenuCheckState(mnu As ToolStripMenuItem)
            DesktopColorToolStripMenuItem.Checked = mnu Is DesktopColorToolStripMenuItem
            TitlebarColorToolStripMenuItem.Checked = mnu Is TitlebarColorToolStripMenuItem
            DefaultColorToolStripMenuItem.Checked = mnu Is DefaultColorToolStripMenuItem
        End Sub

        Private Sub OpacityToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles OpacityToolStripMenuItem.Click
            Me.TopMost = False
            Dim opacity As String = InputBox("Please enter a value between " + UserSettings.MinTickerOpacity.ToString + " and 100." + vbCrLf + "100 = fully opaque.", "Ticker Opacity", UserSettings.TickerOpacity.ToString).Trim
            If opacity <> String.Empty Then
                If IsNumeric(opacity) Then
                    Try
                        UserSettings.TickerOpacity = CInt(opacity)
                        SetTickerOpacity(CInt(opacity))
                    Catch ex As ArgumentOutOfRangeException
                        MessageBox.Show(ex.Message, "Invalid Opacity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                Else
                    MessageBox.Show("Invalid opacity value!", "Invalid Opacity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            SetTopMostState(UserSettings.TickerOnTop)
        End Sub

        Private Sub SetTickerOpacity(percent As Integer)
            Me.Opacity = CDbl(percent / 100)
        End Sub

        Private Sub TopMostToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles TopMostToolStripMenuItem.Click
            UserSettings.TickerOnTop = Not TopMostToolStripMenuItem.Checked
            SetTopMostState(UserSettings.TickerOnTop)
        End Sub
    End Class

End Namespace