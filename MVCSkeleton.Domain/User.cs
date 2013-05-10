namespace MVCSkeleton.Domain
{
    public class User : EntityBase, IAggregateRoot
    {     
        public virtual string Name { get; set; }

        public virtual string Password { get; set; }
    }
}