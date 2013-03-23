Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports TechTalk.SpecFlow
Imports NUnit.Framework
Imports Rhino.Mocks
'// In current version of RhinoMocks,  VB.NET has to fully qualify call to Expect.
'// Reason: http://chrismay.org/CommentView,guid,09c435a9-897a-4800-a6cf-ad0e2cd2467c.aspx
'// Can create a work around using the following import alias...

Imports Spr.YahooQueryLanguage.Cricket
Imports Spr.CricketTicker.Library
Imports Spr.CricketTicker.SampleFeeds
Imports Spr.Library.Extensions.String
Imports System.Xml

Namespace Spr.CricketTicker.SpecTests

    <Binding()> _
    Public Class DisplayCricketScoreSteps

        Private _view As ICricketTickerView
        Private _feedProvider As IFeedProvider
        Private _gameId As String
        Private _presenter As CricketTickerPresenter
        Private _cricketMatch As CricketMatch

#Region "Given"

        <TechTalk.SpecFlow.Given("a live One Day match")> _
        Public Sub GivenALiveOneDayMatch()
            _cricketMatch = New OneDayMatch
        End Sub

        <TechTalk.SpecFlow.Given("a live Test match")> _
        Public Sub GivenALiveTestMatch()
            _cricketMatch = New TestMatch
        End Sub

        <TechTalk.SpecFlow.Given("the teams are")> _
        Public Sub GivenTheTeamsAre(ByVal table As Table)
            For i = 0 To table.Rows.Count - 1
                _cricketMatch.Teams(i).Id = CInt(table.Rows(i)("Id"))
                _cricketMatch.Teams(i).Abbreviation = table.Rows(i)("Abbreviation")
                If table.ContainsColumn("Name") Then
                    _cricketMatch.Teams(i).Name = table.Rows(i)("Name")
                End If
            Next
        End Sub

        <TechTalk.SpecFlow.Given("the series title is ""(.*)""")> _
        Public Sub GivenTheSeriesTitleIs(ByVal p0 As String)
            _cricketMatch.SeriesName = p0
        End Sub

        <TechTalk.SpecFlow.Given("this match is the ""(.*)"" in the series")> _
        Public Sub GivenThisMatchIsTheInTheSeries(ByVal p0 As String)
            _cricketMatch.MatchTitle = p0
        End Sub

        <TechTalk.SpecFlow.Given("the venue is ""(.*)""")> _
        Public Sub GivenTheVenueIs(ByVal p0 As String)
            _cricketMatch.Venue = p0
        End Sub

        <TechTalk.SpecFlow.Given("the match starts on ""(.*)""")> _
        Public Sub GivenTheMatchStartsOn(ByVal p0 As String)
            _cricketMatch.StartDate = CDate(p0)
        End Sub

        <TechTalk.SpecFlow.Given("the match ends on ""(.*)""")> _
        Public Sub GivenTheMatchEndsOn(ByVal p0 As String)
            _cricketMatch.EndDate = CDate(p0)
        End Sub

        <TechTalk.SpecFlow.Given("this is day number (.*)")> _
        Public Sub GivenThisIsDayNumber(ByVal p0 As Int32)
            _cricketMatch.DayNumber = p0
        End Sub

        <TechTalk.SpecFlow.Given("the status of the match is ""(.*)""")> _
        Public Sub GivenTheStatusOfTheMatchIs(ByVal p0 As String)
            _cricketMatch.MatchStatus = p0
        End Sub

        <TechTalk.SpecFlow.Given("the match status is")> _
        Public Sub GivenTheMatchStatusIs(ByVal table As Table)
            With _cricketMatch
                .CurrentInningsNumber = CInt(table.Rows(0)("CurrentInnings"))
                .MatchStatus = table.Rows(0)("Status")
                .MatchResult = table.Rows(0)("ResultCode").AsEnum(Of CricketMatch.MatchResultCode)()
                If TypeOf (_cricketMatch) Is TestMatch Then
                    .DayNumber = CInt(table.Rows(0)("Day"))
                End If
            End With
        End Sub

        <TechTalk.SpecFlow.Given("the score should be displayed using the Oz format")> _
        Public Sub GivenTheScoreShouldBeDisplayedUsingTheOzFormat()
            _cricketMatch.ReverseScoreDisplay = True
        End Sub

        <TechTalk.SpecFlow.Given("the innings scores are")> _
        Public Sub GivenTheInningsScoresAre(ByVal table As Table)
            For Each row As TableRow In table.Rows
                Dim innings As Innings = _cricketMatch.Innings(CInt(row("InningsNumber")))
                With innings
                    .SetBattingTeam(CInt(row("BattingTeamId")))
                    .RunsScored = CInt(row("RunsScored"))
                    .WicketsLost = CInt(row("WicketsTaken"))
                    If TypeOf (_cricketMatch) Is OneDayMatch Then
                        .OversBowled = CSng(row("Overs"))
                        .RunRate = CSng(row("Run Rate"))
                        .RequiredRunRate = CSng(row("Req Run Rate"))
                    End If
                End With
            Next
            _cricketMatch.CurrentInningsNumber = table.Rows.Count
        End Sub

        <TechTalk.SpecFlow.Given("the home team is the winner")> _
        Public Sub GivenTheHomeTeamIsTheWinner()
            '_cricketMatch.WinningTeam = _cricketMatch.HomeTeam
            _cricketMatch.SetWinningTeam(_cricketMatch.HomeTeam.Id)
        End Sub

        <TechTalk.SpecFlow.Given("the away team is the winner")> _
        Public Sub GivenTheAwayTeamIsTheWinner()
            '_cricketMatch.WinningTeam = _cricketMatch.AwayTeam
            _cricketMatch.SetWinningTeam(_cricketMatch.AwayTeam.Id)
        End Sub

        <TechTalk.SpecFlow.Given("the winning team Id is (.*)")> _
        Public Sub GivenTheWinningTeamIdIs(ByVal p0 As Int32)
            '_cricketMatch.WinningTeam = _cricketMatch.GetTeamFromTeamId(p0)
            _cricketMatch.SetWinningTeam(p0)
        End Sub

        <TechTalk.SpecFlow.Given("the sample feed ""(.*)""")> _
        Public Sub GivenTheSampleFeed(ByVal p0 As String)
            Dim sampleXml As XmlDocument = SharedCommon.GetEmbeddedSampleXmlDocument(p0)
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetLiveGamesAsXml()).Return(sampleXml)
        End Sub

        <TechTalk.SpecFlow.Given("the game I want to monitor has an Id equal to ""(.*)""")> _
        Public Sub GivenTheGameIWantToMonitorHasAnIdEqualTo(ByVal p0 As String)
            _gameId = p0
        End Sub

        <TechTalk.SpecFlow.Given("an exception occurs when retrieving feed results")> _
        Public Sub GivenAnExceptionOccursWhenRetrievingFeedResults()
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetLiveGamesAsXml()).Throw(New Exception)
        End Sub

