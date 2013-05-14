Feature: Manage the current logged in User

@alreadyLoggedIn
Scenario: As a logged in User I can change my password
	Given I navigate to the 'User\Manage' page
	And I enter my old password and the new password
	When I click change password
	And I log out
	And I log in with the new password
	Then I should be logged in



     