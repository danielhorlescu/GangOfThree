using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        T Save(T domainObject);

        T Get(long id);

        void Delete(T user);

        void Save(IEnumerable<T> domainObjects);

        List<T> GetAll();


    }
}