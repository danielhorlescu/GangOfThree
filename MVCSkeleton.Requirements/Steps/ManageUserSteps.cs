using MVCSkeleton.Requirements.Context;
using MVCSkeleton.Requirements.Flows;
using MVCSkeleton.Requirements.SeleniumHelpers;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps
{
    [Binding]
    public class ManageUserSteps : StepsBase
    {
        [Given(@"I enter my old password and the new password")]
        public void GivenIEnterMyOldPasswordAndTheNewPassword()
        {
            UserContext.Current.NewPassword = "newTestPass";
            Browser.SetTextBoxValue("OldPassword", UserContext.Current.CurrentUser.Password);
            Browser.SetTextBoxValue("NewPassword", UserContext.Current.NewPassword) ;
            Browser.SetTextBoxValue("ConfirmPassword", UserContext.Current.NewPassword);
        }

        [When(@"I click change password")]
        public void WhenIClickChangePassword()
        {
            Browser.ClickButton("ChangePassword");
        }

        [When(@"I log out")]
        public void WhenILogOut()
        {
            UserFlows.LogOut();
        }

        [When(@"I log in with the new password")]
        public void WhenILogInWithTheNewPassword()
        {
            UserContext.Current.CurrentUser.Password = UserContext.Current.NewPassword;
            UserFlows.LogIn();
        }

    }
}