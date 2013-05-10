using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
   public interface ICustomerService
    {
        List<CustomerDTO> GetCustomers();

       long SaveCustomer(CustomerDTO customerDTO);

        void DeleteCustomer(long customerId);

        void UpdateCustomer(CustomerDTO customerDTO);
    }
}
