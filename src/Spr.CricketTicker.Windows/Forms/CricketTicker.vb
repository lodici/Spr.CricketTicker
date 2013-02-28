Imports Spr.CricketTicker.Library

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
            SetupTooltip()
            _presenter = New CricketTickerPresenter(Me, service, gameId)
        End Sub

        Private Sub SetupTooltip()
            _tickerToolTip = New ToolTip With {
                .AutoPopDelay = 30000,
                .ToolTipTitle = "Match Summary",
                .ShowAlways = True,
                .InitialDelay = 1500
            }
        End Sub

        Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
            Label1.Text = "Please wait..."
        End Sub

        Private Sub Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            _presenter.UpdateTicker()
        End Sub

        Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
            Close()
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

    End Class

End Namespace