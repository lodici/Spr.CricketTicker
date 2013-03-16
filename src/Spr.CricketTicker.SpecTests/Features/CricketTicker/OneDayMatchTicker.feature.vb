﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by SpecFlow (http://www.specflow.org/).
'     SpecFlow Version:1.9.0.77
'     SpecFlow Generator Version:1.9.0.0
'     Runtime Version:4.0.30319.296
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
#Region "Designer generated code"
'#pragma warning disable
Imports TechTalk.SpecFlow

Namespace Spr.CricketTicker.SpecTests.Features.CricketTicker
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77"),  _
     System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     NUnit.Framework.TestFixtureAttribute(),  _
     NUnit.Framework.DescriptionAttribute("OneDayMatchTicker"),  _
     NUnit.Framework.CategoryAttribute("ODI")>  _
    Partial Public Class OneDayMatchTickerFeature
        
        Private Shared testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("OneDayMatchTicker.feature",1)
#End ExternalSource
        
        <NUnit.Framework.TestFixtureSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "OneDayMatchTicker", "", ProgrammingLanguage.VB, New String() {"ODI"})
            testRunner.OnFeatureStart(featureInfo)
        End Sub
        
        <NUnit.Framework.TestFixtureTearDownAttribute()>  _
        Public Overridable Sub FeatureTearDown()
            testRunner.OnFeatureEnd
            testRunner = Nothing
        End Sub
        
        <NUnit.Framework.SetUpAttribute()>  _
        Public Overridable Sub TestInitialize()
        End Sub
        
        <NUnit.Framework.TearDownAttribute()>  _
        Public Overridable Sub ScenarioTearDown()
            testRunner.OnScenarioEnd
        End Sub
        
        Public Overridable Sub ScenarioSetup(ByVal scenarioInfo As TechTalk.SpecFlow.ScenarioInfo)
            testRunner.OnScenarioStart(scenarioInfo)
        End Sub
        
        Public Overridable Sub ScenarioCleanup()
            testRunner.CollectScenarioErrors
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Drinks")>  _
        Public Overridable Sub Drinks()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Drinks", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",9)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",10)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table1 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table1.AddRow(New String() {"1", "ENG"})
            table1.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",11)
 testRunner.And("the teams are", CType(Nothing,String), table1, "And ")
#End ExternalSource
            Dim table2 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table2.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
            table2.AddRow(New String() {"2", "2", "123", "7", "15.5", "6.2", "16.3"})
#ExternalSource("OneDayMatchTicker.feature",15)
 testRunner.And("the innings scores are", CType(Nothing,String), table2, "And ")
#End ExternalSource
            Dim table3 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table3.AddRow(New String() {"2", "Drinks", "None"})
#ExternalSource("OneDayMatchTicker.feature",19)
 testRunner.And("the match status is", CType(Nothing,String), table3, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",22)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",23)
 testRunner.Then("the ticker should display ""ENG:188 SA:123/7 Drinks""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Match not started")>  _
        Public Overridable Sub MatchNotStarted()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Match not started", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",25)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",26)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table4 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table4.AddRow(New String() {"1", "ENG"})
            table4.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",27)
 testRunner.And("the teams are", CType(Nothing,String), table4, "And ")
#End ExternalSource
            Dim table5 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table5.AddRow(New String() {"1", "1", "0", "0", "0.0", "0.0", "0.0"})
#ExternalSource("OneDayMatchTicker.feature",31)
 testRunner.And("the innings scores are", CType(Nothing,String), table5, "And ")
#End ExternalSource
            Dim table6 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table6.AddRow(New String() {"1", "Match yet to begin", "None"})
#ExternalSource("OneDayMatchTicker.feature",34)
 testRunner.And("the match status is", CType(Nothing,String), table6, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",37)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",38)
 testRunner.Then("the ticker should display ""ENG:0/0 SA:0 Match yet to begin""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Home team batting first")>  _
        Public Overridable Sub HomeTeamBattingFirst()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Home team batting first", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",40)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",41)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table7 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table7.AddRow(New String() {"1", "ENG"})
            table7.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",42)
 testRunner.And("the teams are", CType(Nothing,String), table7, "And ")
