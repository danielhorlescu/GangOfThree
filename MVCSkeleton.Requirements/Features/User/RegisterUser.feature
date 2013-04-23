Feature: Register a new User
	Register  a new User
	As member of the site
	So that they can log in to the site and use its features

Scenario: On Successful registration the user should be redirected to Home Page
	Given The user has entered all the information
	When He Clicks on Register button
	Then He should be redirected to the home page

Scenario: Register should return error if username is missing
	Given The user has not entered the username
	When He Clicks on Register button
	Then He should be shown the error message "Username is required"  "username"
     