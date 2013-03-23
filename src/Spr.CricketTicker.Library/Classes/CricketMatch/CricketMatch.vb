Imports System.Text

Public Class CricketMatch

    '// See Cricket Web Service Short Guide.pdf
    Public Enum MatchResultCode
        None = 0
        Result = 1
        Draw = 2
        Tie = 3
        Abandoned = 4
        Cancelled = 5
        Postponed = 6
    End Enum

    Private _teams(0 To 1) As CricketTeam
    Private _innings(0 To 4) As Innings '// ie. 1 to 4. Ignore zero.
    Private _matchStatus As String = "Match yet to begin"
    Private _winningTeam As CricketTeam

#Region "Properties"

    Public Property Id As String
    Public Property SeriesName As String
    Public Property MatchTitle As String
    Public Property Venue As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property CurrentStatus As String
    Public Property CurrentInningsNumber As Integer = 1
    Public Property DayNumber As Integer = 1
    Public Property SessionNumber As Integer = 1
    Public Property MatchResult As MatchResultCode = MatchResultCode.None
    Public Property ReverseScoreDisplay As Boolean = False

    Public ReadOnly Property Teams As CricketTeam()
        Get
            Return _teams
        End Get
    End Property

    Public ReadOnly Property HomeTeam As CricketTeam
        Get
            Return _teams(0)
        End Get
    End Property

    Public ReadOnly Property AwayTeam As CricketTeam
        Get
            Return _teams(1)
        End Get
    End Property

    Public ReadOnly Property WinningTeam As CricketTeam
        Get
            Return _winningTeam
        End Get
    End Property

    Public Property MatchStatus As String
        Set(value As String)
            _matchStatus = value
        End Set
        Get
            Return GetMatchStatus()
        End Get
    End Property

    Public ReadOnly Property IsMatchStarted As Boolean
        Get
            Return StrComp(MatchStatus, "Match yet to begin", CompareMethod.Text) <> 0
        End Get
    End Property

    Public ReadOnly Property IsMatchInProgress As Boolean
        Get
            Return IsMatchStarted And Not Me.IsMatchFinished
        End Get
    End Property

    Public ReadOnly Property IsMatchFinished As Boolean
        Get
            Return (MatchResult <> MatchResultCode.None)
        End Get
    End Property

    Public Overridable ReadOnly Property TickerCaption As String
        Get
            Return MatchStatus
        End Get
    End Property

    Public Overridable ReadOnly Property MatchSummary As String
        Get
            Throw New Exception("Must override in inherited class!")
        End Get
    End Property

    Public ReadOnly Property Innings As Innings()
        Get
            Return _innings
        End Get
    End Property

#End Region

    Public Sub New()
        _teams(0) = New CricketTeam
        _teams(1) = New CricketTeam
        _innings(1) = New Innings(_teams)
        _innings(2) = New Innings(_teams)
        _innings(3) = New Innings(_teams)
        _innings(4) = New Innings(_teams)
    End Sub

    Public Sub SetWinningTeam(teamId As Integer)
        _winningTeam = GetTeamFromId(teamId)
    End Sub

