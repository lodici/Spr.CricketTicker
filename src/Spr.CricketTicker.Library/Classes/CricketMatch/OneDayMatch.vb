Imports System.Text

Public Class OneDayMatch
    Inherits CricketMatch

    Public Overrides ReadOnly Property TickerCaption As String
        Get
            Dim sb As New StringBuilder
            sb.Append(HomeTeam.Abbreviation).Append(":")
            sb.Append(TickerTeamScore(HomeTeam))
            sb.Append(TeamWonIndicator(HomeTeam)).Append(" ")
            sb.Append(AwayTeam.Abbreviation).Append(":")
            sb.Append(TickerTeamScore(AwayTeam))
            sb.Append(TeamWonIndicator(AwayTeam))
            If Me.IsMatchInProgress And Me.MatchStatus = "Play in Progress" Then
                sb.Append(" ").Append("Ov:").Append(CurrentInnings.OversBowled.ToString("0.0")).Append(" ")
                If IsMatchFinished = False Then
                    sb.Append("Rt:").Append(CurrentInnings.RunRate.ToString("0.0"))
                    If CurrentInningsNumber = 2 Then
                        sb.Append("/").Append(CurrentInnings.RequiredRunRate.ToString("0.0"))
                    End If
                End If
            End If
            sb.Append(GetMatchStatusCaption())
            Return sb.ToString
        End Get
    End Property

    Public Overrides ReadOnly Property MatchSummary As String
        Get
            Dim sb As New StringBuilder
            sb.Append(HomeTeam.Name).Append(" (").Append(HomeTeam.Abbreviation).Append(") v ")
            sb.Append(AwayTeam.Name).Append(" (").Append(AwayTeam.Abbreviation).AppendLine(")")
            sb.AppendLine(SeriesName)
            sb.AppendLine()
            sb.Append(MatchTitle)
            sb.Append(" (").Append(StartDate.ToString("dd/MM/yyyy")).AppendLine(")")
            sb.AppendLine(Venue)
            sb.AppendLine()
            sb.Append(MatchStatus)
            If MatchResult = MatchResultCode.None Then
                If IsMatchStarted And CurrentInningsNumber > 1 Then
                    sb.AppendLine(GetBattingTeamRunDifference()).Append(GetRequiredRunRateClause())
                End If
            Else
                sb.Append(GetMatchResultCaption)
            End If
            Return sb.ToString
        End Get
    End Property

    Private Function GetRequiredRunRateClause() As String
        If CurrentInningsNumber > 1 Then
            Dim sb As New StringBuilder
            sb.Append("Required run rate is ").Append(Innings(Me.CurrentInningsNumber).RequiredRunRate.ToString("0.0"))
            Return sb.ToString
        Else
            Return String.Empty
        End If
    End Function

End Class
