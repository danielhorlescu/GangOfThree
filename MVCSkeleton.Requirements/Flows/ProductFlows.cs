using System.Collections.Generic;
using MVCSkeleton.Presentation.Models;
using MVCSkeleton.Requirements.SeleniumHelpers;
using OpenQA.Selenium;

namespace MVCSkeleton.Requirements.Flows
{
    internal static class ProductFlows
    {
        private static IWebDriver Browser
        {
            get { return BrowserWrapper.Instance.Browser; }
        }

        public static void CreateProducts(IEnumerable<ProductModel> products)
        {
            foreach (var product in products)
            {
                Browser.NavigateTo(@"Product\Edit");
                InitializeControlsFrom(product);
                Browser.ClickButton("saveProductBtn");
            }
        }

        public static void InitializeControlsFrom(ProductModel product)
        {
            Browser.SetInputValue("Name", product.Name);
            Browser.SetInputValue("Code", product.Code);
            Browser.SetInputValue("UnitPrice", product.UnitPrice.ToString());
            Browser.SetInputValue("UnitsInStock", product.UnitsInStock.ToString());
        }
    }
}