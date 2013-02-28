Imports Spr.CricketTicker.Library
Imports System.IO
Imports System.Xml

Namespace Cricket

    Public Class CricketService
        Implements ICricketService

        Private ReadOnly _feed As IFeedProvider
        Private _xmlFeed As XmlDocument

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
                Dim parser = New ScorecardSummaryParser
                Return parser.GetListOfLiveGames(liveGamesXml)
            Catch ex As Exception
                log4net.ThreadContext.Properties("xmlFeed") = liveGamesXml.InnerXml
                Throw
            End Try
        End Function

        Public Function GetLatestScore(gameId As String) As CricketTicker.Library.CricketMatch Implements CricketTicker.Library.ICricketService.GetLatestScore
            Dim liveGamesXml As Xml.XmlDocument = _feed.GetLiveGamesAsXml
            _xmlFeed = liveGamesXml
            Try
                Dim parser = New ScorecardSummaryParser
                Return parser.GetLatestScore(liveGamesXml, gameId)
            Catch ex As Exception
                log4net.ThreadContext.Properties("xmlFeed") = liveGamesXml.InnerXml
                Throw
            End Try
        End Function

        Public ReadOnly Property XmlFeed As System.Xml.XmlDocument Implements CricketTicker.Library.ICricketService.XmlFeed
            Get
                Return _xmlFeed
            End Get
        End Property
    End Class

End Namespace