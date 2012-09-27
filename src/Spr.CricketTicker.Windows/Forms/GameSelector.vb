Imports Spr.CricketTicker.Library

Public Class GameSelector
    Implements IGameSelectorView

    Private _presenter As GameSelectorPresenter
    Private _service As ICricketService

    Public Sub New(service As ICricketService)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _service = service
    End Sub

    Friend ReadOnly Property SelectedGameId As String
        Get
            Return _presenter.SelectedGameId
        End Get
    End Property

    Private Sub SelectGameDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ListView1.Items.Clear()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If IsGameSelected() Then
            _presenter.ItemDoubleClicked(GetSelectedGameId())
        End If
    End Sub

    Private Function IsGameSelected() As Boolean
        Return (ListView1.SelectedItems.Count = 1)
    End Function

    Private Function GetSelectedGameId() As String
        Return ListView1.SelectedItems(0).SubItems(2).Text
    End Function

    Private Sub SelectSeriesForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        PictureBox1.Refresh()
        _presenter = New GameSelectorPresenter(Me, _service)
        PictureBox1.Hide()
    End Sub

    Public Sub SetFormCaption(caption As String) Implements Library.IGameSelectorView.SetFormCaption
        Me.Text = caption
#If USE_SAMPLE_FEED Then
        Me.Text += " ## SAMPLE FEED ##"
#End If
    End Sub

    Public Sub DisplayUpcomingGameDetails(details As String) Implements Library.IGameSelectorView.DisplayUpcomingGameDetails
        MessageBox.Show(details, "Game Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    
    Public Sub AddSelectorItem(gameId As String, gameCaption As String, gameStatus As String) Implements Library.IGameSelectorView.AddSelectorItem
        Dim lvRow(3) As String
        lvRow(0) = gameCaption
        lvRow(1) = gameStatus
        lvRow(2) = gameId
        ListView1.Items.Add(New ListViewItem(lvRow))
    End Sub

    Public Sub CloseView() Implements Library.IGameSelectorView.CloseView
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class