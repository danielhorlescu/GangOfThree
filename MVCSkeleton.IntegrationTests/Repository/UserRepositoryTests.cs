﻿using System.Transactions;
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
    public class UserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[]
            {new StructureMapApplicationStartupModule(), new AutoMapperApplicationStartupModule()}).Load();
        }

        private UserRepository CreateSUT()
        {
            return new UserRepository();
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
            TransactionScope transactionScope = new TransactionScope();
            var user = CreateUser();
            UserRepository userRepository = CreateSUT();
            userRepository.Save(user);
            IOCProvider.Instance.Get<ISessionAdapter>().CommitWithoutDispose();
            var newPassword = "testPass";
            userRepository.ChangePassword(user.Name, user.Password, newPassword);
            IOCProvider.Instance.Get<ISessionAdapter>().CommitWithoutDispose();

            User actualUser = userRepository.Get(user.Id);

            Assert.AreEqual(newPassword, actualUser.Password);
            transactionScope.Dispose();
        }

        [Test]
        public void Should_Delete_A_User()
        {
            var user = CreateUser();

            UserRepository userRepository = CreateSUT();
            userRepository.Save(user);
            userRepository.Delete(user);

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