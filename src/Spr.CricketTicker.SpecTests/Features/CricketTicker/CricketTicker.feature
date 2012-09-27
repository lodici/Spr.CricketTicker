Feature: Cricket Ticker
	In order to keep up-to-date on the cricket
	As a cricket fan
	I want to see the current score

Scenario: Tooltip when missing Sub Series value
	Given the sample feed "MissingSubSeries"
	And the game I want to monitor has an Id equal to "184575"
	When the ticker is updated the first time
	Then the tooltip should be set to
	"""
	ICC World Twenty20 Warm-up Matches
	2012

	Match 11
	R.Premadasa Stadium, Colombo, Sri Lanka.
	"""

Scenario: Tooltip for Test Match
	Given the sample feed "OneOdiOneTest"
	And the game I want to monitor has an Id equal to "108608"
	When the ticker is updated the first time
	Then the tooltip should be set to
	"""
	New Zealand in India Test Series
	2 Test Cricket Series, 2012

	1st Test
	Rajiv Gandhi International Stadium, Hyderabad, India.
	"""

Scenario: Tooltip for ODI
	Given the sample feed "OneOdiMatchEnded"
	And the game I want to monitor has an Id equal to "104905"
	When the ticker is updated the first time
	Then the tooltip should be set to
	"""
	South Africa in England ODI Series
	5 ODI Cricket Series, 2012
	
	5th ODI
	Trent Bridge, Nottingham, England.
	"""

Scenario: ODI display format in first innings
	Given the sample feed "OneOdiFirstInnings"
	And the game I want to monitor has an Id equal to "184303"
	When the ticker is updated
	Then display "PAK:0 AUS:47/0 OV:6.4 RR:7.05"

Scenario: ODI display format in first innings and rain stoppage
	Given the sample feed "OneOdiOneTest"
	And the game I want to monitor has an Id equal to "104901"
	When the ticker is updated
	Then display "SA:0 ENG:0/0 Rain Stoppage"

Scenario: ODI display format in second innings and drinks break
	Given the sample feed "TwoOdi"
	And the game I want to monitor has an Id equal to "104902"
	When the ticker is updated
	Then display "SA:287 ENG:152/5 Drinks"

Scenario: ODI display format in second innings and play in progress
	Given the sample feed "TwoOdi"
	And the game I want to monitor has an Id equal to "184298"
	When the ticker is updated
	Then display "PAK:198 AUS:21/1 OV:5.0 RR:4.20/3.95"

Scenario: Test Match display format
	Given the sample feed "OneTestSecondInningsStumps"
	And the game I want to monitor has an Id equal to "104900"
	When the ticker is updated
	Then display "ENG: 208/5 (Stumps)"

Scenario: Feed throws runtime exception
	Given an exception occurs when retrieving feed results
	When the ticker is updated
	Then display "Unexpected Error! Restart Required."
	#And the exceptions details logged to file

Scenario: No live game
	Given the sample feed "NoGames"
	When the ticker is updated
	Then display "Game Data Not Available"