NOTE! Some of this stuff could go in the project WIKI (eg. Background, tech details, etc).

BACKGROUND
==========
I am using this project as a kind of test center for trying out various techniques and NET-related technologies -  
- test driven development (TDD)  
- - NUnit  
- - SpecFlow  
- using WiX to generate the required MSI package.  
- - How to remove files added to installation directory post install during uninstall.  
- - Upgrade existing installation. Avoid creating multiple entries in Add/Remove programs.  
- - Activate wizard dialogs.  
- - - Customize bitmaps  
- - - Customize licence details.  
- - Pre-requisite check (in this case, verify NET Framework 4 is already installed).  
- - Create own product group in start menu.  
- use of Git as repository of choice  
- - experience of typical workflow  
- - - GitFlow  
- - - GitHub  
- use of NuGet  
- - No-commit strategy.  
- - local server  
- first open source project  
- - sourceforge  
- - github  
- Continuous Integration  
- - TeamCity  

SOURCE CODE
===========

SPR development environment:  
- VB.NET   
- Visual Studio 2010  
- Windows 7 (64-Bit).  
Tools:  
- {{url|Nuget}} packages:  
- - automatic install using {{url|Nuget no-commit strategy}}  
- - - requires initial build to get packages from Nuget servers and fix missing reference errors.  
- - {{url|log4net}}  
- - {{url|NUnit}}  
- - {{url|RhinoMocks}}  
- - {{url|SpecFlow}}  
- - - See Spr.CricketTicker.SpecTests  
- - {{url|Wix}}  
- - Unfortunately, no official Nuget package.  
- - - I use a own home-baked Nuget package (SPR-WiX) installed on a local Nuget server.  
- - This means that to successfully compile Spr.CricketTicker.Wix  
- - - install WiX from {{url|here}}  
- - - set the required references manually.  
- - - [optional] host your own NuGet package locally.  
- - By default, Spr.CricketTicker.Wix is unloaded from the solution  
- - {{url|Git}} & {{url|GitHub}}  

Where to start  
- Download and install the {{url|NUnit Client}}  
- Build Spr.CricketTicker solution.  
- Run NUnit client and point to SprCricketTicker.SpecTests  
- Run tests (all should be green!)  
- For more details about a specific test  
- - Double click test.  
- - Open Text Output tab.  
- - - Describes really clearly the steps involved for that particular test.  
- Open Spr.CricketTicker.SpecTests.  
- - See feature files for list of scenarios.  
- - Within each scenario there will be a number of steps.  
- - - Drill down on a step to open the associated test code.  





WORKFLOW
========
From the outset I have attempted to use SpecFlow feature scripts to drive a test driven development approach. If you want to start anywhere, then the feature files in Spr.CricketTicker.SpecTests are the place to start. These describe the main features of the application which in turn define various tests which in turn lead you to the actual core source code. Running NUnit against the Spr.CricketTicker.SpecTests assembly and you automatically generate clear and concise documentation. For example -

***** 
Given the sample live games feed "OneOdiOneTest"
-> done: GameSelectorSteps.GivenTheSampleLiveGamesFeed("OneOdiOneTest") (0.5s)
When the game selector starts
-> done: GameSelectorSteps.WhenTheGameSelectorStarts() (0.2s)
Then the game selector should display the following entries
  --- table step argument ---
  | Game                            | Status           | Game Id |
  | India v New Zealand, 1st Test   | Play In Progress | 108608  |
  | England v South Africa, 1st ODI | Rain Stoppage    | 104901  |
-> done: GameSelectorSteps.ThenTheGameSelectorShouldDisplayTheFollowingEntries(<table>) (0.0s)
When I double click on the upcoming game with Id equal to "108608"
-> done: GameSelectorSteps.WhenIDoubleClickOnTheUpcomingGameWithIdEqualTo("108608") (0.0s)
Then a cricket ticker should be launched
-> done: GameSelectorSteps.ThenACricketTickerShouldBeLaunched() (0.0s)


I want to know how to change it...
----------------------------------




primarily to get experience 

This is the first complete project I have created using a primarily test driven (TDD) approach.






##Development Tools:##
- [Nuget](http://nuget.codeplex.com/) packages:
	- automatic install using [Nuget no-commit strategy](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages).
		- requires initial build to get packages from Nuget servers and fix missing reference errors.
	- [log4net]()
	- [NUnit]()
	- [RhinoMocks]()
	- [SpecFlow]()
		- See Spr.CricketTicker.SpecTests
	- [WiX]()
		- Unfortunately, no official Nuget package.
		- I use a own home-baked Nuget package (SPR-WiX) installed on a local Nuget server.
		- This means that to successfully compile Spr.CricketTicker.Wix
			- install WiX from {{url|here}}
			- set the required references manually.
			- [optional] host your own NuGet package locally.
		- By default, Spr.CricketTicker.Wix is unloaded from the solution
- [Git](), [GitFlow]() and [GitHub]()