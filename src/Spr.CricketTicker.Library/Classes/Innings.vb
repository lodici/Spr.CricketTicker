Public Class Innings

    Private _teams As CricketTeam()
    Private _battingTeam As CricketTeam

    Public Property RunsScored As Integer = 0
    Public Property WicketsLost As Integer = 0
    Public Property OversBowled As Single = 0.0F
    Public Property RunRate As Single = 0.0F
    Public Property RequiredRunRate As Single = 0.0F

    Friend Sub New(ByRef teams As CricketTeam())
        _teams = teams
    End Sub

    Public ReadOnly Property BattingTeam As CricketTeam
        Get
            Return _battingTeam
        End Get
    End Property

    Public ReadOnly Property BowlingTeam As CricketTeam
        Get
            Return _teams.Single(Function(x) x.Id <> Me.BattingTeam.Id)
        End Get
    End Property

    Public Sub SetBattingTeam(teamId As Integer)
        _battingTeam = _teams.Single(Function(x) x.Id = teamId)
    End Sub

End Class
