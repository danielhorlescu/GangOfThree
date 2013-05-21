using System.Collections.ObjectModel;
using MVCSkeleton.Presentation.Constants;
using OpenQA.Selenium;

namespace MVCSkeleton.Requirements.SeleniumHelpers
{
    public abstract class StepsBase
    {
        protected IWebDriver Browser
        {
            get { return BrowserWrapper.Instance.Browser; }
        }

        protected ReadOnlyCollection<IWebElement> FindRowsBy(string xPathGridIdCondition, string rowId)
        {
            IWebElement productsGrid = Browser.FindElement(By.XPath(xPathGridIdCondition));
            ReadOnlyCollection<IWebElement> rowWithProduct =
                productsGrid.FindElements(By.XPath(GetFindRowXPath(rowId)));
            return rowWithProduct;
        }

        private static string GetFindRowXPath(string rowId)
        {
            return string.Format("//tr[@role='row' and @{0}='{1}']", CustomAttributeNames.DataId, rowId.ToLower());
        }
    }
}