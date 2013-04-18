using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.ApplicationStartup;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup() 
        {
            ApplicationStartupModuleContainer.Instance.RegisterModulesFromConfigurationFile();
            ApplicationStartupModuleContainer.Instance.LoadRegisteredModules();
            _userRepository = IOCProvider.Instance.Get<IUserRepository>();
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

            _userRepository.Save(expectedUser);

            User actualUser = _userRepository.Get(expectedUser.Id);
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
        }

        [Test]
        public void Should_Update_A_User_Password()
        {
            var expectedUser = CreateUser();
            string expectedPassword = "newPassword";

            _userRepository.Save(expectedUser);
            _userRepository.ChangePassword(expectedUser.Name, expectedUser.Password, expectedPassword);
            User actualUser = _userRepository.Get(expectedUser.Id);
            Assert.AreEqual(expectedPassword, actualUser.Password);
        }

        [Test]
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