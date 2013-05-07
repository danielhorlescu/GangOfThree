using System;

namespace MVCSkeleton.Domain
{
    public interface IEntity
    {
        long Id { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}