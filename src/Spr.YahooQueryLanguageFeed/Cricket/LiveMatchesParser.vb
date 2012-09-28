Imports System.Xml
Imports Spr.Extensions
Imports Spr.CricketTicker.Library

Namespace Cricket

    Friend Class LiveMatchesParser

        Public Shared Function GetListOfLiveGames(xmlDoc As XmlDocument) As List(Of CricketMatch)
            If xmlDoc IsNot Nothing Then
                Return (
                    From xe As XElement In xmlDoc.ToXDocument.<query>.<results>.<Scorecard>
                        Order By xe.<place>.<date>.Value
                        Select New CricketMatch With {
                            .Id = xe.<mid>.Value,
                            .SeriesName = GetGameSelectorCaption(xe),
                            .CurrentStatus = xe.<ms>.Value
                            }
                    ).ToList
            Else
                Return New List(Of CricketMatch)
            End If
        End Function

        Private Shared Function GetGameSelectorCaption(xeScorecard As XElement) As String
            Dim homeTeamName As String = xeScorecard.<teams>(0).<fn>.Value
            Dim awayTeamName As String = xeScorecard.<teams>(1).<fn>.Value
            Dim gameTitle As String = xeScorecard.<mn>.Value
            Return homeTeamName + " v " + awayTeamName + ", " + gameTitle
        End Function

    End Class

End Namespace