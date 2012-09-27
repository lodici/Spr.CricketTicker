Feature: Game Selector
	In order to keep up-to-date on the cricket
	As a cricket fan
	I want to select from a list of available games

Scenario: Double clicking upcoming game with no sub title
	Given the sample upcoming games feed "UpcomingIncludingThreeWorldCup"
	And the current date is "2012-09-15"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                           | Status | Game Id |
	| Bangladesh v Zimbabwe, Match 5 | 05:00  | 184572   |
	When I double click on the upcoming game with Id equal to "184572"
	Then display the following additional game information
	"""
	ICC World Twenty20 Warm-up Matches
	2012

	Match 5
	Colts Cricket Club Ground, Colombo
	"""

Scenario: Double clicking upcoming game shows more details
	Given the sample upcoming games feed "UpcomingFourOdiOneTest"
	And the current date is "2012-08-30"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                            | Status           | Game Id |
	| India v New Zealand, 2nd Test   | 31/08/2012 05:00 | 108609   |
	| England v South Africa, 3rd ODI | 31/08/2012 13:00 | 104903   |
	| Pakistan v Australia, 2nd ODI   | 31/08/2012 15:00 | 184299   |
	When I double click on the upcoming game with Id equal to "108609"
	Then display the following additional game information
	"""
	New Zealand in India Test Series
	2 Test Cricket Series, 2012

	2nd Test
	M.Chinnaswamy Stadium, Bengaluru
	"""
	When I double click on the upcoming game with Id equal to "184299"
	Then display the following additional game information
	"""
	Australia vs Pakistan ODI Series
	3 ODI Cricket Series in United Arab Emirates, 2012

	2nd ODI
	Sheikh Zayed Stadium, Abu Dhabi
	"""

Scenario: Double click live game should launch ticker
	Given the sample live games feed "OneOdiOneTest"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                            | Status           | Game Id |
	| India v New Zealand, 1st Test   | Play In Progress | 108608  |
	| England v South Africa, 1st ODI | Rain Stoppage    | 104901  |
	When I double click on the upcoming game with Id equal to "108608"
	Then a cricket ticker should be launched

Scenario: Runtime error with Upcoming Games feed
	Given an unexpected error with the Upcoming Games feed
	When the game selector starts
	Then the game selector should display the following entries
	| Game                                             | Status | Game Id |
	| Unexpected problem with the Upcoming Games feed! | FAILED |         |

Scenario: Runtime error with Live Games feed
	Given an unexpected error with the Live Games feed
	When the game selector starts
	Then the game selector should display the following entries
	| Game                                         | Status | Game Id |
	| Unexpected problem with the Live Games feed! | FAILED |         |

Scenario: One or more live games available
	Given the sample live games feed "OneOdiOneTest"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                            | Status           | Game Id |
	| India v New Zealand, 1st Test   | Play In Progress | 108608  |
	| England v South Africa, 1st ODI | Rain Stoppage    | 104901  |

Scenario: No live games
	Given the sample live games feed "NoGames"
	When the game selector starts
	Then the game selector should display nothing

Scenario: No upcoming games
	Given the sample upcoming games feed "UpcomingFourOdiOneTest"
	And the current date is "2013-08-01"
	When the game selector starts
	Then the game selector should display nothing

Scenario: Upcoming games start after current date
	Given the sample upcoming games feed "UpcomingFourOdiOneTest"
	And the current date is "2012-08-30"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                            | Status           | Game Id |
	| India v New Zealand, 2nd Test   | 31/08/2012 05:00 | 108609  |
	| England v South Africa, 3rd ODI | 31/08/2012 13:00 | 104903  |
	| Pakistan v Australia, 2nd ODI   | 31/08/2012 15:00 | 184299  |

Scenario: Upcoming games start on current date
	Given the sample upcoming games feed "UpcomingFourOdiOneTest"
	And the current date is "2012-08-31"
	When the game selector starts
	Then the game selector should display the following entries
	| Game                            | Status | Game Id |
	| India v New Zealand, 2nd Test   | 05:00  | 108609  |
	| England v South Africa, 3rd ODI | 13:00  | 104903  |
	| Pakistan v Australia, 2nd ODI   | 15:00  | 184299  |