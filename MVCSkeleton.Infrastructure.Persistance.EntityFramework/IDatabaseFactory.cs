using System;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public interface IDatabaseFactory : IDisposable
    {
        MVCSkeletonDataContext Get();
    }
}