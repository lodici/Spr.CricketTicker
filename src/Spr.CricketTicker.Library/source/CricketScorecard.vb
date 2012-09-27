Public Class CricketScorecard

    Public Enum GameTypeEnum
        Unknown = 0
        Test = 1
        OneDay = 2
        Twenty20 = 3
    End Enum

    Private _battingTeamRunsScored(2) As Integer
    Private _bowlingTeamRunsScored(2) As Integer

    Public Property BattingTeam As CricketTeamStats
    Public Property BowlingTeam As CricketTeamStats

    Public Property GameType As GameTypeEnum = GameTypeEnum.Unknown
    Public Property OversBowled As Single
    Public Property GameStatus As String
    Public Property WicketsLost As Integer
    Public Property RunsScored As Integer
    Public Property TeamBattingRunsDifference As String
    Public Property TeamBowlingName As String
    Public Property TeamBowlingInningsScores As String
    Public Property SeriesTitle As String
    Public Property SeriesSubTitle As String
    Public Property GameTitle As String
    Public Property GameLocation As String
    Public Property DayNumber As Integer
    Public Property TeamBattingRunRate As Single
    Public Property TeamBattingRequiredRunRate As Single

End Class

Public Class CricketTeamStats
    Public Property Id As Integer
    Public Property Name As String
    Public Property Abbreviation As String
    Public Property Runs As Integer()
End Class
