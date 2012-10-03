Imports Spr.CricketTicker.Library

Namespace Forms

    Public Class CricketTicker
        Implements ICricketTickerView

        Private ReadOnly _presenter As CricketTickerPresenter

        Public Sub New(service As ICricketService, gameId As String)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _presenter = New CricketTickerPresenter(Me, service, gameId)
        End Sub

        Private Sub TickerForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            Label1.Text = "Please wait..."
        End Sub

        Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
            Close()
        End Sub

        Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
            If e.Button = MouseButtons.Left Then
                DragForm()
            End If
        End Sub

        Private Sub Timer1_Tick(sender As System.Object, e As EventArgs) Handles Timer1.Tick
            _presenter.UpdateTicker()
        End Sub

        Private Sub DragForm()
            Label1.Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1S
            Const HTCAPTION As Integer = 2
            Dim msg As Message = Message.Create(Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
            DefWndProc(msg)
        End Sub

        Private Sub CricketTicker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            _presenter.UpdateTicker()
        End Sub

        Public Sub UpdateTicker(caption As String) Implements ICricketTickerView.UpdateTicker
            Label1.Text = caption
        End Sub

        Public Sub DisplayScorecard(details As String) Implements ICricketTickerView.DisplayScorecard
            Throw New NotImplementedException
        End Sub

        Public Sub SetTooltipText(details As String) Implements ICricketTickerView.SetTooltipText
            Dim tickerToolTip As New ToolTip
            With tickerToolTip
                .AutoPopDelay = 30000
                .ToolTipTitle = "Match Details"
                .ShowAlways = True
                .InitialDelay = 1500
                .SetToolTip(Label1, details)
            End With
        End Sub

    End Class

End Namespace