#End Region

#Region "When"

        <TechTalk.SpecFlow.When("the xml is parsed")> _
        Public Sub WhenTheXmlIsParsed()
            Dim service As ICricketService = New CricketService(_feedProvider)
            _cricketMatch = service.GetLatestScore(_gameId)
        End Sub

        <TechTalk.SpecFlow.When("the cricket ticker is updated")> _
        Public Sub WhenTheCricketTickerIsUpdated()
            '// nothing to do
        End Sub

        <TechTalk.SpecFlow.When("the ticker is updated")> _
        Public Sub WhenTheTickerIsUpdated()
            _view = MockRepository.GenerateStub(Of ICricketTickerView)()
            Dim service As ICricketService = New CricketService(_feedProvider)
            _presenter = New CricketTickerPresenter(_view, service, _gameId)
            _presenter.UpdateTicker()
        End Sub

        <TechTalk.SpecFlow.When("the ticker is updated the first time")> _
        Public Sub WhenTheTickerIsUpdatedTheFirstTime()
            WhenTheTickerIsUpdated()
            '// Fire the update a second time so that we can verify that
            '// the tooltip was set on the first call only (see ThenTheTooltipShouldBeSetTo)
            _presenter.UpdateTicker()
        End Sub

#End Region

#Region "Then"

        <TechTalk.SpecFlow.Then("the match summary should display")> _
        Public Sub ThenTheMatchSummaryShouldDisplay(ByVal multilineText As String)
            Assert.That(_cricketMatch.MatchSummary, [Is].EqualTo(multilineText))
        End Sub

        <TechTalk.SpecFlow.Then("the ticker should display ""(.*)""")> _
        Public Sub ThenTheTickerShouldDisplay(ByVal p0 As String)
            Assert.That(_cricketMatch.TickerCaption, [Is].EqualTo(p0))
        End Sub

        <TechTalk.SpecFlow.Then("display ""(.*)""")> _
        Public Sub ThenDisplay(ByVal p0 As String)

            Dim actualArgsPerCall As IEnumerable(Of Object()) =
                _view.GetArgumentsForCallsMadeOn(Sub(x) x.UpdateTicker(Nothing))
            Assert.That(actualArgsPerCall.Count, [Is].EqualTo(1))

            _view.AssertWasCalled(Sub(x) x.UpdateTicker(p0))

        End Sub

#End Region

    End Class

End Namespace
