Feature: Misc Ticker
	In order to keep up-to-date on the cricket
	As a cricket fan
	I want to see the current score

#Scenario: Feed throws runtime exception
#	Given an exception occurs when retrieving feed results
#	When the ticker is updated
#	Then display "Unexpected Error! Restart Required."
#	#And the exceptions details logged to file

Scenario: No live game
	Given the sample feed "NoGames"
	When the ticker is updated
	Then display "Game Data Not Available"