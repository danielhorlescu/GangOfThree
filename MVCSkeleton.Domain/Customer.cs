namespace MVCSkeleton.Domain
{
    public class Customer : IAggregateRoot
    {
        public virtual long Id { get; set; }

        public virtual  string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string AddressId { get; set; }
    }
}
