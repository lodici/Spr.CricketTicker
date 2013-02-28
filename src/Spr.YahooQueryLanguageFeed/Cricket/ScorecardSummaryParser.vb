Option Strict Off '// Make life easier using LINQ.
Imports System.Xml
Imports Spr.Extensions
Imports Spr.CricketTicker.Library

Namespace Cricket

    Public Class ScorecardSummaryParser

        Private Enum GameTypeEnum
            Unknown = 0
            Test = 1
            OneDay = 2
            Twenty20 = 3
        End Enum

        Private _xeScorecard As XElement
        Private _cricketMatch As CricketMatch

        Public Function GetListOfLiveGames(xmlDoc As XmlDocument) As List(Of CricketMatch)
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

        Public Function GetLatestScore(xmlDoc As XmlDocument, gameId As String) As CricketMatch
            _xeScorecard = IdentifyScorecardXElementFromGameId(xmlDoc, gameId)
            If _xeScorecard IsNot Nothing Then
                _cricketMatch = GetCricketMatchType()
                ExtractTeams(_cricketMatch.Teams)
                ExtractInningsDetails(_cricketMatch)
                SetWinningTeam(_cricketMatch)
                With _cricketMatch
                    .Id = gameId
                    .DayNumber = ExtractMatchDayNumber()
                    .SessionNumber = ExtractSessionNumber()
                    .MatchStatus = GetGameStatusFromXml()
                    .SeriesName = ExtractSeriesName()
                    .MatchTitle = ExtractMatchTitle()
                    .Venue = ExtractVenue()
                    .StartDate = ExtractStartDate()
                    .EndDate = ExtractEndDate()
                    .MatchResult = ExtractResultCode()
                End With
                Return _cricketMatch
            Else
                Return Nothing
            End If
        End Function

        Public Function ParseSeriesName(xmlValue As String) As String
            Dim captions As String() = Split(xmlValue, ",")
            If captions.Count = 3 Then
                Return captions(1).Trim
            ElseIf captions.Count = 2 Then
                Return captions(0).Trim
            Else
                Return Join(captions, ",").Trim
            End If
        End Function

