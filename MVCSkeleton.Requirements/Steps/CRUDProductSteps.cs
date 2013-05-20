using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MVCSkeleton.Domain;
using MVCSkeleton.Presentation.Constants;
using MVCSkeleton.Infrastracture.Utils.Comparer;
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
            Assert.IsTrue(ObjectComparer.AreObjectsEqual(ProductContext.Current.Product, product, "Id", "CreationDate", "UpdateDate"));
        }

        [Given(@"I have the products")]
        public void GivenIHaveTheProducts(Table table)
        {
            ProductFlows.CreateProducts(GetProductsFromTable(table));
        }

        [Given(@"I click edit for the '(.*)' product")]
        public void GivenIClickEditForTheProduct(string productId)
        {
            var editButton = FindButtonOnRowWithProduct(productId, string.Format("//*[@{0} ='{1}']/a", CustomAttributeNames.DataPropertyName, ProductConstants.Name));
            editButton.Click();
        }

        [When(@"I click delete for the '(.*)' product")]
        public void WhenIClickDeleteForTheProduct(string productId)
        {
            var deleteButton = FindButtonOnRowWithProduct(productId, ProductListConstants.FindDeleteButtonInGridXPath);
            deleteButton.Click();
            Browser.SwitchTo().Alert().Accept();
        }

        private IWebElement FindButtonOnRowWithProduct(string productId, string xPathButtonCondition)
        {
            var rowWithProduct = FindRowWithProduct(productId);
            IWebElement button = rowWithProduct.FindElement(By.XPath(xPathButtonCondition));
            return button;
        }

        private IWebElement FindRowWithProduct(string productId)
        {
            return FindRowsBy(ProductListConstants.FindProductsGridXPath, productId).First();
        }

        [Then(@"The grid should not contain the '(.*)' product")]
        public void ThenTheGridShouldNotContainTheProduct(string productId)
        {
            var rowWithProduct = FindRowsBy(ProductListConstants.FindProductsGridXPath, productId);
            Assert.AreEqual(0, rowWithProduct.Count);
        }

        private static IEnumerable<Product> GetProductsFromTable(Table table)
        {
            List<Product> products = new List<Product>();
            foreach (var row in table.Rows)
            {
                products.Add(new Product
                {
                    Id = !row.ContainsKey(ProductConstants.Id) ? Guid.Empty : Guid.Parse(row[ProductConstants.Id]),
                    Name = row[ProductConstants.Name],
                    Code = row[ProductConstants.Code],
                    UnitPrice = Convert.ToDouble(row["Unit Price"]),
                    UnitsInStock = Convert.ToInt32(row["Units In Stock"])
                });
            }
            return products;
        }

        private IEnumerable<Product> GetProductsFromGrid()
        {
            List<Product> products = new List<Product>();
            foreach (var gridRow in Browser.FindElements(By.XPath(ProductListConstants.FindRowsInProductsGridXPath)))
            {
                Product product = new Product();
                product.Name = GetPropertyValue(gridRow, ProductConstants.Name);
                product.Code = GetPropertyValue(gridRow, ProductConstants.Code);
                product.UnitPrice = double.Parse(GetPropertyValue(gridRow, ProductConstants.UnitPrice), NumberStyles.Currency);
                product.UnitsInStock = Convert.ToInt32(GetPropertyValue(gridRow, ProductConstants.UnitsInStock));
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
            return gridRow.FindElement((By.XPath(string.Format(".//*[@{0} ='{1}']", CustomAttributeNames.DataPropertyName, dataPropertynameName))));
        }
    }
}