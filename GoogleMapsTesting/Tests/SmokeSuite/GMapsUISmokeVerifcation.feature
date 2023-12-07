Feature: GMapsUISmokeVerifcation

Test cases verifies all main components of the first page are displayed.

Scenario Outline: Smoke Validation of Main Components
	Given Google Maps page is open
	Then <componentName> compontent should be displayed
		Examples:
		| componentName             |
		| Menu                      |
		| Search Google Maps        |
		| Restaurants               |
		| Hotels                    |
		| Things to do              |
		| Interactive map           |
		| Show Street View coverage |
		| Sign in                   |



