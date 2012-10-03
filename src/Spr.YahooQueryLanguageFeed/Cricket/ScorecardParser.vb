Option Strict Off '// Make life easier using LINQ.
Imports System.Xml
Imports Spr.Extensions
Imports Spr.CricketTicker.Library

Namespace Cricket

    Friend Class ScorecardParser

        Private Shared _xeScorecard As XElement

        Public Shared Function GetScorecard(xmlDoc As XmlDocument, gameId As String) As CricketScorecard
            _xeScorecard = IdentifyScorecardXElementFromGameId(xmlDoc, gameId)
            If _xeScorecard IsNot Nothing Then
                Return CreateScorecard()
            Else
                Return Nothing
            End If
        End Function

        Private Shared Function CreateScorecard() As CricketScorecard
            Dim scorecard As New CricketScorecard
            With scorecard
                .BattingTeam = GetBattingTeamStats()
                .BowlingTeam = GetBowlingTeamStats()
                .TeamBattingRunsDifference = "-101"
                .TeamBattingRunRate = ExtractBattingTeamRunRate()
                .TeamBattingRequiredRunRate = ExtractBattingTeamRequiredRate()
                .TeamBowlingName = GetBowlingTeamNameFromXml()
                .TeamBowlingInningsScores = GetBowlingTeamInningsScoresFromXml()
                .RunsScored = GetRunsScoredFromXml()
                .WicketsLost = GetWicketsLostFromXml()
                .GameStatus = GetGameStatusFromXml()
                .GameType = GetGameTypeFromXml()
                .OversBowled = GetOversBowledFromXml()
                .SeriesTitle = GetShortSeriesNameFromXml()
                .SeriesSubTitle = ParserHelper.GetSeriesSubTitle(_xeScorecard.<series>.<series_name>(0).Value)
                .GameTitle = GetGameTitleFromXml()
                .GameLocation = GetGameLocationFromXml()
                .DayNumber = GetDayNumberFromXml()
            End With
            Return scorecard
        End Function

#Region "BattingTeam"

        Private Shared Function GetBattingTeamStats() As CricketTeamStats
            Dim teamId As Integer = _xeScorecard.<past_ings>(0).<s>.<a>.<i>.Value
            Dim teamXe As XElement = ExtractTeamXElement(teamId)
            Return New CricketTeamStats With {
                .Id = teamId,
                .Name = teamXe.<fn>.Value,
                .Abbreviation = teamXe.<sn>.Value,
                .Runs = ExtractTeamInningsRunsScored(teamId)
                }
        End Function

        Private Shared Function GetRunsScoredFromXml() As Integer
            Return CInt(_xeScorecard.<past_ings>(0).<s>.<a>.<r>.Value)
        End Function

        Private Shared Function GetWicketsLostFromXml() As Integer
            Return CInt(_xeScorecard.<past_ings>(0).<s>.<a>.<w>.Value)
        End Function

        Private Shared Function ExtractBattingTeamRunRate() As Single
            Return CSng(_xeScorecard.<past_ings>(0).<s>.<a>.<cr>.Value)
        End Function

        Private Shared Function ExtractBattingTeamRequiredRate() As Single
            Return CSng(_xeScorecard.<past_ings>(0).<s>.<a>.<rr>.Value)
        End Function

#End Region

