@TestMatch
Feature: TestMatchXmlParser
##
## This tests that ScorecardParser populates TestMatch 
## correctly with details extracted from the XML feed.
##

Scenario: Ticker at stumps
	Given the sample feed "OneTestSecondInningsStumps"
	And the game I want to monitor has an Id equal to "104900"
	When the xml is parsed
	Then the ticker should display "ENG:208/5 SA:309 D:2 Stumps"

Scenario: Extract Match Summary
	Given the sample feed "NzSaTestFourthDay"
	And the game I want to monitor has an Id equal to "108646"
	When the xml is parsed
	Then the match summary should display
	"""
	South Africa (SA) v New Zealand (NZ)
	2 Test Cricket Series

	2nd Test (11/01/2013 - 15/01/2013)
	St George's Park, Port Elizabeth, South Africa
	
	Day 3: Stumps
	Innings #3
	NZ trail by 247 runs
	"""