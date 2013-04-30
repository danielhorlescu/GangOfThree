using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.Tests.IOC
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void Assert_that_configurations_are_valid()
        {
            new AutoMapperApplicationStartupModule().Load();
        }
    }
}