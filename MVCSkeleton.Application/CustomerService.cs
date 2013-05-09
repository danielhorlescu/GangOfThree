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

      public long SaveCustomer(CustomerDTO customerDTO)
      {
        return  customerRepository.Save(mapper.Map(customerDTO, new Customer()));
        
      }

      public void DeleteCustomer(CustomerDTO customerDTO)
      {
          customerRepository.Delete(mapper.Map(customerDTO, new Customer()));
      }

      public void UpdateCustomer(CustomerDTO customerDTO)
      {
          Customer customer = mapper.Map(customerDTO, new Customer());
          customerRepository.Save(customer);
      }

    }
}
