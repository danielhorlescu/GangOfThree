using System.Collections.Generic;
using FakeItEasy;
using MVCSkeleton.Application;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Application
{
    [TestFixture]
    public class MenuItemServiceTests
    {
        private IMenuItemRepository menuItemRepository;
        private IMapper mapper;

        public MenuItemService CreateSUT()
        {
            menuItemRepository = A.Fake<IMenuItemRepository>();
            mapper = A.Fake<IMapper>();
            return new MenuItemService(menuItemRepository, mapper);
        }

        [Test]
        public void Should_Get_Root_Menu_Items()
        {
            MenuItemService menuItemService = CreateSUT();
            List<MenuItem> menuItems = new List<MenuItem>();
            List<RootMenuItemDTO> menuItemDtos = new List<RootMenuItemDTO>();

            A.CallTo(() => menuItemRepository.GetRootMenuItems()).Returns(menuItems);
            A.CallTo(() => mapper.Map(menuItems, menuItemDtos)).Returns(menuItemDtos);


            List<RootMenuItemDTO> actualMenuItemDtos = menuItemService.GetRootMenuItems();
            Assert.IsNotNull(actualMenuItemDtos);
        }
    }
}