#Region "Private"

        Private Function GetGameSelectorCaption(xeScorecard As XElement) As String
            Dim homeTeamName As String = xeScorecard.<teams>(0).<fn>.Value
            Dim awayTeamName As String = xeScorecard.<teams>(1).<fn>.Value
            Dim gameTitle As String = xeScorecard.<mn>.Value
            Return homeTeamName + " v " + awayTeamName + ", " + gameTitle
        End Function

        Private Sub SetWinningTeam(matchDetails As CricketMatch)
            If ExtractResultCode() <> CricketMatch.MatchResultCode.None Then
                Dim teamId As Integer = _xeScorecard.<result>.<winner>.Value
                matchDetails.SetWinningTeam(teamId)
            End If
        End Sub

        Private Sub ExtractTeams(ByRef teams As CricketTeam())
            For t = 0 To _xeScorecard.<teams>.Count - 1
                Dim teamXElement As XElement = _xeScorecard.<teams>(t)
                With teams(t)
                    .Id = teamXElement.<i>.Value
                    .Name = teamXElement.<fn>.Value
                    .Abbreviation = teamXElement.<sn>.Value
                End With
            Next
        End Sub

        Private Function ExtractResultCode() As CricketMatch.MatchResultCode
            Return _xeScorecard.<result>.<r>.Value
        End Function

        Private Function ExtractStartDate() As Date
            Return ConvertXmlDateElementToDate(_xeScorecard.<place>.<date>.Value)
        End Function

        Private Function ExtractEndDate() As Date
            Return ConvertXmlDateElementToDate(_xeScorecard.<place>.<enddate>.Value)
        End Function

        Private Function ExtractSeriesName() As String
            Return ParseSeriesName(_xeScorecard.<series>.<series_name>.Value)
        End Function

        Private Function ExtractMatchTitle() As String
            Return _xeScorecard.<mn>.Value
        End Function

        Private Sub ExtractInningsDetails(cricketMatch As CricketMatch)
            Dim inningsCount As Integer = _xeScorecard.<past_ings>.Count
            cricketMatch.CurrentInningsNumber = inningsCount
            For i = 1 To inningsCount
                With cricketMatch.Innings(inningsCount - i + 1)
                    .SetBattingTeam(ExtractBattingTeamId(i))
                    .RunsScored = ExtractRunsScored(i)
                    .WicketsLost = ExtractWicketsTaken(i)
                    .OversBowled = ExtractOversBowled(i)
                    .RunRate = ExtractRunRate()
                    .RequiredRunRate = ExtractRequiredRunRate()
                End With
            Next
        End Sub

        Private Function ExtractBattingTeamId(inningsNumber As Integer) As Integer
            Return _xeScorecard.<past_ings>(inningsNumber - 1).<s>.<a>.<i>.Value
        End Function

        Private Function ExtractRunsScored(inningsNumber As Integer) As Integer
            Return CInt(_xeScorecard.<past_ings>(inningsNumber - 1).<s>.<a>.<r>.Value)
        End Function

        Private Function ExtractWicketsTaken(inningsNumber As Integer) As Integer
            Return CInt(_xeScorecard.<past_ings>(inningsNumber - 1).<s>.<a>.<w>.Value)
        End Function

        Private Function ExtractRunRate() As Single
            Return CSng(_xeScorecard.<past_ings>(0).<s>.<a>.<cr>.Value)
        End Function

        Private Function ExtractRequiredRunRate() As Single
            Return CSng(_xeScorecard.<past_ings>(0).<s>.<a>.<rr>.Value)
        End Function

        Private Function ExtractMatchDayNumber() As Integer
            Dim dayOfMatch As XElement = _xeScorecard.<past_ings>(0).<s>.<dm>(0)
            If dayOfMatch IsNot Nothing Then
                Dim dayNumberString As String = dayOfMatch.Value.Replace("Day", String.Empty).Trim
                If IsNumeric(dayNumberString) Then
                    Return CInt(dayNumberString)
                Else
                    Return 1
                End If
            Else
                Return 0
            End If
        End Function

        Private Function ExtractSessionNumber() As Integer
            Return _xeScorecard.<past_ings>(0).<s>.<sn>.Value
        End Function

        Private Function ExtractVenue() As String
            Dim stadium As String = _xeScorecard.<place>.<stadium>.Value.Replace("&#39;", "'")
            Dim country As String = _xeScorecard.<place>.<country>.Value
            Return stadium.Trim + ", " + country.Trim
        End Function

        Private Function ExtractOversBowled(inningsNumber As Integer) As Single
            Return _xeScorecard.<past_ings>(inningsNumber - 1).<s>.<a>.<o>.Value
        End Function

        Private Function GetBowlingTeamXElement() As XElement
            Dim currentInnings As XElement = _xeScorecard.<past_ings>(0)
            Dim battingTeamId As String = currentInnings.<s>.<a>.<i>.Value
            Return _
                (From xe As XElement In _xeScorecard.<teams>
                    Where xe.<i>.Value <> battingTeamId
                    Select xe)(0)
        End Function

        Private Function IdentifyScorecardXElementFromGameId(xmlDoc As XmlDocument, gameId As String) As XElement
            Return (
                From xe As XElement In xmlDoc.ToXDocument.<query>.<results>.<Scorecard>
                    Where xe.<mid>.Value = gameId
                    Select xe)(0)
        End Function

        Private Function GetGameTypeFromXml() As GameTypeEnum
            Return CType(_xeScorecard.<m>.Value, GameTypeEnum)
        End Function

        Private Function GetGameStatusFromXml() As String
            Return _xeScorecard.<ms>(0).Value
        End Function

        Private Function ConvertXmlDateElementToDate(dateElement As String) As Date
            Return DateSerial(
                CInt(Left(dateElement, 4)),
                CInt(Mid(dateElement, 5, 2)),
                CInt(Mid(dateElement, 7, 2)))
        End Function

        Private Function GetCricketMatchType() As CricketMatch
            Select Case GetGameTypeFromXml()
                Case GameTypeEnum.Test
                    Return New TestMatch
                Case GameTypeEnum.OneDay, GameTypeEnum.Twenty20
                    Return New OneDayMatch
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function

#End Region

    End Class

End Namespace