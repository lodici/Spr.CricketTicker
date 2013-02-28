Imports System.Text

Public Class TestMatch
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
            If IsMatchStarted Then
                sb.Append(" D:").Append(Me.DayNumber)
            End If
            If Me.IsMatchInProgress And StrComp(Me.MatchStatus, "Play in Progress", CompareMethod.Text) = 0 Then
                sb.Append(".").Append(Me.SessionNumber)
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
            sb.Append(" (").Append(StartDate.ToString("dd/MM/yyyy")).Append(" - ").Append(EndDate.ToString("dd/MM/yyyy")).AppendLine(")")
            sb.AppendLine(Venue)
            sb.AppendLine()
            sb.Append("Day ").Append(DayNumber).Append(": ").Append(MatchStatus)
            If IsMatchStarted And MatchResult = MatchResultCode.None Then
                sb.AppendLine()
                sb.Append("Innings #").Append(CurrentInningsNumber)
                sb.Append(GetBattingTeamRunDifference())
            ElseIf MatchResult = MatchResultCode.Result Then
                sb.Append(GetMatchResultCaption)
            End If
            Return sb.ToString
        End Get
    End Property

End Class
