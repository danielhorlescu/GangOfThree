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
            Browser.SetInputValue("OldPassword", UserContext.Current.CurrentUser.Password);
            Browser.SetInputValue("NewPassword", UserContext.Current.NewPassword) ;
            Browser.SetInputValue("ConfirmPassword", UserContext.Current.NewPassword);
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickButton(string butonId)
        {
            Browser.ClickButton(butonId);
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