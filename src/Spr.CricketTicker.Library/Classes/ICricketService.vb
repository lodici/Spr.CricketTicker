Public Interface ICricketService
    ReadOnly Property XmlFeed As Xml.XmlDocument
    Function GetListOfLiveGames() As List(Of CricketMatch)
    Function GetListOfUpcomingMatches(afterDate As Date) As List(Of UpcomingMatch)
    Function GetLatestScore(gameId As String) As CricketMatch
End Interface
