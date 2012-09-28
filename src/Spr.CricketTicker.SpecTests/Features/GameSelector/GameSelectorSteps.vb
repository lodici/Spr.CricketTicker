Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Spr.YahooQueryLanguage.Cricket
Imports TechTalk.SpecFlow
Imports NUnit.Framework
Imports Rhino.Mocks
'// In current version of RhinoMocks,  VB.NET has to fully qualify call to Expect.
'// Reason: http://chrismay.org/CommentView,guid,09c435a9-897a-4800-a6cf-ad0e2cd2467c.aspx
'// Can create a work around using the following import alias...

Imports Spr.CricketTicker.Library
Imports Spr.CricketTicker.SampleFeeds
Imports System.Xml

Namespace Spr.CricketTicker.SpecTests

    <Binding()> _
    Public Class GameSelectorSteps

        Private _feedProvider As IFeedProvider
        Private _view As IGameSelectorView
        Private _currentDate As Date = Now
        Private _presenter As GameSelectorPresenter

#Region "Given/Arrange"

        <TechTalk.SpecFlow.Given("an unexpected error with the Live Games feed")> _
        Public Sub GivenAnUnexpectedErrorWithTheLiveGamesFeed()
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetLiveGamesAsXml()).Throw(New Exception)
        End Sub

        <TechTalk.SpecFlow.Given("an unexpected error with the Upcoming Games feed")> _
        Public Sub GivenAnUnexpectedErrorWithTheUpcomingGamesFeed()
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetUpcomingGamesAsXml()).Throw(New Exception)
        End Sub

        <TechTalk.SpecFlow.Given("the sample live games feed ""(.*)""")> _
        Public Sub GivenTheSampleLiveGamesFeed(ByVal p0 As String)
            Dim sampleXml As XmlDocument = SharedCommon.GetEmbeddedSampleXmlDocument(p0)
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetLiveGamesAsXml()).Return(sampleXml)
        End Sub

        <TechTalk.SpecFlow.Given("the sample upcoming games feed ""(.*)""")> _
        Public Sub GivenTheSampleUpcomingGamesFeed(ByVal p0 As String)
            Dim sampleXml As XmlDocument = SharedCommon.GetEmbeddedSampleXmlDocument(p0)
            _feedProvider = MockRepository.GenerateStub(Of IFeedProvider)()
            _feedProvider.Stub(Function(x) x.GetUpcomingGamesAsXml()).Return(sampleXml)
        End Sub

        <TechTalk.SpecFlow.Given("the current date is ""(.*)""")> _
        Public Sub GivenTheCurrentDateIs(ByVal p0 As String)
            _currentDate = CDate(p0)
        End Sub

#End Region

#Region "When/Act"

        <TechTalk.SpecFlow.When("the game selector starts")> _
        Public Sub WhenTheGameSelectorStarts()
            Dim service As New CricketService(_feedProvider)
            _view = MockRepository.GenerateStub(Of IGameSelectorView)()
            _presenter = New GameSelectorPresenter(_view, service, _currentDate)
        End Sub

        <TechTalk.SpecFlow.When("I double click on the upcoming game with Id equal to ""(.*)""")> _
        Public Sub WhenIDoubleClickOnTheUpcomingGameWithIdEqualTo(ByVal p0 As String)
            _presenter.ItemDoubleClicked(p0)
        End Sub

#End Region

#Region "Then/Assert"

        <TechTalk.SpecFlow.Then("display the following additional game information")> _
        Public Sub ThenDisplayTheFollowingAdditionalGameInformation(ByVal multilineText As String)
            _view.AssertWasCalled(Sub(x) x.DisplayUpcomingGameDetails(multilineText))
        End Sub

        <TechTalk.SpecFlow.Then("the game selector should display the following entries")> _
        Public Sub ThenTheGameSelectorShouldDisplayTheFollowingEntries(ByVal table As Table)

            Dim actualArgsPerCall As IEnumerable(Of Object()) =
                _view.GetArgumentsForCallsMadeOn(Sub(x) x.AddSelectorItem(Nothing, Nothing, Nothing))

            Assert.That(actualArgsPerCall.Count, [Is].EqualTo(table.Rows.Count))

            For i As Integer = 0 To table.Rows.Count - 1
                Assert.That(actualArgsPerCall(i)(0), [Is].EqualTo(table.Rows(i)("Game Id")))
                Assert.That(actualArgsPerCall(i)(1), [Is].EqualTo(table.Rows(i)("Game")))
                Assert.That(actualArgsPerCall(i)(2), [Is].EqualTo(table.Rows(i)("Status")))
            Next

        End Sub

        <TechTalk.SpecFlow.Then("the game selector should display nothing")> _
        Public Sub ThenTheGameSelectorShouldDisplayNothing()
            _view.AssertWasNotCalled(Sub(x) x.AddSelectorItem(Nothing, Nothing, Nothing), Sub(y) y.IgnoreArguments())
        End Sub

        <TechTalk.SpecFlow.Then("a cricket ticker should not be launched")> _
        Public Sub ThenACricketTickerShouldNotBeLaunched()
            _view.AssertWasNotCalled(Sub(x) x.CloseView())
        End Sub

        <TechTalk.SpecFlow.Then("a cricket ticker should be launched")> _
        Public Sub ThenACricketTickerShouldBeLaunched()
            _view.AssertWasCalled(Sub(x) x.CloseView())
        End Sub

#End Region

    End Class

End Namespace

