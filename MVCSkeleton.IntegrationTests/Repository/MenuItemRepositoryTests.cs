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
        public void Should_Save_A_User()
        {
            var expectedMenuItem = CreateMenuItem();

            MenuItemRepository menuItemRepository = CreateSUT();
            menuItemRepository.Save(expectedMenuItem);
            MenuItem actualMenuItem = menuItemRepository.Get(expectedMenuItem.Id);

            Assert.IsNotNull(actualMenuItem);
            Assert.AreEqual(expectedMenuItem.Id, actualMenuItem.Id);
        }

        //[Test]
        //public void Should_Update_A_User_Password()
        //{
        //    var user = CreateMenuItem();
        //    UserRepository userRepository = CreateSUT();
        //    userRepository.Save(user);

        //    var newPassword = "testPass";
        //    userRepository.ChangePassword(user.Name, user.Password, newPassword);
        //    User actualUser = userRepository.Get(user.Id);

        //    Assert.AreEqual(newPassword, actualUser.Password);
        //}

        //[Test]
        //public void Should_Delete_A_User()
        //{
        //    var user = CreateMenuItem();

        //    UserRepository userRepository = CreateSUT();
        //    userRepository.Save(user);
        //    userRepository.Delete(user);

        //    User actualUser = userRepository.Get(user.Id);
        //    Assert.IsNull(actualUser);
        //}

        private static MenuItem CreateMenuItem()
        {
            MenuItem expectedMenuItem = new MenuItem();
            expectedMenuItem.Controller = "User";
            expectedMenuItem.Action = "GetAccounts";
            return expectedMenuItem;
        }
    }

   
}