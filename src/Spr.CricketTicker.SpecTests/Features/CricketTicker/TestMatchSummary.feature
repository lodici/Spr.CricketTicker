@TestMatch
Feature: TestMatchSummary

Scenario: Match yet to begin
	Given a live Test match
	And the series title is "3 Test Cricket Series"
	And this match is the "2nd Test" in the series
	And the venue is "Newlands, Cape Town, South Africa"
	And the match starts on "2013-02-14"
	And the match ends on "2013-02-18"
	And the teams are
	| Id | Abbreviation | Name         |
	| 1  | SA           | South Africa |
	| 2  | PAK          | Pakistan     |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status             | ResultCode |
	| 1              | 1   | Match yet to begin | None       |
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	South Africa (SA) v Pakistan (PAK)
	3 Test Cricket Series

	2nd Test (14/02/2013 - 18/02/2013)
	Newlands, Cape Town, South Africa
	
	Day 1: Match yet to begin
	"""

Scenario: Match abandoned
	Given a live Test match
	And the series title is "2 Test Cricket Series"
	And this match is the "2nd Test" in the series
	And the venue is "St George's Park, Port Elizabeth, South Africa"
	And the match starts on "2013-01-11"
	And the match ends on "2013-01-15"
	And the teams are
	| Id | Abbreviation | Name         |
	| 1  | SA           | South Africa |
	| 2  | NZ           | New Zealand  |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 525        | 8            |
	| 2             | 2             | 121        | 10           |
	| 3             | 2             | 257        | 10           |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 3              | 4   | Match Ended | Abandoned  |
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	South Africa (SA) v New Zealand (NZ)
	2 Test Cricket Series

	2nd Test (11/01/2013 - 15/01/2013)
	St George's Park, Port Elizabeth, South Africa
	
	Day 4: Match Abandoned
	"""

Scenario: We have a winner
	Given a live Test match
	And the series title is "2 Test Cricket Series"
	And this match is the "2nd Test" in the series
	And the venue is "St George's Park, Port Elizabeth, South Africa"
	And the match starts on "2013-01-11"
	And the match ends on "2013-01-15"
	And the teams are
	| Id | Abbreviation | Name         |
	| 1  | SA           | South Africa |
	| 2  | NZ           | New Zealand  |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 525        | 8            |
	| 2             | 2             | 121        | 10           |
	| 3             | 2             | 257        | 10           |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 3              | 4   | Match Ended | Result     |
	And the winning team Id is 1
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	South Africa (SA) v New Zealand (NZ)
	2 Test Cricket Series

	2nd Test (11/01/2013 - 15/01/2013)
	St George's Park, Port Elizabeth, South Africa

	Day 4: Match Ended
	SA win
	"""

Scenario: Start of first innings no score
	Given a live Test match
	And the series title is "2 Test Cricket Series"
	And this match is the "1st Test" in the series
	And the venue is "Rajiv Gandhi International Stadium, Hyderabad, India"
	And the match starts on "2012-08-23"
	And the match ends on "2012-08-27"
	And the teams are
	| Id | Abbreviation | Name        |
	| 1  | IND          | India       |
	| 2  | NZ           | New Zealand |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 1              | 1   | Not Started | None       |
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	India (IND) v New Zealand (NZ)
	2 Test Cricket Series

	1st Test (23/08/2012 - 27/08/2012)
	Rajiv Gandhi International Stadium, Hyderabad, India

	Day 1: Not Started
	Innings #1
	"""

Scenario: In progress on day two
	Given a live Test match
	And the series title is "2 Test Cricket Series"
	And this match is the "1st Test" in the series
	And the venue is "Rajiv Gandhi International Stadium, Hyderabad, India"
	And the match starts on "2012-08-23"
	And the match ends on "2012-08-27"
	And the teams are
	| Id | Abbreviation | Name        |
	| 1  | IND          | India       |
	| 2  | NZ           | New Zealand |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 438        | 10           |
	| 2             | 2             | 35         | 2            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 2              | 2   | In Progress | None       |
	When the cricket ticker is updated
	Then the match summary should display 
	"""
	India (IND) v New Zealand (NZ)
	2 Test Cricket Series

	1st Test (23/08/2012 - 27/08/2012)
	Rajiv Gandhi International Stadium, Hyderabad, India

	Day 2: In Progress
	Innings #2
	NZ trail by 403 runs
	"""

Scenario: Stumps on day three
	Given a live Test match
	And the series title is "2 Test Cricket Series"
	And this match is the "2nd Test" in the series
	And the venue is "St George's Park, Port Elizabeth, South Africa"
	And the match starts on "2013-01-11"
	And the match ends on "2013-01-15"
	And the teams are
	| Id | Abbreviation | Name         |
	| 1  | SA           | South Africa |
	| 2  | NZ           | New Zealand  |
	And the innings scores are
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 1             | 525        | 8            |
	| 2             | 2             | 121        | 10           |
	| 3             | 2             | 157        | 4            |
	And the match status is
	| CurrentInnings | Day | Status | ResultCode |
	| 3              | 3   | Stumps | None       |
	When the cricket ticker is updated
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