#End ExternalSource
            Dim table8 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table8.AddRow(New String() {"1", "1", "15", "1", "4.5", "2.2", "0.0"})
#ExternalSource("OneDayMatchTicker.feature",46)
 testRunner.And("the innings scores are", CType(Nothing,String), table8, "And ")
#End ExternalSource
            Dim table9 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table9.AddRow(New String() {"1", "Play in Progress", "None"})
#ExternalSource("OneDayMatchTicker.feature",49)
 testRunner.And("the match status is", CType(Nothing,String), table9, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",52)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",53)
 testRunner.Then("the ticker should display ""ENG:15/1 SA:0 Ov:4.5 Rt:2.2""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Away team batting first")>  _
        Public Overridable Sub AwayTeamBattingFirst()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Away team batting first", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",55)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",56)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table10 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table10.AddRow(New String() {"1", "ENG"})
            table10.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",57)
 testRunner.And("the teams are", CType(Nothing,String), table10, "And ")
#End ExternalSource
            Dim table11 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table11.AddRow(New String() {"1", "2", "15", "1", "4.5", "2.2", "0.0"})
#ExternalSource("OneDayMatchTicker.feature",61)
 testRunner.And("the innings scores are", CType(Nothing,String), table11, "And ")
#End ExternalSource
            Dim table12 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table12.AddRow(New String() {"1", "Play in Progress", "None"})
#ExternalSource("OneDayMatchTicker.feature",64)
 testRunner.And("the match status is", CType(Nothing,String), table12, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",67)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",68)
 testRunner.Then("the ticker should display ""ENG:0 SA:15/1 Ov:4.5 Rt:2.2""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Innings Break")>  _
        Public Overridable Sub InningsBreak()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Innings Break", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",70)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",71)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table13 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table13.AddRow(New String() {"1", "ENG"})
            table13.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",72)
 testRunner.And("the teams are", CType(Nothing,String), table13, "And ")
#End ExternalSource
            Dim table14 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table14.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
#ExternalSource("OneDayMatchTicker.feature",76)
 testRunner.And("the innings scores are", CType(Nothing,String), table14, "And ")
#End ExternalSource
            Dim table15 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table15.AddRow(New String() {"1", "Innings Break", "None"})
#ExternalSource("OneDayMatchTicker.feature",79)
 testRunner.And("the match status is", CType(Nothing,String), table15, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",82)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",83)
 testRunner.Then("the ticker should display ""ENG:188 SA:0 Innings Break""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Start of Away Team innings")>  _
        Public Overridable Sub StartOfAwayTeamInnings()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Start of Away Team innings", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",85)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",86)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table16 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table16.AddRow(New String() {"1", "ENG"})
            table16.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",87)
 testRunner.And("the teams are", CType(Nothing,String), table16, "And ")
#End ExternalSource
            Dim table17 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table17.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
            table17.AddRow(New String() {"2", "2", "0", "0", "0", "0", "9.4"})
#ExternalSource("OneDayMatchTicker.feature",91)
 testRunner.And("the innings scores are", CType(Nothing,String), table17, "And ")
#End ExternalSource
            Dim table18 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table18.AddRow(New String() {"2", "Play in Progress", "None"})
#ExternalSource("OneDayMatchTicker.feature",95)
 testRunner.And("the match status is", CType(Nothing,String), table18, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",98)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",99)
 testRunner.Then("the ticker should display ""ENG:188 SA:0/0 Ov:0.0 Rt:0.0/9.4""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Away Team batting second")>  _
        Public Overridable Sub AwayTeamBattingSecond()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Away Team batting second", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",101)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",102)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table19 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table19.AddRow(New String() {"1", "ENG"})
            table19.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",103)
 testRunner.And("the teams are", CType(Nothing,String), table19, "And ")
#End ExternalSource
            Dim table20 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table20.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
            table20.AddRow(New String() {"2", "2", "123", "7", "15.5", "6.2", "16.3"})
#ExternalSource("OneDayMatchTicker.feature",107)
 testRunner.And("the innings scores are", CType(Nothing,String), table20, "And ")
#End ExternalSource
            Dim table21 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table21.AddRow(New String() {"2", "Play in Progress", "None"})
