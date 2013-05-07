using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Controllers
{
    [TestFixture]
    public class StoreControllerTests
    {
        public StoreController CreateSUT()
        {
            return new StoreController();
        }

        [Test]
        public void Should_Get_All_Stores()
        {

        }
    }

    public class StoreController
    {
    }
}
