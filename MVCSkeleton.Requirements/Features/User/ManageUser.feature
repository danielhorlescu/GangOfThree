Feature: Manage the current logged in User

  Background:
    Given  The user "testUser" with the password "testPass" is logged in

Scenario: As a logged in User I can change my password
	Given He enters the newPassword "newPass" 
	When He Clicks the Change Password button
	Then He should be redirected to the Manage page
	And He should see the success message "Password was successfully changed."

Scenario: As a logged in User I should not be able to change my password if I put a wrong password
	Given  He entered the oldPassword "myOldPass" 
	When He Clicks the Change Password button
	Then He should see an error message


     