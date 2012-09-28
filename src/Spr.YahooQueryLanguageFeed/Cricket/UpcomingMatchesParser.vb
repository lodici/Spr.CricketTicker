Imports System.Xml
Imports Spr.Extensions
Imports Spr.CricketTicker.Library

Namespace Cricket

    Friend Class UpcomingMatchesParser

        Public Shared Function GetListOfUpcomingMatches(xmlDoc As XmlDocument, afterDate As Date) As List(Of UpcomingMatch)
            If xmlDoc IsNot Nothing Then
                Return (From xe As XElement In xmlDoc.ToXDocument.<query>.<results>.<Match>
                    Where CDate(xe.<StartDate>.Value) >= afterDate
                    Order By CDate(xe.<StartDate>.Value)
                    Select New UpcomingMatch With {
                        .Id = xe.@matchid,
                        .SeriesTitle = GetSeriesTitle(xe),
                        .SeriesSubTitle = ParserHelper.GetSeriesSubTitle(xe.@series_name),
                        .MatchNumber = xe.<MatchNo>.Value,
                        .MatchLocation = xe.<Venue>.Value,
                        .Caption = GetGameSelectorCaption(xe),
                        .StartDate = CDate(xe.<StartDate>.Value)
                        }).ToList
            Else
                Return New List(Of UpcomingMatch)
            End If
        End Function

        Private Shared Function GetSeriesTitle(xeMatch As XElement) As String
            Return Split(xeMatch.@series_name, ",")(0)
        End Function

        Private Shared Function GetGameSelectorCaption(xeMatch As XElement) As String
            Dim homeTeamName As String = xeMatch.<Team>(0).@Team
            Dim awayTeamName As String = xeMatch.<Team>(1).@Team
            Dim gameTitle As String = xeMatch.<MatchNo>.Value
            Return homeTeamName + " v " + awayTeamName + ", " + gameTitle
        End Function
    End Class

End Namespace