﻿using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class CustomerRepository :  BaseRepository<Customer> ,ICustomerRepository
    {

      
    }
}
