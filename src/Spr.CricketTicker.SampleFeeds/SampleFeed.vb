Imports System.Xml
Imports Spr.CricketTicker.Library
Imports Spr.Extensions.LinqXmlExtensions

Public Class SampleFeed
    Implements IFeedProvider

    Private Const _ACTIVE_FEED As SharedCommon.XmlFeeds = SharedCommon.XmlFeeds.MissingSubSeries
    Private Const _UPCOMING_FEED As SharedCommon.XmlFeeds = SharedCommon.XmlFeeds.UpcomingFourOdiOneTest
    Private Const _SIMULATED_DELAY = 3000 'millisecs

    Private Sub SimulateCommunicationDelay()
        Threading.Thread.Sleep(_SIMULATED_DELAY)
    End Sub

    Public Function GetUpcomingGamesAsXml() As System.Xml.XmlDocument Implements IFeedProvider.GetUpcomingGamesAsXml
        SimulateCommunicationDelay()
        Return DoctorStartDates(SharedCommon.GetEmbeddedSampleXmlDocument(_UPCOMING_FEED))
    End Function

    Public Function GetLiveGamesAsXml() As System.Xml.XmlDocument Implements IFeedProvider.GetLiveGamesAsXml
        SimulateCommunicationDelay()
        Return SharedCommon.GetEmbeddedSampleXmlDocument(_ACTIVE_FEED)
    End Function

    Private Function DoctorStartDates(xmlDoc As XmlDocument) As XmlDocument
        Dim xDoc As XDocument = xmlDoc.ToXDocument
        Dim xMatches = (
            From xe As XElement In xDoc.<query>.<results>.<Match>
            Order By CDate(xe.<StartDate>.Value)
            Select xe
        )
        Dim minStartDate As Date = CDate(xMatches(0).<StartDate>.Value)
        Dim diffInDays As Long = DateDiff(DateInterval.Day, minStartDate, Now())
        For Each xe As XElement In xMatches
            xe.<StartDate>.Value = DateAdd(DateInterval.Day, diffInDays, CDate(xe.<StartDate>.Value)).ToString
        Next
        Return xDoc.ToXmlDocument
    End Function

End Class
