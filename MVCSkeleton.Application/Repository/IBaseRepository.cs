using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {

        long Save(T domainObject);

        T Get(long id);

        void Delete(T user);

        void Delete(long id);

        void Save(IEnumerable<T> domainObjects);

        List<T> GetAll();


    }
}