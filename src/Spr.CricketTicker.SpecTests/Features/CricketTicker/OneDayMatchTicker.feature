@ODI
Feature: OneDayMatchTicker
##
## SL:0 NZ:87/2 OV:10.3 RR:8.7 In Progress
##
## What about a draw in T20?
##

Scenario: Display score using Oz format
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 123        | 7            | 15.5  | 6.2      | 16.3         |
	And the match status is
	| CurrentInnings | Status | ResultCode |
	| 2              | Drinks | None       |
	And the score should be displayed using the Oz format
	When the cricket ticker is updated
	Then the ticker should display "ENG:188 SA:7/123 Drinks"

Scenario: Drinks
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 123        | 7            | 15.5  | 6.2      | 16.3         |
	And the match status is
	| CurrentInnings | Status | ResultCode |
	| 2              | Drinks | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:188 SA:123/7 Drinks"

Scenario: Match not started
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 0          | 0            | 0.0   | 0.0      | 0.0          |
	And the match status is
	| CurrentInnings | Status             | ResultCode |
	| 1              | Match yet to begin | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0/0 SA:0 Match yet to begin"

Scenario: Home team batting first
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 15         | 1            | 4.5   | 2.2      | 0.0          |
	And the match status is
	| CurrentInnings | Status           | ResultCode |
	| 1              | Play in Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:15/1 SA:0 Ov:4.5 Rt:2.2"

Scenario: Away team batting first
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 2             | 15         | 1            | 4.5   | 2.2      | 0.0          |
	And the match status is
	| CurrentInnings | Status           | ResultCode |
	| 1              | Play in Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0 SA:15/1 Ov:4.5 Rt:2.2"

Scenario: Innings Break
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	And the match status is
	| CurrentInnings | Status        | ResultCode |
	| 1              | Innings Break | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:188 SA:0 Innings Break"

Scenario: Start of Away Team innings
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 0          | 0            | 0     | 0        | 9.4          |
	And the match status is
	| CurrentInnings | Status           | ResultCode |
	| 2              | Play in Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:188 SA:0/0 Ov:0.0 Rt:0.0/9.4"

Scenario: Away Team batting second
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 123        | 7            | 15.5  | 6.2      | 16.3         |
	And the match status is
	| CurrentInnings | Status           | ResultCode |
	| 2              | Play in Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:188 SA:123/7 Ov:15.5 Rt:6.2/16.3"

Scenario: Home Team batting second
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 2             | 188        | 8            | 20    | 9.4      | 0            |
	| 2             | 1             | 123        | 7            | 15.5  | 6.2      | 16.3         |
	And the match status is
	| CurrentInnings | Status           | ResultCode |
	| 2              | Play in Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:123/7 SA:188 Ov:15.5 Rt:6.2/16.3"

Scenario: Home team won
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           | 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 167        | 10           | 19.4  | 0        | 0            |
	And the match status is
	| CurrentInnings | Status      | ResultCode |
	| 2              | Match Ended | Result     |
	And the home team is the winner
	When the cricket ticker is updated
	Then the ticker should display "ENG:188[W] SA:167 Match Ended"

Scenario: Away team won
	Given a live One Day match
	And the teams are
	| Id | Abbreviation |
	| 2  | SA           |
	| 1  | ENG          |	 
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken | Overs | Run Rate | Req Run Rate |
	| 1             | 1             | 188        | 8            | 20    | 9.4      | 0.0          |
	| 2             | 2             | 167        | 10           | 19.4  | 0        | 0            |
	And the match status is
	| CurrentInnings | Status      | ResultCode |
	| 2              | Match Ended | Result     |
	And the away team is the winner
	When the cricket ticker is updated
	Then the ticker should display "SA:167 ENG:188[W] Match Ended"