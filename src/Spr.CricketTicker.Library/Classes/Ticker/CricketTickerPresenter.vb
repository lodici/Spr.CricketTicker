Imports System.Text
#If LOGFEED Then
Imports System.IO
#End If
Imports Spr.CricketTicker.Settings

Public Class CricketTickerPresenter

    Private ReadOnly _log As log4net.ILog =
        log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private ReadOnly _view As ICricketTickerView
    Private ReadOnly _service As ICricketService
    Private ReadOnly _gameId As String
    Private _timer As System.Timers.Timer
    Private _currentScorecard As CricketMatch = Nothing
    Private _errorCount As Integer = 0

    Public Sub New(view As ICricketTickerView, service As ICricketService, gameId As String)
        _view = view
        _service = service
        _gameId = gameId
        StartTimer()
    End Sub

    Private Sub StartTimer()
        _timer = New System.Timers.Timer(30000)
        AddHandler _timer.Elapsed, AddressOf Timer_Elapsed
        _timer.Start()
    End Sub

    Private Sub Timer_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs)
        Try
            _timer.Enabled = False
            UpdateTicker()
            _errorCount = 0
            _timer.Enabled = True
        Catch ex As Exception
            _errorCount += 1
            If _errorCount <= 3 Then
                _timer.Enabled = True
            Else
                _log.Error("Runtime Error", ex)
                _view.UpdateTicker("Unexpected Error! Restart Required.")
            End If
        End Try
    End Sub

    Public Sub UpdateTicker()
        Dim latestScorecard As CricketMatch = _service.GetLatestScore(_gameId)
        LogFeed(_service.XmlFeed, latestScorecard)
        If latestScorecard IsNot Nothing Then
            latestScorecard.ReverseScoreDisplay = UserSettings.ReverseScoreDisplay
            UpdateView(latestScorecard)
            _currentScorecard = latestScorecard
        Else
            If _currentScorecard Is Nothing Or
               ((_currentScorecard IsNot Nothing) AndAlso
                (_currentScorecard.IsMatchFinished = False)) Then
                _view.UpdateTicker("Game Data Not Available")
            End If
        End If
    End Sub

    Public Sub UpdateView(cm As CricketMatch)
        _view.UpdateTicker(cm.TickerCaption)
        _view.UpdateMatchSummary(cm.MatchSummary)
        _view.SetReverseScoreDisplayOption(cm.ReverseScoreDisplay)
    End Sub

    Public Sub SetReverseScoreFormat(p1 As Boolean)
        UserSettings.ReverseScoreDisplay = p1
        _currentScorecard.ReverseScoreDisplay = p1
        UpdateView(_currentScorecard)
    End Sub

    Private Sub LogFeed(xmlFeed As Xml.XmlDocument, cm As CricketMatch)
#If LOGFEED Then
        Dim fileName As String
        If cm IsNot Nothing Then
            fileName = Now.ToString("yyyy-MM-dd_HH-mm-ss") + " " + cm.Id + "=" + cm.MatchStatus + ".xml"
        Else
            fileName = Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xml"
        End If
        Dim logsDirectory As String = ".history/livegames"
        If Not Directory.Exists(logsDirectory) Then
            Directory.CreateDirectory(logsDirectory)
        End If
        xmlFeed.Save(Path.Combine(logsDirectory, fileName))
#End If
    End Sub

End Class
