using MVCSkeleton.Application.Session;
using MVCSkeleton.ApplicationStartup;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Infrastructure.Persistance.Repositories;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            ApplicationStartupModuleContainer.Instance.RegisterModulesFromConfigurationFile();
            ApplicationStartupModuleContainer.Instance.LoadRegisteredModules();
        }

        private UserRepository CreateSUT()
        {
            return new UserRepository();
        }

        [TearDown]
        public void CleanUp()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().Rollback();
        }

        [Test]
        public void Should_Save_A_User()
        {
            var expectedUser = CreateUser();

            UserRepository userRepository = CreateSUT();
            userRepository.Save(expectedUser);
            User actualUser = userRepository.Get(expectedUser.Id);

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
        }

        [Test]
        public void Should_Update_A_User_Password()
        {
            var user = CreateUser();
            UserRepository userRepository = CreateSUT();
            userRepository.Save(user);

            var newPassword = "testPass";
            userRepository.ChangePassword(user.Name, user.Password, newPassword);
            User actualUser = userRepository.Get(user.Id);

            Assert.AreEqual(newPassword, actualUser.Password);
        }

        [Test]
        public void Should_Delete_A_User()
        {
            var user = CreateUser();

            UserRepository userRepository = CreateSUT();
            userRepository.Save(user);
            IOCProvider.Instance.Get<ISessionAdapter>().Commit();
            userRepository.Delete(user);
            IOCProvider.Instance.Get<ISessionAdapter>().Commit();

            User actualUser = userRepository.Get(user.Id);
            Assert.IsNull(actualUser);
        }

        private static User CreateUser()
        {
            User expectedUser = new User();
            expectedUser.Name = "gigi";
            expectedUser.Password = "plainText";
            return expectedUser;
        }
    }
}