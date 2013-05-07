using System;
using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class CustomerRepository :  BaseRepository<Customer> ,ICustomerRepository
    {

    }
}
