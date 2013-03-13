namespace MVCSkeleton.Domain
{
    public class User : IAggregateRoot
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }
    }
}