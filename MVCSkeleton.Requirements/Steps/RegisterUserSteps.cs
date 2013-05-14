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
            Browser.SetTextBoxValue("UserName", "testUser");
            Browser.SetTextBoxValue("Password", "pass123");
            Browser.SetTextBoxValue("ConfirmPassword", "pass123");
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            Browser.SubmitForm();
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.AreEqual(1, Browser.FindElements(By.Id("logoutForm")).Count);
        }
    }
}