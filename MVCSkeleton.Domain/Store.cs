using System;

namespace MVCSkeleton.Domain
{
    public class Store : IAggregateRoot
    {
        public virtual long Id { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual DateTime LastModification { get; set; }
    }
}
