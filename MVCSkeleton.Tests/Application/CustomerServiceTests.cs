using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using MVCSkeleton.Application;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Application
{
   
   [TestFixture]
    public class CustomerServiceTests
    {
        private ICustomerRepository customerRepository;
        private IMapper mapper;

        public CustomerService CreateSUT()
        {
            customerRepository = A.Fake<ICustomerRepository>();
            mapper = A.Fake<IMapper>();
            return new CustomerService(customerRepository, mapper);
        }

        [Test]
        public void Should_Get_Customer_List()
        {
            CustomerService customerService = CreateSUT();
            List<Customer> customers = new List<Customer>();
            List<CustomerDTO> customerDtos = new List<CustomerDTO>();

            A.CallTo(() => customerRepository.GetAll()).Returns(customers);
            A.CallTo(() => mapper.Map(customers, customerDtos)).Returns(customerDtos);


            List<CustomerDTO> actualCustomerDtos = customerService.GetCustomers();
            Assert.IsNotNull(actualCustomerDtos);
        }
    }
}
