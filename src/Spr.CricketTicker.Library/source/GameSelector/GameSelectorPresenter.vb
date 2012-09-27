
Public Class GameSelectorPresenter

    Private Shared ReadOnly _log As log4net.ILog =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private _view As IGameSelectorView
    Private _service As ICricketService
    Private _gameId As String = String.Empty
    Private _upcomingGames As List(Of UpcomingMatch) = Nothing
    Private _liveGames As List(Of CricketMatch) = Nothing

    Public Sub New(view As IGameSelectorView, service As ICricketService)
        _view = view
        _service = service
        DisplayVersionOnStartup()
        DisplayLiveGames()
        DisplayUpcomingGames(Today)
    End Sub

    Public Sub New(view As IGameSelectorView, service As ICricketService, currentDate As Date)
        _view = view
        _service = service
        DisplayVersionOnStartup()
        DisplayLiveGames()
        DisplayUpcomingGames(currentDate)
    End Sub

    Public ReadOnly Property SelectedGameId() As String
        Get
            Return _gameId
        End Get
    End Property

    Public Sub ItemDoubleClicked(gameId As String)
        If IsGameLive(gameId) Then
            _gameId = gameId
            _view.CloseView()
        Else
            DisplayUpcomingGameDetails(gameId)
        End If
    End Sub

    Private Sub DisplayUpcomingGameDetails(gameId As String)
        Dim upcomingMatch As UpcomingMatch = _upcomingGames.Find(Function(x) x.Id = gameId)
        Dim details As String =
            upcomingMatch.SeriesTitle + vbCrLf +
            upcomingMatch.SeriesSubTitle + vbCrLf +
            String.Empty + vbCrLf +
            upcomingMatch.MatchNumber + vbCrLf +
            upcomingMatch.MatchLocation
        'Console.WriteLine("ACTUAL = {0}", details)
        _view.DisplayUpcomingGameDetails(details)
    End Sub

    Private Function IsGameLive(gameId As String) As Boolean
        Return _liveGames.Find(Function(x) x.Id = gameId) IsNot Nothing
    End Function

    Private Sub DisplayVersionOnStartup()
        Dim productVersion As String = SprSnippets.ProductCaption
        _view.SetFormCaption(SprSnippets.ProductCaption)
    End Sub

    Private Sub DisplayLiveGames()
        _liveGames = GetListOfLiveGames()
        For Each game As CricketMatch In _liveGames
            _view.AddSelectorItem(game.Id, game.SeriesName, game.CurrentStatus)
        Next
    End Sub

    Private Function GetListOfLiveGames() As List(Of CricketMatch)
        Try
            Return _service.GetListOfLiveGames()
        Catch ex As Exception
            _log.Error("Runtime Error", ex)
            _view.AddSelectorItem(String.Empty, "Unexpected problem with the Live Games feed!", "FAILED")
            Return New List(Of CricketMatch)
        End Try
    End Function

    Private Sub DisplayUpcomingGames(startingFrom As Date)
        _upcomingGames = GetListOfUpcomingGames(startingFrom)
        For Each game As UpcomingMatch In _upcomingGames
            _view.AddSelectorItem(game.Id, game.Caption, GetStartDateCaption(game.StartDate, startingFrom))
        Next
    End Sub

    Private Function GetListOfUpcomingGames(startingFrom As Date) As List(Of UpcomingMatch)
        Try
            Return _service.GetListOfUpcomingMatches(startingFrom)
        Catch ex As Exception
            _log.Error("Runtime Error", ex)
            _view.AddSelectorItem(String.Empty, "Unexpected problem with the Upcoming Games feed!", "FAILED")
            Return New List(Of UpcomingMatch)
        End Try
    End Function

    Private Function GetStartDateCaption(startDate As Date, currentDate As Date) As String
        If startDate.ToShortDateString = currentDate.ToShortDateString Then
            Return startDate.ToString("HH:mm")
        Else
            Return startDate.ToString("dd/MM/yyyy HH:mm")
        End If
    End Function

End Class
