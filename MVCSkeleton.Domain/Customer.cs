namespace MVCSkeleton.Domain
{
    public class Customer : EntityBase, IAggregateRoot
    {
       
        public virtual  string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string AddressId { get; set; }

    }
}
