using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Controllers;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Controllers
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private ICustomerService service;
        private IMapper mapper;

        private CustomerController CreateSUT()
        {
            service = A.Fake<ICustomerService>();
            mapper = A.Fake<IMapper>();
            return new CustomerController(service,mapper);
        }

        [Test]
        public void Should_Return_All_Customers()
        {
            CustomerController customerController = CreateSUT();
            List<CustomerDTO> expectedCustomers = CreateCustomerList();

            A.CallTo(() => service.GetCustomers()).Returns(expectedCustomers);
            ViewResult view = customerController.GetCustomers();
            Assert.AreEqual(expectedCustomers.Count,((CustomersModel)view.Model).CustomerList.Count);
        }

        private List<CustomerDTO> CreateCustomerList()
        {
            return new List<CustomerDTO>
                {
                    new CustomerDTO
                        {
                            AddressId = "123",
                            Id = Guid.NewGuid(),
                            Name = "CustomerName1",
                            Surname = "CustomerSurname1"

                        },
                    new CustomerDTO
                        {
                            AddressId = "321",
                            Id = Guid.NewGuid(),
                            Name = "CustomerName2",
                            Surname = "CustomerSurname2"

                        }
                };
        }

    }
}
