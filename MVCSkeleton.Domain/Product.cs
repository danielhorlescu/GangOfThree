namespace MVCSkeleton.Domain
{
    public class Product : EntityBase, IAggregateRoot
    {
        public virtual long CategoryId { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual double UnitPrice { get; set; }

        public virtual int UnitsInStock { get; set; }
    }
}