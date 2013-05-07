using System;

namespace MVCSkeleton.Domain
{
    public class EntityBase
    {
        protected EntityBase()
        {
            CreationDate = DateTime.Now;
        }

        public virtual long Id { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual DateTime? UpdateDate { get; set; }
    }
}