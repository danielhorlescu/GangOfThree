using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MVCSkeleton.Requirements.SeleniumHelpers
{
    public static class WebDriverExtensions
    {
        public static string GetTextBoxValue(this IWebDriver browser, string field)
        {
            IWebElement control = GetControlById(browser, field);

            return control.GetAttribute("value");
        }

        public static void SetInputValue(this IWebDriver browser, string controlId, string value)
        {
            var control = browser.GetControlById(controlId);
            if (!control.Displayed)
            {
                browser.MakeControlVisible(controlId);
            }
            control.Clear();
            control.SendKeys(value);
        }

        private static void MakeControlVisible(this IWebDriver browser, string controlId)
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            js.ExecuteScript(string.Format("$('#{0}').css('display', 'inline-block');", controlId));
        }

        public static void SubmitForm(this IWebDriver browser, string formId = null)
        {
            var form = formId == null ? GetForm(browser) : browser.FindElements(By.Id(formId)).First();
            form.Submit();
        }

        public static void ClickButton(this IWebDriver browser, string buttonId)
        {
            browser.FindElements(By.Id(buttonId)).First().Click();
        }

        private static IWebElement GetControlById(this IWebDriver browser, string controlId)
        {
            return browser.FindElement(By.Id(controlId));
        }

        private static IWebElement GetForm(IWebDriver browser)
        {
            return browser.FindElements(By.TagName("form")).First();
        }

        public static void NavigateTo(this IWebDriver browser, string relativeUrl)
        {
            browser.Navigate().GoToUrl(new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl));
        }

        public static DropDown GetDropDown(this IWebDriver browser, string id)
        {
            return browser.FindElement(By.Id(id)).AsDropDown();
        }

        public static DropDown AsDropDown(this IWebElement e)
        {
            return new DropDown(e);
        }

        public class DropDown
        {
            private readonly IWebElement dropDown;

            public DropDown(IWebElement dropDown)
            {
                this.dropDown = dropDown;

                if (dropDown.TagName != "select")
                    throw new ArgumentException("Invalid web element type");
            }

            public string SelectedValue
            {
                get
                {
                    var selectedOption =
                        dropDown.FindElements(By.TagName("option")).Where(e => e.Selected).FirstOrDefault();
                    if (selectedOption == null)
                        return null;

                    return selectedOption.GetAttribute("value");
                }
                set { new SelectElement(dropDown).SelectByValue(value); }
            }
        }
    }
}