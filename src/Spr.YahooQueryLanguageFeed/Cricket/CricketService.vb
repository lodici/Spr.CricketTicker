Imports Spr.CricketTicker.Library

Namespace Cricket

    Public Class CricketService
        Implements ICricketService

        Private ReadOnly _feed As IFeedProvider

        Public Sub New()
            _feed = New CricketFeeds()
        End Sub

        Public Sub New(feed As IFeedProvider)
            _feed = feed
        End Sub

        Public Function GetListOfUpcomingMatches(afterDate As Date) As List(Of CricketTicker.Library.UpcomingMatch) Implements CricketTicker.Library.ICricketService.GetListOfUpcomingMatches
            Return UpcomingMatchesParser.GetListOfUpcomingMatches(_feed.GetUpcomingGamesAsXml, afterDate)
        End Function

        Public Function GetListOfLiveGames() As List(Of CricketTicker.Library.CricketMatch) Implements CricketTicker.Library.ICricketService.GetListOfLiveGames
            Dim liveGamesXml As Xml.XmlDocument = _feed.GetLiveGamesAsXml
            Try
                Return LiveMatchesParser.GetListOfLiveGames(liveGamesXml)
            Catch ex As Exception
                log4net.ThreadContext.Properties("xmlFeed") = liveGamesXml.InnerXml
                Throw
            End Try
        End Function

        Public Function GetScorecard(gameId As String) As CricketTicker.Library.CricketScorecard Implements CricketTicker.Library.ICricketService.GetScorecard
            Dim liveGamesXml As Xml.XmlDocument = _feed.GetLiveGamesAsXml
            Try
                Return ScorecardParser.GetScorecard(liveGamesXml, gameId)
            Catch ex As Exception
                log4net.ThreadContext.Properties("xmlFeed") = liveGamesXml.InnerXml
                Throw
            End Try
        End Function

    End Class

End Namespace