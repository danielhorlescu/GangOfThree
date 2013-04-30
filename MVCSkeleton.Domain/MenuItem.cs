namespace MVCSkeleton.Domain
{
    public class MenuItem : IAggregateRoot
    {
        public virtual long Id { get; set; }

        public virtual string Controller { get; set; }

        public virtual string Action { get; set; }

        public virtual string Name { get; set; }

        public virtual MenuItem ParentItem { get; set; }
    }
}