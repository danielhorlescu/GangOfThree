using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class UserRepositoryTests : BaseRepositoryTests
    {
        private UserRepository CreateSUT()
        {
            return new UserRepository();
        }

        private static User CreateUser()
        {
            var expectedUser = new User();
            expectedUser.Name = "gigi";
            expectedUser.Password = "plainText";
            return expectedUser;
        }

        [Test]
        public void Should_Delete_A_User()
        {
            User user = CreateUser();

            UserRepository userRepository = CreateSUT();
            userRepository.SaveWithCommit(user);
            userRepository.DeleteWithCommit(user);

            User actualUser = userRepository.Get(user.Id);
            Assert.IsNull(actualUser);
        }

        [Test]
        public void Should_Save_A_User()
        {
            User expectedUser = CreateUser();

            UserRepository userRepository = CreateSUT();
            userRepository.SaveWithCommit(expectedUser);
            User actualUser = userRepository.Get(expectedUser.Id);

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
        }

        [Test]
        public void Should_Update_A_User_Password()
        {
            User user = CreateUser();
            UserRepository userRepository = CreateSUT();
            userRepository.SaveWithCommit(user);
            string newPassword = "testPass";
            userRepository.ChangePassword(user.Name, user.Password, newPassword);

            User actualUser = userRepository.Get(user.Id);

            Assert.AreEqual(newPassword, actualUser.Password);
        }
    }
}