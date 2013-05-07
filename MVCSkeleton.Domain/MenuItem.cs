namespace MVCSkeleton.Domain
{
    public class MenuItem :  EntityBase, IAggregateRoot
    {
        public virtual string Controller { get; set; }

        public virtual string Action { get; set; }

        public virtual string Name { get; set; }

        public virtual MenuItem ParentItem { get; set; }
    }
}