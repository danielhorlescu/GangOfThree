using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using MVCSkeleton.Domain;
using MVCSkeleton.Presentation.Models;
using MVCSkeleton.Requirements.Context;
using MVCSkeleton.Requirements.Flows;
using MVCSkeleton.Requirements.SeleniumHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Steps
{
    [Binding]
    public class CRUDProductSteps : StepsBase
    {
        [Given(@"I enter the product")]
        public void GivenIEnterTheProduct(Table table)
        {
            ProductContext.Current.Product = GetProductsFromTable(table).First();
            ProductFlows.InitializeControlsFrom(ProductContext.Current.Product);
        }

        [Then(@"I should be redirected to the '(.*)' page")]
        public void ThenIShouldBeRedirectedToThePage(string pageUrl)
        {
            Assert.IsTrue(Browser.Url.Contains(pageUrl));
        }

        [Then(@"I should have the product listed in the grid")]
        public void ThenIShouldHaveTheProductListedInTheGrid()
        {
            Product product = GetProductsFromGrid().First();
            Assert.AreEqual(ProductContext.Current.Product, product);
        }

        [Given(@"I have the products")]
        public void GivenIHaveTheProducts(Table table)
        {
            ProductFlows.CreateProducts(GetProductsFromTable(table));
        }

        [Given(@"I click edit for the '(.*)' product")]
        public void GivenIClickEditForTheProduct(string productId)
        {
            IWebElement productsGrid = Browser.FindElement(By.XPath("//div[@id ='ProductsGrid']"));
            IWebElement rowWithProduct =
                 productsGrid.FindElement(By.XPath(string.Format("//tr[@role='row' and @data-id='{0}']", productId.ToLower())));

            IWebElement editButton =
                rowWithProduct.FindElement(By.XPath(string.Format("//*[@data-propertyname ='{0}']/a", "Name")));
            editButton.Click();
        }

        [When(@"I click delete for the '(.*)' product")]
        public void WhenIClickDeleteForTheProduct(string productId)
        {
            IWebElement productsGrid = Browser.FindElement(By.XPath("//div[@id ='ProductsGrid']"));
            IWebElement rowWithProduct =
                 productsGrid.FindElement(By.XPath(string.Format("//tr[@role='row' and @data-id='{0}']", productId.ToLower())));

            IWebElement deleteButton = rowWithProduct.FindElement(By.XPath("//td/a[contains(@class, 'k-grid-delete')]"));

            deleteButton.Click();
            Browser.SwitchTo().Alert().Accept();
        }

        [Then(@"The grid should not contain the '(.*)' product")]
        public void ThenTheGridShouldNotContainTheProduct(string productId)
        {
            IWebElement productsGrid = Browser.FindElement(By.XPath("//div[@id ='ProductsGrid']"));
            ReadOnlyCollection<IWebElement> rowWithProduct =
                 productsGrid.FindElements(By.XPath(string.Format("//tr[@role='row' and @data-id='{0}']", productId.ToLower())));

            Assert.AreEqual(0, rowWithProduct.Count);
        }


        private static IEnumerable<Product> GetProductsFromTable(Table table)
        {
            List<Product> products = new List<Product>();
            foreach (var row in table.Rows)
            {
                products.Add(new Product
                {
                    Id = string.IsNullOrEmpty(row["Id"]) ? Guid.Empty : Guid.Parse(row["Id"]),
                    Name = row["Name"],
                    Code = row["Code"],
                    UnitPrice = Convert.ToDouble(row["Unit Price"]),
                    UnitsInStock = Convert.ToInt32(row["Units In Stock"])
                });
            }
            return products;
        }

        private IEnumerable<Product> GetProductsFromGrid()
        {
            List<Product> products = new List<Product>();
            foreach (var gridRow in Browser.FindElements(By.XPath("//div[@id ='ProductsGrid']//tr[@role ='row']")))
            {
                Product product = new Product();
                product.Name = GetPropertyValue(gridRow, "Name");
                product.Code = GetPropertyValue(gridRow, "Code");
                product.UnitPrice = double.Parse(GetPropertyValue(gridRow, "UnitPrice"), NumberStyles.Currency);
                product.UnitsInStock = Convert.ToInt32(GetPropertyValue(gridRow, "UnitsInStock"));
                products.Add(product);
            }
            return products;
        }

        private static string GetPropertyValue(IWebElement gridRow, string dataPropertynameName)
        {
            return FindElement(gridRow, dataPropertynameName).Text;
        }

        private static IWebElement FindElement(IWebElement gridRow, string dataPropertynameName)
        {
            return gridRow.FindElement((By.XPath(string.Format(".//*[@data-propertyname ='{0}']",dataPropertynameName))));
        }
    }
}