using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            ProductModel productModel = GetProductsFromGrid().First();
            Assert.AreEqual(ProductContext.Current.Product, productModel);
        }

        [Given(@"I have the products")]
        public void GivenIHaveTheProducts(Table table)
        {
            ProductFlows.CreateProducts(GetProductsFromTable(table));
        }

        [Given(@"I click on the product edit link")]
        public void GivenIClickOnTheProductEditLink()
        {
            IWebElement rowWithProduct =
                Browser.FindElement(By.XPath(string.Format("//*[@data-PropertyName ='{0}']", "Name")));
            rowWithProduct.Click();
        }

        [When(@"I click delete for the '(.*)' product")]
        public void WhenIClickDeleteForTheProduct(string productName)
        {
            IWebElement rowWithProduct =
                 Browser.FindElement(By.XPath(string.Format("//tr//a[@data-PropertyName ='{0}' and text()={1}]", "Name",productName)));
            rowWithProduct.Click();
        }

        [Then(@"The grid should not contain the '(.*)' product")]
        public void ThenTheGridShouldNotContainTheProduct(string productName)
        {
            ScenarioContext.Current.Pending();
        }


        private static IEnumerable<ProductModel> GetProductsFromTable(Table table)
        {
            List<ProductModel> products = new List<ProductModel>();
            foreach (var row in table.Rows)
            {
                products.Add(new ProductModel
                {
                    Name = row["Name"],
                    Code = row["Code"],
                    UnitPrice = Convert.ToDouble(row["Unit Price"]),
                    UnitsInStock = Convert.ToInt32(row["Units In Stock"])
                });
            }
            return products;
        }

        private IEnumerable<ProductModel> GetProductsFromGrid()
        {
            List<ProductModel> products = new List<ProductModel>();
            foreach (var gridRow in Browser.FindElements(By.XPath("//div[@id ='ProductsGrid']//tr[@role ='row']")))
            {
                ProductModel product = new ProductModel();
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
            return gridRow.FindElement((By.XPath(string.Format(".//*[@data-PropertyName ='{0}']",dataPropertynameName))));
        }
    }
}