using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace MVCSkeleton.Requirements.SeleniumHelpers
{
    public class BrowserWrapper
    {
        private static BrowserWrapper instance;

        public static BrowserWrapper Instance
        {
            get { return instance ?? (instance = new BrowserWrapper()); }
        }

        public IWebDriver Browser { get; private set; }

        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

        public void Start()
        {
            if (Browser != null)
                return;

            Browser = GetBrowserDriver();
            Browser.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);
        }

        private static IWebDriver GetBrowserDriver()
        {
           //  return new FirefoxDriver();
               return new ChromeDriver();
            //return new InternetExplorerDriver();
        }

        public void Stop()
        {
            if (Browser == null)
                return;

            try
            {
                Browser.Quit();
                Browser.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            Browser = null;
        }
    }
}