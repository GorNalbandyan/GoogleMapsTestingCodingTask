Feature: SearchRouteDirections

Test case verifies reoute direction information is displayed
and add destination features

Background: Selecying starting point and destination
	Given Google Maps page is open
		And Directions is selected
	When I choose Massachusetts as starting point
		And I choose Arizona as destination
		
Scenario: Search Route Direction
	Then Route information is displayed

Scenario: Add Directions
	When I add <destinationNumber> destinations
	Then Route information is displayed
	Examples: 
		| destinationNumber |
		| 2                 |
		| 3                 |


