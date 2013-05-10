using System;

namespace MVCSkeleton.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime UpdateDate { get; set; }
    }
}