#ExternalSource("OneDayMatchTicker.feature",111)
 testRunner.And("the match status is", CType(Nothing,String), table21, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",114)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",115)
 testRunner.Then("the ticker should display ""ENG:188 SA:123/7 Ov:15.5 Rt:6.2/16.3""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Home Team batting second")>  _
        Public Overridable Sub HomeTeamBattingSecond()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Home Team batting second", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",117)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",118)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table22 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table22.AddRow(New String() {"1", "ENG"})
            table22.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",119)
 testRunner.And("the teams are", CType(Nothing,String), table22, "And ")
#End ExternalSource
            Dim table23 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table23.AddRow(New String() {"1", "2", "188", "8", "20", "9.4", "0"})
            table23.AddRow(New String() {"2", "1", "123", "7", "15.5", "6.2", "16.3"})
#ExternalSource("OneDayMatchTicker.feature",123)
 testRunner.And("the innings scores are", CType(Nothing,String), table23, "And ")
#End ExternalSource
            Dim table24 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table24.AddRow(New String() {"2", "Play in Progress", "None"})
#ExternalSource("OneDayMatchTicker.feature",127)
 testRunner.And("the match status is", CType(Nothing,String), table24, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",130)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",131)
 testRunner.Then("the ticker should display ""ENG:123/7 SA:188 Ov:15.5 Rt:6.2/16.3""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Home team won")>  _
        Public Overridable Sub HomeTeamWon()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Home team won", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",133)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",134)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table25 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table25.AddRow(New String() {"1", "ENG"})
            table25.AddRow(New String() {"2", "SA"})
#ExternalSource("OneDayMatchTicker.feature",135)
 testRunner.And("the teams are", CType(Nothing,String), table25, "And ")
#End ExternalSource
            Dim table26 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table26.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
            table26.AddRow(New String() {"2", "2", "167", "10", "19.4", "0", "0"})
#ExternalSource("OneDayMatchTicker.feature",139)
 testRunner.And("the innings scores are", CType(Nothing,String), table26, "And ")
#End ExternalSource
            Dim table27 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table27.AddRow(New String() {"2", "Match Ended", "Result"})
#ExternalSource("OneDayMatchTicker.feature",143)
 testRunner.And("the match status is", CType(Nothing,String), table27, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",146)
 testRunner.And("the home team is the winner", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",147)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",148)
 testRunner.Then("the ticker should display ""ENG:188[W] SA:167 Match Ended""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Away team won")>  _
        Public Overridable Sub AwayTeamWon()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Away team won", CType(Nothing,String()))
#ExternalSource("OneDayMatchTicker.feature",150)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",151)
 testRunner.Given("a live One Day match", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
            Dim table28 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"Id", "Abbreviation"})
            table28.AddRow(New String() {"2", "SA"})
            table28.AddRow(New String() {"1", "ENG"})
#ExternalSource("OneDayMatchTicker.feature",152)
 testRunner.And("the teams are", CType(Nothing,String), table28, "And ")
#End ExternalSource
            Dim table29 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"InningsNumber", "BattingTeamId", "RunsScored", "WicketsTaken", "Overs", "Run Rate", "Req Run Rate"})
            table29.AddRow(New String() {"1", "1", "188", "8", "20", "9.4", "0.0"})
            table29.AddRow(New String() {"2", "2", "167", "10", "19.4", "0", "0"})
#ExternalSource("OneDayMatchTicker.feature",156)
 testRunner.And("the innings scores are", CType(Nothing,String), table29, "And ")
#End ExternalSource
            Dim table30 As TechTalk.SpecFlow.Table = New TechTalk.SpecFlow.Table(New String() {"CurrentInnings", "Status", "ResultCode"})
            table30.AddRow(New String() {"2", "Match Ended", "Result"})
#ExternalSource("OneDayMatchTicker.feature",160)
 testRunner.And("the match status is", CType(Nothing,String), table30, "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",163)
 testRunner.And("the away team is the winner", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",164)
 testRunner.When("the cricket ticker is updated", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchTicker.feature",165)
 testRunner.Then("the ticker should display ""SA:167 ENG:188[W] Match Ended""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
    End Class
End Namespace
'#pragma warning restore
#End Region