#Region "Protected"

    Protected Function GetMatchStatusCaption() As String
        Dim sb As New StringBuilder
        If StrComp(Me.MatchStatus, "Play in Progress", CompareMethod.Text) <> 0 Then
            sb.Append(" ").Append(Me.MatchStatus)
        End If
        Return sb.ToString
    End Function

    Protected ReadOnly Property CurrentInnings As Innings
        Get
            Return Innings(Me.CurrentInningsNumber)
        End Get
    End Property

    Protected Function GetScore(runsScored As Integer, wicketsLost As Integer) As String
        Dim sb As New StringBuilder
        If ReverseScoreDisplay() Then
            sb.Append(wicketsLost).Append("/").Append(runsScored)
        Else
            sb.Append(runsScored).Append("/").Append(wicketsLost)
        End If
        Return sb.ToString
    End Function

    Protected Function TeamWonIndicator(team As CricketTeam) As String
        If team.Equals(WinningTeam) Then
            Return "[W]"
        Else
            Return String.Empty
        End If
    End Function

    Protected Function GetMatchResultCaption() As String
        Dim sb As New StringBuilder
        sb.AppendLine()
        sb.Append(Me.WinningTeam.Abbreviation).Append(" win")
        Return sb.ToString
    End Function

    Protected Function TickerTeamScore(team As CricketTeam) As String

        Dim battingInnings As IEnumerable(Of Innings) =
            From i In Me.Innings
            Where i IsNot Nothing _
            AndAlso i.BattingTeam IsNot Nothing _
            AndAlso i.BattingTeam.Equals(team)
            Select i

        Dim scoreCaption As String = String.Empty
        For Each i In battingInnings
            Dim inningsScore As String
            If i.Equals(CurrentInnings) Then
                If (IsMatchInProgress And MatchStatus <> "Innings Break") Or (MatchStatus = "Match yet to begin") Then
                    Dim scorePart1 As String
                    Dim scorePart2 As String
                    If ReverseScoreDisplay() Then
                        scorePart1 = i.WicketsLost.ToString.ToString
                        scorePart2 = i.RunsScored.ToString
                    Else
                        scorePart1 = i.RunsScored.ToString
                        scorePart2 = i.WicketsLost.ToString
                    End If
                    inningsScore = scorePart1 + "/" + scorePart2
                Else
                    inningsScore = i.RunsScored.ToString
                End If
            Else
                inningsScore = i.RunsScored.ToString
            End If
            If scoreCaption = String.Empty Then
                scoreCaption = inningsScore
            Else
                scoreCaption += "+" + inningsScore
            End If
        Next

        If scoreCaption = String.Empty Then
            scoreCaption = "0"
        End If

        Return scoreCaption

    End Function

    ''' <remarks>
    ''' The first innings score for a team is not necessarily the current
    ''' innings -2. If a team follows on then it is -1 and for the bowling
    '''  team (should they have to bat again) it will be -3.
    ''' </remarks>
    Protected Function GetFirstInningsScore(teamAbbreviation As String) As Integer
        '// Not using the 0-element of the array so need a short-circuit check for Nothing.
        Dim score As Integer =
            (From i In Me.Innings
            Where i IsNot Nothing _
            AndAlso i.BattingTeam.Abbreviation = teamAbbreviation
            Select i)(0).RunsScored
        Return score
    End Function

    Protected Function GetDiffOfBattingTeamScoreToBowlingTeamScore(battingTeam As String, bowlingTeam As String) As Integer
        Dim diff As Integer = 0
        If Me.CurrentInningsNumber = 2 Then
            diff = Me.Innings(2).RunsScored - Me.Innings(1).RunsScored
        ElseIf Me.CurrentInningsNumber > 2 Then
            Dim battingTeamFirstInningsScore As Integer = GetFirstInningsScore(battingTeam)
            Dim bowlingTeamFirstInningsScore As Integer = GetFirstInningsScore(bowlingTeam)
            If Me.CurrentInningsNumber = 3 Then
                diff = (Me.Innings(3).RunsScored + battingTeamFirstInningsScore) - bowlingTeamFirstInningsScore
            ElseIf Me.CurrentInningsNumber = 4 Then
                diff = (Me.Innings(4).RunsScored + battingTeamFirstInningsScore) - (Me.Innings(3).RunsScored + bowlingTeamFirstInningsScore)
            End If
        End If
        Return diff
    End Function

    Protected Function GetBattingTeamRunDifference() As String
        Dim sb As New StringBuilder
        Dim battingTeam As String = CurrentInnings.BattingTeam.Abbreviation
        Dim bowlingTeam As String = CurrentInnings.BowlingTeam.Abbreviation
        Dim scoreDiff As Integer = GetDiffOfBattingTeamScoreToBowlingTeamScore(battingTeam, bowlingTeam)
        If scoreDiff <> 0 Then
            sb.AppendLine()
            sb.Append(battingTeam)
            If scoreDiff < 0 Then
                sb.Append(" trail by ")
            ElseIf scoreDiff > 0 Then
                sb.Append(" lead by ")
            End If
            sb.Append(Math.Abs(scoreDiff)).Append(" runs")
            If TypeOf Me Is OneDayMatch Then
                sb.Append(" after ").Append(CurrentInnings.OversBowled).Append(" overs.")
            End If
        End If
        Return sb.ToString
    End Function

#End Region

#Region "Private"

    Private Function GetTeamFromId(teamId As Integer) As CricketTeam
        Return _teams.Single(Function(x) x.Id = teamId)
    End Function

    Private Function GetMatchStatus() As String
        Select Case Me.MatchResult
            Case MatchResultCode.Abandoned
                Return "Match Abandoned"
            Case Else
                Return _matchStatus
        End Select
    End Function

#End Region

End Class
