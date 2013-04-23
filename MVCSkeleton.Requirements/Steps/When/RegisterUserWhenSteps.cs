using MVCSkeleton.Requirements.Context;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.When
{
    [Binding]
    public class RegisterUserWhenSteps
    {
        [When(@"He Clicks on Register button")]
        public void WhenHeClicksOnRegisterButton()
        {
            UserContext.Current.RegisterResult =
                UserContext.Current.Controller.Register(UserContext.Current.RegisterModel);
        }
    }
}