Public Interface ICricketService
    Function GetScorecard(gameId As String) As CricketScorecard
    Function GetListOfLiveGames() As List(Of CricketMatch)
    Function GetListOfUpcomingMatches(afterDate As Date) As List(Of UpcomingMatch)
End Interface
