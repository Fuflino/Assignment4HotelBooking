Feature: CreateBookingExample
	In order to avoid silly mistakes
	As a booking retard
	I want to be sure i

@mytag
Scenario Outline: Create Booking
	Given I have entered <startDate> and <endDate>
	And a room is already booked from '11/10/2018' to '11/11/2018'
	When I press create booking
	Then the result should be '<outcome>'

	Examples:
	| startDate | endDate | outcome |
	| 11/8/2018 | 11/9/2018 | true  |
	| 11/12/2018 | 11/13/2018 | true|
	| 11/9/2018 | 11/12/2018 | false|
	| 11/9/2018 | 11/10/2018 | false|
	| 11/9/2018 | 11/11/2018 | false|
	| 11/10/2018 | 11/10/2018 | false|
	| 11/10/2018 | 11/11/2018 | false|
	| 11/11/2018 | 11/11/2018 | false|
	| 11/10/2018 | 11/12/2018 | false|
	| 11/11/2018 | 11/12/2018 | false|