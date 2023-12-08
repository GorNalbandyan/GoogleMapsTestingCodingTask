﻿Feature: CheckTransportTypes

A short summary of the feature

Scenario: CheckTransportTypes
	Given Google Maps page is open
		And Directions is selected
	When I choose Boston as starting point
		And I choose New York as destination
	Then The <transportType> route information will be displayed
	Examples: 
		| transportType |
		| Driving       |
		| Transit       |
		| Walking       |
		| Cycling       |
		| Flights       |

