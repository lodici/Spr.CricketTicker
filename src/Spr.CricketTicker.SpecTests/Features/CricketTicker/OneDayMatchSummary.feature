@ODI
Feature: OneDayMatchSummary
	In order to...
	As a...
	I want to...

Scenario: Match yet to begin
	Given a live One Day match
	And the series title is "5 ODI Cricket Series"
	And this match is the "5th ODI" in the series
	And the venue is "Trent Bridge, Nottingham, England"
	And the match starts on "2012-09-05"
	And the match ends on "2012-09-05"
	And the teams are
	| Id | Abbreviation | Name     |
	| 1  | ENG          | England  |
	| 2  | PAK          | Pakistan |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 0          | 0            | 0     | 0        | 0            |
	And the status of the match is "Match yet to begin"
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	England (ENG) v Pakistan (PAK)
	5 ODI Cricket Series

	5th ODI (05/09/2012)
	Trent Bridge, Nottingham, England

	Match yet to begin
	"""

Scenario: Match ended with winner
	Given a live One Day match
	And the series title is "5 ODI Cricket Series"
	And this match is the "5th ODI" in the series
	And the venue is "Trent Bridge, Nottingham, England"
	And the match starts on "2012-09-05"
	And the match ends on "2012-09-05"
	And the teams are
	| Id | Abbreviation | Name     |
	| 1  | ENG          | England  |
	| 2  | PAK          | Pakistan |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 182        | 10           | 45.2  | 4.01     | 0            |
	| 2             | 2             | 186        | 3            | 34.3  | 5.39     | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 2              | 1   | Match Ended | Result  |
	And the winning team Id is 2
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	England (ENG) v Pakistan (PAK)
	5 ODI Cricket Series

	5th ODI (05/09/2012)
	Trent Bridge, Nottingham, England

	Match Ended
	PAK win
	"""

Scenario: Unable to take ten wickets in first innings
	Given a live One Day match
	And the series title is "5 ODI Cricket Series"
	And this match is the "2nd ODI" in the series
	And the venue is "The Rose Bowl, Southampton, England"
	And the match starts on "2012-08-28"
	And the match ends on "2012-08-28"
	And the teams are
	| Id | Abbreviation | Name         |
	| 1  | ENG          | England      |
	| 2  | SA           | South Africa |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 2             | 287        | 5            | 50    | 5.74     | 0            |
	| 2             | 1             | 152        | 5            | 32    | 4.75     | 7.55         |
	And the status of the match is "Drinks"
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	England (ENG) v South Africa (SA)
	5 ODI Cricket Series

	2nd ODI (28/08/2012)
	The Rose Bowl, Southampton, England

	Drinks
	ENG trail by 135 runs after 32 overs.
	Required run rate is 7.6
	"""

Scenario: Seconds innings in progress
	Given a live One Day match
	And the series title is "3 ODI Cricket Series in United Arab Emirates"
	And this match is the "1st ODI" in the series
	And the venue is "Sharjah Cricket Association Stadium, Sharjah, United Arab Emirates"
	And the match starts on "2012-08-28"
	And the match ends on "2012-08-28"
	And the teams are
	| Id | Abbreviation | Name      |
	| 1  | PAK          | Pakistan  |
	| 2  | AUS          | Australia |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 198        | 10           | 45.1  | 4.38     | 0            |
	| 2             | 2             | 21         | 1            | 5     | 4.2      | 3.95         |
	And the status of the match is "Play in Progress"
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	Pakistan (PAK) v Australia (AUS)
	3 ODI Cricket Series in United Arab Emirates

	1st ODI (28/08/2012)
	Sharjah Cricket Association Stadium, Sharjah, United Arab Emirates

	Play in Progress
	AUS trail by 177 runs after 5 overs.
	Required run rate is 4.0
	"""

Scenario: First innings in progress
	Given a live One Day match
	And the series title is "3 T20 Cricket Series in United Arab Emirates"
	And this match is the "3rd T20I" in the series
	And the venue is "Dubai International Cricket Stadium, Dubai, United Arab Emirates"
	And the match starts on "2012-09-10"
	And the match ends on "2012-09-10"
	And the teams are
	| Id | Abbreviation | Name      |
	| 1  | PAK          | Pakistan  |
	| 2  | AUS          | Australia |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 2             | 47         | 0            | 6.4   | 7.0      | 0            |
	And the status of the match is "Play in Progress"
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	Pakistan (PAK) v Australia (AUS)
	3 T20 Cricket Series in United Arab Emirates

	3rd T20I (10/09/2012)
	Dubai International Cricket Stadium, Dubai, United Arab Emirates

	Play in Progress
	"""