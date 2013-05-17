using System.Collections.Generic;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using MVCSkeleton.Presentation.Models;
using MVCSkeleton.Requirements.SeleniumHelpers;
using Microsoft.Practices.ObjectBuilder2;
using OpenQA.Selenium;

namespace MVCSkeleton.Requirements.Flows
{
    internal static class ProductFlows
    {
        private static IWebDriver Browser
        {
            get { return BrowserWrapper.Instance.Browser; }
        }

        public static void CreateProducts(IEnumerable<Product> products)
        {
            using (MVCSkeletonDataContext db = new MVCSkeletonDataContext())
            {
                products.ForEach(p => db.Products.Add(p));
                db.SaveChanges();
            }
        }

        public static void InitializeControlsFrom(Product product)
        {
            Browser.SetInputValue("Name", product.Name);
            Browser.SetInputValue("Code", product.Code);
            Browser.SetInputValue("UnitPrice", product.UnitPrice.ToString());
            Browser.SetInputValue("UnitsInStock", product.UnitsInStock.ToString());
        }
    }
}