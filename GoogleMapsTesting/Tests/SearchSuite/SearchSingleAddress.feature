Feature: SearchSingleAddress

Test cases verifies search works both with exact address and place names

Scenario: Search single address
	Given Google Maps page is open
	When I search <street> St, <city> address
	Then <buildingNumber>, <street>, <city>, <postalCode> address should be displayed
	Examples: 
		| street      | buildingNumber | city    | postalCode |
		| 1 Nersisyan | 1              | Yerevan | 0014       |

Scenario: Search place name
	Given Google Maps page is open
	When I search <placeName> place
	Then <buildingNumber>, <street>, <city>, <postalCode> address should be displayed
	Examples: 
		| placeName    | street        | buildingNumber | city   | postalCode |
		| Wooga Games  | Saarbrücker   | 38             | Berlin | 10405      |
		| Eiffel Tower | Champ de Mars | 5              | Paris  | 75007      |
