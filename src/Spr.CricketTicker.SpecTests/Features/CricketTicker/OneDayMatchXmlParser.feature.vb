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
     NUnit.Framework.DescriptionAttribute("OneDayMatchXmlParser"),  _
     NUnit.Framework.CategoryAttribute("ODI")>  _
    Partial Public Class OneDayMatchXmlParserFeature
        
        Private Shared testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("OneDayMatchXmlParser.feature",1)
#End ExternalSource
        
        <NUnit.Framework.TestFixtureSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "OneDayMatchXmlParser", "", ProgrammingLanguage.VB, New String() {"ODI"})
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
         NUnit.Framework.DescriptionAttribute("Drinks break in the second innings")>  _
        Public Overridable Sub DrinksBreakInTheSecondInnings()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Drinks break in the second innings", CType(Nothing,String()))
#ExternalSource("OneDayMatchXmlParser.feature",8)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",9)
 testRunner.Given("the sample feed ""TwoOdi""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",10)
 testRunner.And("the game I want to monitor has an Id equal to ""104902""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",11)
 testRunner.When("the xml is parsed", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",12)
 testRunner.Then("the ticker should display ""ENG:152/5 SA:287 Drinks""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Rain stoppage ticker")>  _
        Public Overridable Sub RainStoppageTicker()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Rain stoppage ticker", CType(Nothing,String()))
#ExternalSource("OneDayMatchXmlParser.feature",14)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",15)
 testRunner.Given("the sample feed ""OneOdiOneTest""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",16)
 testRunner.And("the game I want to monitor has an Id equal to ""104901""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",17)
 testRunner.When("the xml is parsed", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",18)
 testRunner.Then("the ticker should display ""ENG:0/0 SA:0 Rain Stoppage""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Match summary with non standard series name")>  _
        Public Overridable Sub MatchSummaryWithNonStandardSeriesName()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Match summary with non standard series name", CType(Nothing,String()))
#ExternalSource("OneDayMatchXmlParser.feature",20)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",26)
 testRunner.Given("the sample feed ""WomensOdi""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",27)
 testRunner.And("the game I want to monitor has an Id equal to ""185549""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",28)
 testRunner.When("the xml is parsed", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",29)
 testRunner.Then("the match summary should display", "India Women (INDW) v West Indies Women (WIW)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ICC Womens World Cup"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Match 1 (31"& _ 
                    "/01/2013)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Brabourne Stadium, Mumbai, India"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Play in Progress", CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Ticker South Africa Win")>  _
        Public Overridable Sub TickerSouthAfricaWin()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Ticker South Africa Win", CType(Nothing,String()))
#ExternalSource("OneDayMatchXmlParser.feature",40)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",41)
 testRunner.Given("the sample feed ""OneOdiMatchEnded""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",42)
 testRunner.And("the game I want to monitor has an Id equal to ""104905""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",43)
 testRunner.When("the xml is parsed", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",44)
 testRunner.Then("the ticker should display ""ENG:182 SA:186[W] Match Ended""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Match Summary South Africa Win")>  _
        Public Overridable Sub MatchSummarySouthAfricaWin()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Match Summary South Africa Win", CType(Nothing,String()))
#ExternalSource("OneDayMatchXmlParser.feature",46)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",47)
 testRunner.Given("the sample feed ""OneOdiMatchEnded""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",48)
 testRunner.And("the game I want to monitor has an Id equal to ""104905""", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",49)
 testRunner.When("the xml is parsed", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("OneDayMatchXmlParser.feature",50)
 testRunner.Then("the match summary should display", "England (ENG) v South Africa (SA)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"5 ODI Cricket Series"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"5th ODI (05/09/2012)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)& _ 
                    "Trent Bridge, Nottingham, England"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Match Ended"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SA win", CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
    End Class
End Namespace
'#pragma warning restore
#End Region
