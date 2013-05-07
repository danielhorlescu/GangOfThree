using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.ApplicationInterfaces;

namespace MVCSkeleton.Application
{
  public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public List<CustomerDTO> GetCustomers()
        {
            List<Customer> customerList =  customerRepository.GetAll();
          
            return mapper.Map(customerList, new List<CustomerDTO>());
        }

      public CustomerDTO SaveCustomer(CustomerDTO customerDTO)
      {
        Customer customer =   customerRepository.Save(mapper.Map(customerDTO, new Customer()));
         return mapper.Map(customer, new CustomerDTO());
      }

      public void DeleteCustomer(CustomerDTO customerDTO)
      {
          customerRepository.Delete(mapper.Map(customerDTO, new Customer()));
      }

      public void UpdateCustomer(CustomerDTO customerDTO)
      {
          Customer customer = mapper.Map(customerDTO, new Customer());
          customerRepository.Update(customer);
      }

      //public void UpdateCustomer(CustomerDTO customerDto)
      //{
      //    Customer customer = mapper.Map(customerDto, new Customer());
      //    customerRepository.
      //}
    }
}
