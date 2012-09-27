Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports TechTalk.SpecFlow
Imports TechTalk.SpecFlow.Assist
Imports NUnit.Framework
Imports Rhino.Mocks
'// In current version of RhinoMocks,  VB.NET has to fully qualify call to Expect.
'// Reason: http://chrismay.org/CommentView,guid,09c435a9-897a-4800-a6cf-ad0e2cd2467c.aspx
'// Can create a work around using the following import alias...
Imports DoExpect = Rhino.Mocks.Expect

Imports Spr.CricketTicker.Library
Imports Spr.CricketTicker.SampleFeeds
Imports System.Xml

Namespace Spr.CricketTicker.SpecTests

    <Binding()> _
    Public Class DisplayCricketScoreSteps

        Private _view As ICricketTickerView
        Private _feedProvider As IFeedProvider
        Private _gameId As String
        Private _presenter As CricketTickerPresenter

#Region "Given"

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

        <TechTalk.SpecFlow.When("the ticker is updated")> _
        Public Sub WhenTheTickerIsUpdated()
            _view = MockRepository.GenerateStub(Of ICricketTickerView)()
            Dim service As ICricketService = New YahooQueryLanguage.CricketService(_feedProvider)
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

        <TechTalk.SpecFlow.Then("the tooltip should be set to")> _
        Public Sub ThenTheTooltipShouldBeSetTo(ByVal multilineText As String)

            '// Should only be called once - on the first ticker update.
            Dim actualArgsPerCall As IEnumerable(Of Object()) =
                _view.GetArgumentsForCallsMadeOn(Sub(x) x.SetTooltipText(Nothing))
            Assert.That(actualArgsPerCall.Count, [Is].EqualTo(1))

            _view.AssertWasCalled(Sub(x) x.SetTooltipText(multilineText))

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
