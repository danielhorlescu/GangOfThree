using System;

namespace MVCSkeleton.Domain
{
    public class Store : EntityBase, IAggregateRoot
    {        
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }               
    }
}
