using System.Collections.Generic;
using System.Linq;
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
    public class CustomerRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[] { new StructureMapApplicationStartupModule(),
                new AutoMapperApplicationStartupModule() }).Load();
        }

        private CustomerRepository CreateSUT()
        {
            return new CustomerRepository();
        }

        [TearDown]
        public void CleanUp()
        {
            IOCProvider.Instance.Get<ISessionAdapter>().Rollback();
        }

        [Test]
        public void Should_Save_A_Customer()
        {
            Customer expectedCustomer = CreateCustomer();

            CustomerRepository customerRepository = CreateSUT();

            customerRepository.Save(expectedCustomer);
            IEnumerable<Customer> allCustomers = customerRepository.GetAll();

            Assert.IsNotNull(allCustomers);
            var actualCustomer = allCustomers.FirstOrDefault(c => c.Id == expectedCustomer.Id);
            if (actualCustomer != null) Assert.AreEqual(expectedCustomer.Id, actualCustomer.Id);
        }

        private Customer CreateCustomer()
        {
            return new Customer
                {
                    Id = 1,
                    AddressId = "1",
                    Name = "CustomerName",
                    Surname = "CustomerSurname"
                };
        }

        private List<Customer> CreateCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer
                {
                    Id = 3,
                    AddressId =  "24",
                    Name = "CustomerName",
                    Surname = "CustomerSurname"
                });
            customers.Add(new Customer
            {
                Id = 4,
                AddressId = "24",
                Name = "CustomerName",
                Surname = "CustomerSurname"
            });
            customers.Add(new Customer
            {
                Id = 5,
                AddressId = "24",
                Name = "CustomerName",
                Surname = "CustomerSurname"
            });

            return customers;
        }

        [Test]
        public void Should_Retrieve_All_Customers()
        {
            List<Customer> customerList = CreateCustomers();

            CustomerRepository customerRepository = CreateSUT();
            foreach (var customer in customerList)
            {
                customerRepository.Save(customer);
          
            }


            var actualCustomers = customerRepository.GetAll();
            Assert.IsNotNull(actualCustomers);
            Assert.AreEqual(3, actualCustomers.Count());
        }


    }

}
