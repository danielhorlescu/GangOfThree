using System;
using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        void Save(T domainObject);

        T Get(Guid id);

        void Delete(T user);

        void Save(IEnumerable<T> domainObjects);

        IEnumerable<T> GetAll();
    }
}