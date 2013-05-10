Feature: Register a new User
	As member of the site
	So that they can log in to the site and use its features

Scenario: On Successful registration the user should be redirected to Home Page
	Given The user has entered all the information
	When He Clicks on Register button
	Then He should be logged in

     