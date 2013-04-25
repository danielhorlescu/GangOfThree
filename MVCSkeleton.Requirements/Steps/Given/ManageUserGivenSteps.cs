using MVCSkeleton.Presentation.Models;
using MVCSkeleton.Requirements.Context;
using MVCSkeleton.Requirements.QAInterface;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.Given
{
    [Binding]
    public class ManageUserGivenSteps
    {
        [Given(@"The user ""(.*)"" with the password ""(.*)"" is logged in")]
        public void GivenTheUserWithThePasswordIsLoggedIn(string userName, string password)
        {
            UserContext.Current.LoggedUser = UserFlows.CreateUser(userName, password);
            UserContext.Current.PasswordModel = new PasswordModel {OldPassword = password};
        }

        [Given(@"He enters the newPassword ""(.*)""")]
        public void GivenHeEnteredTheNewPassword(string newPassword)
        {
            UserContext.Current.PasswordModel.NewPassword = newPassword;
            UserContext.Current.PasswordModel.ConfirmPassword = newPassword;
        }

        [Given(@"He entered the oldPassword ""(.*)""")]
        public void GivenHeEnteredTheOldPassword(string oldPassword)
        {
            UserContext.Current.LoggedUser.Password = oldPassword;
        }
    }
}