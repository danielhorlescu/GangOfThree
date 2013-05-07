using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCSkeleton.Application.Session;
using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    public class BaseRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[] { new StructureMapApplicationStartupModule(), new AutoMapperApplicationStartupModule() }).Load();
        }

        [TearDown]
        public void CleanUp()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().Rollback();
        }
    }
}
