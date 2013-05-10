﻿using System.Collections.Generic;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class MenuItemRepositoryTests : BaseRepositoryTests
    {
        private MenuItemRepository CreateSUT()
        {
            return new MenuItemRepository();
        }

        [Test]
        public void Should_Save_A_Menu_Item()
        {
            var expectedMenuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.SaveWithCommit(expectedMenuItem);
            MenuItem actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);

            Assert.IsNotNull(actualMenuItem);
            Assert.AreEqual(expectedMenuItem.Id, actualMenuItem.Id);
        }

        [Test]
        public void Should_Delete_A_Menu_Item()
        {
            var menuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.SaveWithCommit(menuItem);
            menuItemRepository.DeleteWithCommit(menuItem);

            MenuItem actualMenuItem = menuItemRepository.Get(menuItem.Id);
            Assert.IsNull(actualMenuItem);
        }

        [Test]
        public void Should_Update_Name()
        {
            var expectedMenuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.SaveWithCommit(expectedMenuItem);
            MenuItem actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);

            const string updatedMenuItem = "Updated Menu Item";
            actualMenuItem.Name = updatedMenuItem;

            actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);
            Assert.IsNotNull(actualMenuItem);
            Assert.AreEqual(updatedMenuItem, actualMenuItem.Name);
        }

        //[Test]
        //public void Should_Return_Correct_Number_Of_Aggregate_Menu_Items()
        //{
        //    List<MenuItem> menuItems = CreateMenuItems();

        //    MenuItemRepository menuItemRepository = CreateSUT();
        //    menuItemRepository.Save(menuItems);

        //    IOCProvider.Instance.Get<ISessionAdapter>().Commit();
        // List<MenuItem> rootMenuItems = menuItemRepository.GetRootMenuItems();
        //  Assert.IsTrue(rootMenuItems.Count == 2);
        //}

        //[Test]
        //public void Should_Load_ChildMenuItem_With_LazyLoading_By_Default()
        //{

        //    MenuItemRepository menuItemRepository = CreateSUT();
        //    MenuItem withParentItem = menuItemRepository.GetWithParentItem(19);
        //    // MenuItem menuItem = menuItemRepository.Get(19);

        //    MenuItem parentItem = withParentItem.ParentItem;

        //}

        private List<MenuItem> CreateMenuItems()
        {
            var testMenuItems = new List<MenuItem>();

            MenuItem rootMenuItem = CreateAggregateMenuItem("Menu Root");
            MenuItem aggregateMenuItem1 = CreateAggregateMenuItem("Menu Aggregate 1", rootMenuItem);
            MenuItem aggregateMenuItem2 = CreateAggregateMenuItem("Menu Aggregate 2", rootMenuItem);
            testMenuItems.Add(CreateMenuItem("testController1", "testAction1", "MenuItem1", aggregateMenuItem1));
            testMenuItems.Add(CreateMenuItem("testController1", "testAction1", "MenuItem1", aggregateMenuItem2));
            testMenuItems.Add(CreateMenuItem("testController1", "testAction1", "MenuItem1", aggregateMenuItem2));

            return testMenuItems;
        }

        private MenuItem CreateMenuItem(string controller = "User", string action = "GetAccounts",
                                        string name = "Test Menu Item",
                                        MenuItem aggregateMenuItem = null)
        {
            var expectedMenuItem = new MenuItem
                {
                    Controller = controller,
                    Action = action,
                    Name = name,
                    ParentItem = aggregateMenuItem
                };
            return expectedMenuItem;
        }

        private MenuItem CreateAggregateMenuItem(string menuAggregate, MenuItem rootMenuItem = null)
        {
            return new MenuItem {Name = menuAggregate, ParentItem = rootMenuItem};
        }
    }
}