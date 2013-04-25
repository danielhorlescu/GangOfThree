using MVCSkeleton.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCSkeleton.Tests.IOC
{
    [TestClass]
    public class AutoMapperTests
    {
        [TestMethod]
        public void Assert_that_configurations_are_valid()
        {
            new AutoMapperApplicationStartupModule().Load();
        }
    }
}