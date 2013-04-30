using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Controllers;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Controllers
{
    [TestFixture]
    public class MenuControllerTests
    {
        private IMenuItemService service;

        public MenuController CreateSUT()
        {
            service = A.Fake<IMenuItemService>();
            return new MenuController(service);
        }

        [Test]
        public void Should_Get_Root_Menu_Items()
        {
            MenuController menuController = CreateSUT();
            List<RootMenuItemDTO> expectedRootMenuItems = CreateRootMenuItemList();

            A.CallTo(() => service.GetRootMenuItems()).Returns(expectedRootMenuItems);
            ViewResult view = menuController.GetRootMenuItems();

            Assert.AreEqual(expectedRootMenuItems, ((MenuModel)view.Model).RootItems);
        }

        private List<RootMenuItemDTO> CreateRootMenuItemList()
        {
            return new List<RootMenuItemDTO>
                {
                    new RootMenuItemDTO {Name = "test menu Item"}
                };
        }
    }
}