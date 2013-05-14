using MVCSkeleton.Requirements.Context;
using MVCSkeleton.Requirements.SeleniumHelpers;
using OpenQA.Selenium;

namespace MVCSkeleton.Requirements.Flows
{
    internal static class UserFlows
    {
        private static IWebDriver Browser
        {
            get { return BrowserWrapper.Instance.Browser; }
        }

        public static void LogIn()
        {
            Browser.NavigateTo(@"User\Login");
            Browser.SetTextBoxValue("UserName", UserContext.Current.CurrentUser.Name);
            Browser.SetTextBoxValue("Password", UserContext.Current.CurrentUser.Password);
            Browser.SubmitForm();
        }

        public static void LogOut()
        {
            Browser.SubmitForm("logoutForm");
        }
    }
}