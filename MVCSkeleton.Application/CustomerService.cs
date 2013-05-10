using System;
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
            var customerList =  (List<Customer>) customerRepository.GetAll();
          
            return mapper.Map(customerList, new List<CustomerDTO>());
        }

      public Guid SaveCustomer(CustomerDTO customerDTO)
      {
        return customerRepository.Save(mapper.Map(customerDTO, new Customer()));
      }

      public void DeleteCustomer(Guid customerId)
      {
          customerRepository.Delete(customerId);
      }

      public void UpdateCustomer(CustomerDTO customerDTO)
      {
          Customer customer = customerRepository.Get(customerDTO.Id);
          mapper.Map(customerDTO, customer);
      }

    }
}
