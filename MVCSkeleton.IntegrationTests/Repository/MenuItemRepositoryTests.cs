using System.Collections.Generic;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class MenuItemRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[] { new StructureMapApplicationStartupModule(),
                new AutoMapperApplicationStartupModule() }).Load();
        }

        private MenuItemRepository CreateSUT()
        {
            return new MenuItemRepository();
        }

        [TearDown]
        public void CleanUp()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().Rollback();
        }

        [Test]
        public void Should_Save_A_Menu_Item()
        {
            var expectedMenuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.Save(expectedMenuItem);
            MenuItem actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);

            Assert.IsNotNull(actualMenuItem);
            Assert.AreEqual(expectedMenuItem.Id, actualMenuItem.Id);
        }

        [Test]
        public void Should_Delete_A_Menu_Item()
        {
            var menuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.Save(menuItem);
            menuItemRepository.Delete(menuItem);

            MenuItem actualMenuItem = menuItemRepository.Get(menuItem.Id);
            Assert.IsNull(actualMenuItem);
        }

        [Test]
        public void Should_Update_Name()
        {
            var expectedMenuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.Save(expectedMenuItem);
            MenuItem actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);

            string updatedMenuItem = "Updated Menu Item";
            actualMenuItem.Name = updatedMenuItem;
            menuItemRepository.Save(actualMenuItem);

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
            List<MenuItem> testMenuItems = new List<MenuItem>();

            MenuItem rootMenuItem = CreateAggregateMenuItem("Menu Root");
            MenuItem aggregateMenuItem1 = CreateAggregateMenuItem("Menu Aggregate 1", rootMenuItem);
            MenuItem aggregateMenuItem2 = CreateAggregateMenuItem("Menu Aggregate 2", rootMenuItem);
            testMenuItems.Add(CreateMenuItem("testController1", "testAction1", "MenuItem1", aggregateMenuItem1));
             testMenuItems.Add( CreateMenuItem("testController1", "testAction1", "MenuItem1",aggregateMenuItem2));
              testMenuItems.Add(CreateMenuItem("testController1", "testAction1", "MenuItem1",aggregateMenuItem2));
           
            return testMenuItems;
        }

        private MenuItem CreateMenuItem(string controller = "User", string action = "GetAccounts", string name = "Test Menu Item",
            MenuItem aggregateMenuItem = null)
        {
            MenuItem expectedMenuItem = new MenuItem();
            expectedMenuItem.Controller = controller;
            expectedMenuItem.Action = action;
            expectedMenuItem.Name = name;
            expectedMenuItem.ParentItem = aggregateMenuItem;
            return expectedMenuItem;
        }

        private MenuItem CreateAggregateMenuItem(string menuAggregate, MenuItem rootMenuItem = null)
        {
            return new MenuItem {Name = menuAggregate, ParentItem = rootMenuItem};
        }
    }

   
}