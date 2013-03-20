Feature: CricketMatchProperties

Scenario: Series Name with three caption format
	Given the series name xml element is "South Africa in England ODI Series, 5 ODI Cricket Series, 2012"
	When the series name is parsed
	Then the resulting string should be "5 ODI Cricket Series"

Scenario: Series Name with two caption format
	Given the series name xml element is "ICC Womens World Cup, 2013"
	When the series name is parsed
	Then the resulting string should be "ICC Womens World Cup"

Scenario: Series Name with redundant padding
	Given the series name xml element is "Australia vs Pakistan ODI Series, 3 ODI Cricket Series in United Arab Emirates                                                                                , 2012"
	When the series name is parsed
	Then the resulting string should be "3 ODI Cricket Series in United Arab Emirates"