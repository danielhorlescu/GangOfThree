using System.Web.Mvc;
using MVCSkeleton.Requirements.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.Then
{
    [Binding]
    public class ManageUserWhenSteps
    {
        [Then(@"He should be redirected to the Manage page")]
        public void ThenHeShouldBeRedirectedToTheManagePage()
        {
            var expected = "Manage";
            Assert.IsNotNull(UserContext.Current.ManageResult);
            Assert.IsInstanceOf<RedirectToRouteResult>(UserContext.Current.ManageResult);

            var tresults = UserContext.Current.ManageResult as RedirectToRouteResult;

            Assert.AreEqual(expected, tresults.RouteValues["action"]);
        }

        [Then(@"He should see the success message ""(.*)""")]
        public void ThenHeShouldSeeTheMessage(string expectedMessage)
        {
            var message = UserContext.Current.Controller.ViewBag.Message;
            Assert.AreEqual(expectedMessage, message);
        }

        [Then(@"He should see an error message")]
        public void ThenHeShouldSeeAnErrorMessage()
        {
            Assert.IsTrue(UserContext.Current.Controller.ModelState.Count == 1);
        }

    }
}