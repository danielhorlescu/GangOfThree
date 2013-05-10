using System;
using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {

        Guid Save(T domainObject);

        T Get(Guid id);

        void Delete(T user);

        void Delete(Guid id);

        void Save(IEnumerable<T> domainObjects);

        IEnumerable<T> GetAll();
    }
}