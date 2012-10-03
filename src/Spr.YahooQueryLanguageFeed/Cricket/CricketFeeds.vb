Imports System.Xml
Imports Spr.CricketTicker.Library

Namespace Cricket

    Friend Class CricketFeeds
        Implements IFeedProvider

        Public Function GetUpcomingGamesAsXml() As XmlDocument Implements IFeedProvider.GetUpcomingGamesAsXml
            Return GetXmlDocumentFromUri(My.Settings.YqlUpcomingCricketGamesUri)
        End Function

        Public Function GetLiveGamesAsXml() As XmlDocument Implements CricketTicker.Library.IFeedProvider.GetLiveGamesAsXml
            Return GetXmlDocumentFromUri(My.Settings.YqlLiveCricketGamesUri)
        End Function

        Private Function GetXmlDocumentFromUri(feedUri As String) As XmlDocument
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(feedUri)
                Return xmlDoc
            Catch ex As Exception
                log4net.ThreadContext.Properties("feedUri") = feedUri
                Throw
            End Try
        End Function

    End Class

End Namespace