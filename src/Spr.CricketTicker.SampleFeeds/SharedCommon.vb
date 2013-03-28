Imports System.Xml
Imports System.Reflection
Imports System.IO

Public Class SharedCommon

    Public Enum XmlFeeds
        NoGames
        OneOdiFirstInnings
        OneOdiMatchEnded
        OneOdiOneTest
        OneTestSecondInningsStumps
        TwoOdi
        NzSaTestFourthDay
        UpcomingFiveT20
        UpcomingFourOdiOneTest
        UpcomingIncludingThreeWorldCup
        MissingSubSeries
        BigScoreDoesNotFit
        BigScoreDoesNotFit2
        WomensOdi
    End Enum

    Public Shared Function GetEmbeddedSampleXmlDocument(resourceId As String) As XmlDocument
        '// NOTE, resource Build Action should be set to "Embedded Resource"
        '// See also, http://support.microsoft.com/kb/319291.
        resourceId = "Spr.CricketTicker.SampleFeeds." + resourceId + ".xml"
        Dim assembly As [Assembly] = [assembly].GetExecutingAssembly()
        Dim textStreamReader As New StreamReader(assembly.GetManifestResourceStream(resourceId))
        Dim xml As New XmlDocument
        xml.Load(textStreamReader)
        Return xml
    End Function

    Public Shared Function GetEmbeddedSampleXmlDocument(feedType As XmlFeeds) As XmlDocument
        Return GetEmbeddedSampleXmlDocument(GetResourceId(feedType))
    End Function

    Private Shared Function GetResourceId(feedType As XmlFeeds) As String
        Select Case feedType
            Case XmlFeeds.WomensOdi
                Return "WomensOdi"
            Case XmlFeeds.NoGames
                Return "NoGames"
            Case XmlFeeds.OneOdiFirstInnings
                Return "OneOdiFirstInnings"
            Case XmlFeeds.OneTestSecondInningsStumps
                Return "OneTestSecondInningsStumps"
            Case XmlFeeds.OneOdiOneTest
                Return "OneOdiOneTest"
            Case XmlFeeds.TwoOdi
                Return "TwoOdi"
            Case XmlFeeds.NzSaTestFourthDay
                Return "NzSaTestFourthDay"
            Case XmlFeeds.UpcomingFourOdiOneTest
                Return "UpcomingFourOdiOneTest"
            Case XmlFeeds.UpcomingFiveT20
                Return "UpcomingFiveT20"
            Case XmlFeeds.OneOdiMatchEnded
                Return "OneOdiMatchEnded"
            Case XmlFeeds.UpcomingIncludingThreeWorldCup
                Return "UpcomingIncludingThreeWorldCup"
            Case XmlFeeds.MissingSubSeries
                Return "MissingSubSeries"
            Case XmlFeeds.BigScoreDoesNotFit
                Return "BigScoreDoesNotFitInTicker"
            Case XmlFeeds.BigScoreDoesNotFit2
                Return "BigScoreDoesNotFitInTicker2"
            Case Else
                Throw New IndexOutOfRangeException
        End Select
    End Function


End Class
