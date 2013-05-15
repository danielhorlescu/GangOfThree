using MVCSkeleton.Requirements.SeleniumHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps
{
    [Binding]
    public class RegisterUserSteps : StepsBase
    {
        [Given(@"I navigate to the '(.*)' page")]
        public void GivenINavigateToThePage(string pageUrl)
        {
            Browser.NavigateTo(pageUrl);
        }

        [Given(@"I enter all the register information")]
        public void GivenIEnterAllTheRegisterInformation()
        {
            Browser.SetInputValue("UserName", "testUser");
            Browser.SetInputValue("Password", "pass123");
            Browser.SetInputValue("ConfirmPassword", "pass123");
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.AreEqual(1, Browser.FindElements(By.Id("logoutForm")).Count);
        }
    }
}