using System.Transactions;
using MVCSkeleton.Application.Session;
using MVCSkeleton.IOC.Unity;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    public class BaseIntegrationTests
    {
        private TransactionScope transactionScope;

        [SetUp]
        public virtual void SetUp()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[]
                {
                    new UnityApplicationStartupModule(),
                    new AutoMapperApplicationStartupModule()
                }).Load();

            transactionScope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            transactionScope.Dispose();
        }

        protected void Commit()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().CommitWithoutDispose();
        }
    }
}