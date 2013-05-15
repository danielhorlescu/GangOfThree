using System.Collections.Generic;
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

        [Test]
        public void Assert_that_configurations_are_valid1()
        {
            Dictionary<string, object> test = new Dictionary<string, object> {{"class", "name"}, {"dsa", "fdas"}};
        }
    }
}