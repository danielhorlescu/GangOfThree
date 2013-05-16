using System;
using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        Guid Save(T domainObject);
        void Save(IEnumerable<T> domainObjects);

        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> filter);

        void Delete(Guid id);
        void Delete(IEnumerable<Guid> ids);
    }
}