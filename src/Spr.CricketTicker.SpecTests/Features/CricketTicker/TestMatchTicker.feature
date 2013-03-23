@TestMatch
Feature: TestMatchTicker

Scenario: Display score using Oz format
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 208        | 5            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 2              | 2   | In Progress | None       |
	And the score should be displayed using the Oz format
	When the cricket ticker is updated
	Then the ticker should display "ENG:5/208 SA:309 D:2 In Progress"

Scenario: Match yet to begin
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status             | ResultCode |
	| 1              | 1   | Match yet to begin | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0 SA:0/0 Match yet to begin"

Scenario: Day one match in progress
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 132        | 3            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 1              | 1   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0 SA:132/3 D:1 In Progress"

Scenario: Day two innings break
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	And the match status is
	| CurrentInnings | Day | Status        | ResultCode |
	| 1              | 2   | Innings Break | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0 SA:309 D:2 Innings Break"

Scenario: Day two seconds innings start
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 2              | 2   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:0/0 SA:309 D:2 In Progress"

Scenario: Day two seconds innings in progress
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 208        | 5            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 2              | 2   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:208/5 SA:309 D:2 In Progress"

Scenario: Day two seconds innings stumps
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 312        | 8            |
	And the match status is
	| CurrentInnings | Day | Status | ResultCode |
	| 2              | 2   | Stumps | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:312/8 SA:309 D:2 Stumps"

Scenario: Day three seconds innings innings break
	Given a live Test match
		And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	And the match status is
	| CurrentInnings | Day | Status        | ResultCode |
	| 2              | 3   | Innings Break | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346 SA:309 D:3 Innings Break"

Scenario: Day three third innings start
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 3              | 3   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346 SA:309+0/0 D:3 In Progress"

Scenario: Day three third innings in progress
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 54         | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 3              | 3   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346 SA:309+54/0 D:3 In Progress"

Scenario: Day three third innings innings break
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 157        | 10           |
	And the match status is
	| CurrentInnings | Day | Status        | ResultCode |
	| 3              | 3   | Innings Break | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346 SA:309+157 D:3 Innings Break"

Scenario: Day three fourth innings start
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 157        | 10           |
	| 4             | 1             | 0          | 0            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 4              | 3   | In Progress | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346+0/0 SA:309+157 D:3 In Progress"

Scenario: Day three fourth innings stumps
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 157        | 10           |
	| 4             | 1             | 100        | 4            |
	And the match status is
	| CurrentInnings | Day | Status | ResultCode |
	| 4              | 3   | Stumps | None       |
	When the cricket ticker is updated
	Then the ticker should display "ENG:346+100/4 SA:309+157 D:3 Stumps"

Scenario: Day four fourth innings match finished
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | ENG          |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 309        | 10           |
	| 2             | 1             | 346        | 10           |
	| 3             | 2             | 157        | 10           |
	| 4             | 1             | 121        | 5            |
	And the match status is
	| CurrentInnings | Day | Status      | ResultCode |
	| 4              | 4   | Match Ended | Result     |
	And the winning team Id is 1
	When the cricket ticker is updated
	Then the ticker should display "ENG:346+121[W] SA:309+157 D:4 Match Ended"

Scenario: Team asked to follow on
	Given a live Test match
	And the teams are
	| Id | Abbreviation |
	| 1  | NZ           |
	| 2  | SA           |
	And the innings scores are 
	| InningsNumber | BattingTeamId | RunsScored | WicketsTaken |
	| 1             | 2             | 525        | 10           |
	| 2             | 1             | 121        | 10           |
	| 3             | 1             | 157        | 4            |
	And the match status is
	| CurrentInnings | Day | Status | ResultCode |
	| 3              | 3   | Stumps | None       |
	When the cricket ticker is updated
	Then the ticker should display "NZ:121+157/4 SA:525 D:3 Stumps"