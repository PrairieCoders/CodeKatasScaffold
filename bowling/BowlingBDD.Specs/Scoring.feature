Feature: Scoring
	When a player enters their series of frame scores
	I want to calculate a score for them

@mytag
Scenario: A perfect game
	Given A bowling game
	When The frame series is: X,X,X,X,X,X,X,X,X,X,X,X
	Then the result should be 300

Scenario: All spares game
	Given A bowling game
	When All the frame scores are 5 and /
	And The bonus roll is 5
	Then the result should be 150

Scenario: No strikes or spares game
	Given A bowling game
	When All the frame scores are 9 and 0
	Then the result should be 90

