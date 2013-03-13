using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        void Save(T domainObject);
    }
}