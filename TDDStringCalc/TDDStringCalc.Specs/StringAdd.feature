Feature: StringAdd
	Needs to add a comma-separated string of 0, 1 or 2 numbers

@mytag
Scenario: Add zero numbers
	Given A calculator
	And An empty string
	When I press add
	Then The result should be 0

Scenario: Add one number
	Given A calculator
	And A string containing one number
	When I press add
	Then The result should be an integer equal to the input string

Scenario: Add two numbers
	Given A calculator
	And A string containing two numbers
	When I press add
	Then The result should be an integer equal to the sum of the two inputs

Scenario: Adding a string with three numbers
	Given A calculator
	And "1, 3, 4"
	When I press add
	Then The result should be 8

Scenario: Adding a string with four numbers
	Given A calculator
	And "1, 3, 4, 2"
	When I press add
	Then The result should be 10

Scenario: Adding a string separated by newlines and commas
	Given A calculator
	And "1\n 3, 4\n2"
	When I press add
	Then The result should be 10


