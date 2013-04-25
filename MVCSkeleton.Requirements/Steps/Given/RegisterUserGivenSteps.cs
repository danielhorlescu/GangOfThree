using System;
using System.Reflection;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Presentation.Controllers;
using MVCSkeleton.Presentation.Models;
using MVCSkeleton.Requirements.Context;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps.Given
{
    [Binding]
    public class RegisterUserGivenSteps
    {
        [Given(@"The user has entered all the information")]
        public void GivenTheUserHasEnteredAllTheInformation()
        {
            UserContext.Current.RegisterModel = new RegisterModel
                {
                    UserName = "user" + new Random(1000).NextDouble().ToString(),
                    Password = "test123",
                    ConfirmPassword = "test123"
                };
            UserContext.Current.InitializeController();
        }

        [Given(@"The user has not entered the username")]
        public void GivenTheUserHasNotEnteredTheUsername()
        {
            UserContext.Current.RegisterModel = new RegisterModel
                {
                    UserName = string.Empty,
                    Password = "test123",
                    ConfirmPassword = "test123"
                };
            UserContext.Current.InitializeController();
            UserContext.Current.Controller.ViewData.ModelState.AddModelError("userName",
                                                                                       "Username is required");
        }
       
    }
}