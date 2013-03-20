Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports TechTalk.SpecFlow
Imports NUnit.Framework

Imports Spr.YahooQueryLanguage.Cricket

Namespace Spr.CricketTicker.SpecTests

    ' For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

    <Binding()> _
    Public Class CricketMatchPropertiesSteps

        Private _xmlRawValue As String
        Private _parsedValue As String

        <TechTalk.SpecFlow.Given("the series name xml element is ""(.*)""")> _
        Public Sub GivenTheSeriesNameXmlElementIs(ByVal p0 As String)
            _xmlRawValue = p0
        End Sub

        <TechTalk.SpecFlow.When("the series name is parsed")> _
        Public Sub WhenTheSeriesNameIsParsed()
            Dim parser As New ScorecardSummaryParser
            _parsedValue = parser.ParseSeriesName(_xmlRawValue)
        End Sub

        <TechTalk.SpecFlow.Then("the resulting string should be ""(.*)""")> _
        Public Sub ThenTheResultingStringShouldBe(ByVal p0 As String)
            Assert.That(_parsedValue, [Is].EqualTo(p0))
        End Sub

    End Class

End Namespace
