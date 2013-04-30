namespace MVCSkeleton.Domain
{
    public class MenuItem : IAggregateRoot
    {
        public long Id { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
    }
}