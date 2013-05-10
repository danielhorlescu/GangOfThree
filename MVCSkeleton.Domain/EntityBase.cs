using System;

namespace MVCSkeleton.Domain
{
    public class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();            
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public virtual Guid Id { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual DateTime UpdateDate { get; set; }
    }
}