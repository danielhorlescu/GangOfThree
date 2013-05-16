Feature: Register a new User
	As member of the site
	So that they can log in to the site and use its features

Scenario: On Successful registration the user is logged in
	Given I navigate to the 'User\Register' page
	And  I enter all the register information
	When I click the 'registerBtn' button
	Then I should be logged in

     