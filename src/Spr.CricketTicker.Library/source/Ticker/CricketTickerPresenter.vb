Imports System.Text

Public Class CricketTickerPresenter

    Private ReadOnly _log As log4net.ILog =
        log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private ReadOnly _view As ICricketTickerView
    Private ReadOnly _service As ICricketService
    Private _exceptionRaised As Boolean = False
    Private ReadOnly _gameId As String
    Private _scorecard As CricketScorecard
    Private _isTooltipSet As Boolean = False

    Public Sub New(view As ICricketTickerView, service As ICricketService, gameId As String)
        _view = view
        _service = service
        _gameId = gameId
    End Sub

    Public Sub UpdateTicker()
        Try
            If Not _exceptionRaised Then
                _scorecard = _service.GetScorecard(_gameId)
                If _scorecard IsNot Nothing Then
                    If Not _isTooltipSet Then
                        _view.SetTooltipText(GetTooltipText())
                        _isTooltipSet = True
                    End If
                    _view.UpdateTicker(GetSingleLineScore(_scorecard))
                Else
                    _view.UpdateTicker("Game Data Not Available")
                End If
            End If
        Catch ex As Exception
            _exceptionRaised = True
            _log.Error("Runtime Error", ex)
            _view.UpdateTicker("Unexpected Error! Restart Required.")
        End Try
    End Sub

    Private Function GetTooltipText() As String
        Dim sb As New StringBuilder
        With _scorecard
            sb _
                .AppendLine(.SeriesTitle) _
                .AppendLine(.SeriesSubTitle) _
                .AppendLine() _
                .AppendLine(.GameTitle) _
                .Append(.GameLocation)
        End With
        Return sb.ToString
    End Function

    Private Function GetSingleLineScore(scorecard As CricketScorecard) As String
        With scorecard
            If (.GameType = CricketScorecard.GameTypeEnum.OneDay) Or
               (.GameType = CricketScorecard.GameTypeEnum.Twenty20) Then
                Return GetTickerScoreForODI(scorecard)
            Else
                Return _
                    .BattingTeam.Abbreviation + ": " +
                    .RunsScored.ToString + "/" +
                    .WicketsLost.ToString + " " +
                    "(" + .GameStatus + ")"
            End If
        End With
    End Function

    Private Function GetTickerScoreForODI(scorecard As CricketScorecard) As String
        With scorecard
            Dim ticker As String =
                .BowlingTeam.Abbreviation + ":" + .BowlingTeam.Runs(0).ToString +
                " " + .BattingTeam.Abbreviation + ":" + .RunsScored.ToString + "/" + .WicketsLost.ToString
            If StrComp(.GameStatus, "play in progress", CompareMethod.Text) = 0 Then
                ticker +=
                    " OV:" + .OversBowled.ToString("0.0") +
                    " RR:" + .TeamBattingRunRate.ToString("0.00")
                If .BowlingTeam.Runs(0) > 0 Then
                    ticker += "/" + .TeamBattingRequiredRunRate.ToString("0.00")
                End If

            Else
                ticker += " " + .GameStatus
            End If
            Return ticker
        End With
    End Function

    '    Public Sub DisplayScorecard()
    '        If _scorecard IsNot Nothing Then
    '            If _scorecard.GameType = CricketScorecard.GameTypeEnum.Test Then
    '                _view.DisplayScorecard(CreateTestMatchScorecard())
    '            Else
    '                _view.DisplayScorecard(CreateOdiScorecard())
    '            End If
    '        End If
    '    End Sub

    '    Private Function CreateTestMatchScorecard() As String
    '        Dim sb As New StringBuilder
    '        With _scorecard
    '            sb _
    '                .AppendLine(.SeriesTitle) _
    '                .AppendLine(.SeriesSubTitle) _
    '                .AppendLine(String.Empty) _
    '                .Append(.GameTitle).Append(" at ").AppendLine(.GameLocation) _
    '                .Append("Day ").Append(.DayNumber).Append(", ").AppendLine(.GameStatus) _
    '                .AppendLine(String.Empty) _
    '                .Append(.BattingTeam.Name).Append(" ").Append(.RunsScored).Append("/").Append(.WicketsLost.ToString) _
    '                .Append(" [").Append(.TeamBattingRunsDifference).AppendLine("]") _
    '                .Append(.TeamBowlingName).Append(" ").Append(.TeamBowlingInningsScores)
    '        End With
    '        Return sb.ToString
    '    End Function

    '    Private Function CreateOdiScorecard() As String
    '        Dim sb As New StringBuilder
    '        With _scorecard
    '            sb _
    '                .AppendLine(.SeriesTitle) _
    '                .AppendLine(.SeriesSubTitle) _
    '                .AppendLine(String.Empty) _
    '                .Append(.GameTitle).Append(" at ").AppendLine(.GameLocation) _
    '                .AppendLine(.GameStatus) _
    '                .AppendLine(String.Empty) _
    '                .Append(.BattingTeam.Name).Append(" ").Append(.RunsScored).Append("/").Append(.WicketsLost.ToString) _
    '                    .Append(" [").Append("-101").Append("]") _
    '                    .Append(" OV:").Append(.OversBowled) _
    '                    .Append(" RR:").Append(.TeamBattingRequiredRunRate.ToString("0.00")) _
    '                    .Append(" CR:").AppendLine(.TeamBattingRunRate.ToString("0.00")) _
    '            .Append(.TeamBowlingName).Append(" ").Append(.TeamBowlingInningsScores)
    '        End With
    '        'Console.WriteLine(sb.ToString)
    '        Return sb.ToString
    '    End Function

End Class
