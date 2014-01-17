Feature: CharToInt Converter
	Checks if a given character is a digit.
	If it is, then it returns the integer representation of it

@mytag
Scenario: If the char is numeric return int
	Given The CharToInt converter
	And The char 6
	When I check if the char can be converted
	Then the result should be true

Scenario: Check if non-numeric char can be converted to 
