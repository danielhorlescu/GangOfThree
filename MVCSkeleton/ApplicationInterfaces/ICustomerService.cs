using System;
using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
   public interface ICustomerService
    {
        List<CustomerDTO> GetCustomers();

       Guid SaveCustomer(CustomerDTO customerDTO);

        void DeleteCustomer(Guid customerId);

        void UpdateCustomer(CustomerDTO customerDTO);
    }
}
