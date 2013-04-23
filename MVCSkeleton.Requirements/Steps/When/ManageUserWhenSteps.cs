using MVCSkeleton.Requirements.Context;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.When
{
    [Binding]
    public class ManageUserWhenSteps
    {
        [When(@"He Clicks the Change Password button")]
        public void WhenHeClicksTheChangePasswordButton()
        {
            UserContext.Current.InitializeController();
            UserContext.Current.ManageResult = UserContext.Current.Controller.Manage(UserContext.Current.PasswordModel, UserContext.Current.LoggedUser.Name);
        }
    }
}