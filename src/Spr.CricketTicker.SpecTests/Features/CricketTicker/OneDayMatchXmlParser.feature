@ODI
Feature: OneDayMatchXmlParser
##
## This tests that ScorecardParser populates OneDayMatch 
## correctly with details extracted from the XML feed.
##

Scenario: Drinks break in the second innings
	Given the sample feed "TwoOdi"
	And the game I want to monitor has an Id equal to "104902"
	When the xml is parsed
	Then the ticker should display "ENG:152/5 SA:287 Drinks"

Scenario: Rain stoppage ticker
	Given the sample feed "OneOdiOneTest"
	And the game I want to monitor has an Id equal to "104901"
	When the xml is parsed
	Then the ticker should display "ENG:0/0 SA:0 Rain Stoppage"

Scenario: Match summary with non standard series name
#
# This is testing the parsing of the <series_name> element. 
# Men's games always seem to consist of three comma separated captions. 
# The women appear to only have two.
#
	Given the sample feed "WomensOdi"
	And the game I want to monitor has an Id equal to "185549"
	When the xml is parsed
	Then the match summary should display
	"""
	India Women (INDW) v West Indies Women (WIW)
	ICC Womens World Cup

	Match 1 (31/01/2013)
	Brabourne Stadium, Mumbai, India

	Play in Progress
	"""

Scenario: Ticker South Africa Win
	Given the sample feed "OneOdiMatchEnded"
	And the game I want to monitor has an Id equal to "104905"
	When the xml is parsed
	Then the ticker should display "ENG:182 SA:186[W] Match Ended"

Scenario: Match Summary South Africa Win
	Given the sample feed "OneOdiMatchEnded"
	And the game I want to monitor has an Id equal to "104905"
	When the xml is parsed
	Then the match summary should display
	"""
	England (ENG) v South Africa (SA)
	5 ODI Cricket Series

	5th ODI (05/09/2012)
	Trent Bridge, Nottingham, England

	Match Ended
	SA win
	"""
