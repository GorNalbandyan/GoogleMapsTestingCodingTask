Feature: MapTypesSmokeVerification

This test case verifies all types of maps are available to select
after hovering on Interactive map component

Scenario: Smoke Validation of Map Details
	Given Google Maps page is open
	When I hover over Interactive map
	Then The following Map Details are displayed
		| mapDetails |
		| Terrain    |
		| Traffic    |
		| Transit    |
		| Biking     |
