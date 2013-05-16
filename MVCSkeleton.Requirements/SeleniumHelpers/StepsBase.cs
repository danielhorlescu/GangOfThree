using OpenQA.Selenium;

namespace MVCSkeleton.Requirements.SeleniumHelpers
{
    public abstract class StepsBase
    {
        protected IWebDriver Browser
        {
            get { return BrowserWrapper.Instance.Browser; }
        }
    }
}