#Region "BowlingTeam"

        Private Shared Function GetBowlingTeamStats() As CricketTeamStats
            Dim teamId As Integer = ExtractBowlingTeamId()
            Dim teamXe As XElement = ExtractTeamXElement(teamId)
            Return New CricketTeamStats With {
                .Id = teamId,
                .Name = teamXe.<fn>.Value,
                .Abbreviation = teamXe.<sn>.Value,
                .Runs = ExtractTeamInningsRunsScored(teamId)
                }
        End Function

        Private Shared Function ExtractBowlingTeamId() As Integer
            Dim currentInnings As XElement = _xeScorecard.<past_ings>(0)
            Dim battingTeamId As String = currentInnings.<s>.<a>.<i>.Value
            Return _
                (From xe As XElement In _xeScorecard.<teams>
                    Where xe.<i>.Value <> battingTeamId
                    Select xe).First.<i>.Value
        End Function

        Private Shared Function GetBowlingTeamXElement() As XElement
            Dim currentInnings As XElement = _xeScorecard.<past_ings>(0)
            Dim battingTeamId As String = currentInnings.<s>.<a>.<i>.Value
            Return _
                (From xe As XElement In _xeScorecard.<teams>
                    Where xe.<i>.Value <> battingTeamId
                    Select xe)(0)
        End Function

        Private Shared Function GetBowlingTeamNameFromXml() As String
            Return GetBowlingTeamXElement().<fn>.Value
        End Function

        Private Shared Function GetBowlingTeamInningsScoresFromXml() As String
            Dim teamId As String = GetBowlingTeamXElement.<i>.Value
            Dim innings As IEnumerable(Of XElement) = (
                    From xe As XElement In _xeScorecard.<past_ings>
                    Where xe.<s>.<a>.<i>.Value = teamId
                    Order By xe.<s>.<i>.Value
                    Select xe)
            If innings.Count = 0 Then
                Return String.Empty
            ElseIf innings.Count = 1 Then
                Return innings(0).<s>.<a>.<r>.Value
            Else
                Return innings(1).<s>.<a>.<r>.Value + " & " + innings(0).<s>.<a>.<r>.Value
            End If
        End Function

#End Region


        Private Shared Function ExtractTeamXElement(teamId As Integer) As XElement
            Return (
                From xe As XElement In _xeScorecard.<teams>
                    Where xe.<i>.Value = teamId
                    Select xe
                ).First
        End Function

        Private Shared Function ExtractTeamInningsRunsScored(teamId As Integer) As Integer()
            Dim runs(2) As Integer
            Dim innings As IEnumerable(Of XElement) = (
                    From xe As XElement In _xeScorecard.<past_ings>
                    Where xe.<s>.<a>.<i>.Value = teamId
                    Order By xe.<s>.<i>.Value
                    Select xe)
            If innings.Count = 0 Then
                runs(0) = 0
                runs(1) = 0
            ElseIf innings.Count = 1 Then
                runs(0) = innings(0).<s>.<a>.<r>.Value
                runs(1) = 0
            Else
                runs(0) = innings(0).<s>.<a>.<r>.Value
                runs(1) = innings(1).<s>.<a>.<r>.Value
            End If
            Return runs
        End Function

        Private Shared Function GetDayNumberFromXml() As Integer
            Dim dayOfMatch As XElement = _xeScorecard.<past_ings>(0).<s>.<dm>(0)
            If dayOfMatch IsNot Nothing Then
                Return CInt(dayOfMatch.Value.Replace("Day", String.Empty).Trim)
            Else
                Return 0
            End If
        End Function

        Private Shared Function GetGameLocationFromXml() As String
            Dim stadium As String = _xeScorecard.<place>.<stadium>.Value.Replace("&#39;", "'")
            Dim country As String = _xeScorecard.<place>.<country>.Value
            Return stadium.Trim + ", " + country.Trim + "."
        End Function

        Private Shared Function GetGameTitleFromXml() As String
            Return _xeScorecard.<mn>.Value
        End Function

        Private Shared Function GetShortSeriesNameFromXml() As String
            Return Split(_xeScorecard.<series>.<series_name>(0).Value, ",")(0)
        End Function

        Private Shared Function IdentifyScorecardXElementFromGameId(xmlDoc As XmlDocument, gameId As String) As XElement
            Return (
                From xe As XElement In xmlDoc.ToXDocument.<query>.<results>.<Scorecard>
                    Where xe.<mid>.Value = gameId
                    Select xe)(0)
        End Function

        Private Shared Function GetGameTypeFromXml() As CricketScorecard.GameTypeEnum
            Return CType(_xeScorecard.<m>.Value, CricketScorecard.GameTypeEnum)
        End Function

        Private Shared Function GetOversBowledFromXml() As Single
            Return _xeScorecard.<past_ings>.<s>.<a>.<o>.Value
        End Function

        Private Shared Function GetGameStatusFromXml() As String
            Return _xeScorecard.<ms>(0).Value
        End Function

    End Class

End Namespace