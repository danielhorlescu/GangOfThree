using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.ApplicationStartup;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCSkeleton.IntegrationTests.EntityFrameworkRepository
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public void Initialize()
        {
            ApplicationStartupModuleContainer.Instance.RegisterModulesFromConfigurationFile();
            ApplicationStartupModuleContainer.Instance.LoadRegisteredModules();
            _userRepository = IOCProvider.Instance.Get<IUserRepository>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().Rollback();
        }

        [TestMethod]
        public void Should_Save_A_User()
        {
            var expectedUser = CreateUser();

            _userRepository.Save(expectedUser);

            User actualUser = _userRepository.Get(expectedUser.Id);
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
        }

        [TestMethod]
        public void Should_Update_A_User_Password()
        {
            var expectedUser = CreateUser();
            string expectedPassword = "newPassword";

            _userRepository.Save(expectedUser);
            _userRepository.ChangePassword(expectedUser.Name, expectedUser.Password, expectedPassword);
            User actualUser = _userRepository.Get(expectedUser.Id);
            Assert.AreEqual(expectedPassword, actualUser.Password);
        }

        [TestMethod]
        public void Should_Delete_A_User()
        {
            var user = CreateUser();

            _userRepository.Save(user);
            _userRepository.Delete(user);
            User actualUser = _userRepository.Get(user.Id);
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