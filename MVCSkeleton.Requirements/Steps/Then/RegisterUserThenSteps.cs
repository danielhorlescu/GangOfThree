using System.Web.Mvc;
using MVCSkeleton.Requirements.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.Then
{
    [Binding]
    public class RegisterUserThenSteps
    {
        [Then(@"He should be redirected to the home page")]
        public void ThenHeShouldBeRedirectedToTheHomePage()
        {
            var expected = "Index";
            Assert.IsNotNull(UserContext.Current.RegisterResult);
            Assert.IsInstanceOf<RedirectToRouteResult>(UserContext.Current.RegisterResult);

            var tresults = UserContext.Current.RegisterResult as RedirectToRouteResult;

            Assert.AreEqual(expected, tresults.RouteValues["action"]);
        }

        [Then(@"He should be shown the error message ""(.*)""  ""(.*)""")]
        public void ThenHeShouldBeShownTheErrorMessage(string errorMessage, string field)
        {
            Assert.IsNotNull(UserContext.Current.RegisterResult);
            Assert.IsInstanceOf<ViewResult>(UserContext.Current.RegisterResult);

            Assert.IsTrue(UserContext.Current.Controller.ViewData.ModelState.ContainsKey(field));

            Assert.AreEqual(errorMessage,
                UserContext.Current.Controller.ViewData.ModelState[field].Errors[0].ErrorMessage);
        }

    }
}
