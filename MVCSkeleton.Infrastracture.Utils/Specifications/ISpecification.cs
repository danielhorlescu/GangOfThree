namespace MVCSkeleton.Infrastracture.Utils.Specifications
{
    public interface ISpecification<TCandidate>
    {
        bool IsSatisfiedBy(TCandidate candidate);
        bool HasBeenAddedToComposite { get; set; }
    }

    public interface ISpecification
    {
        bool IsSatisfiedBy(object candidate);
        bool HasBeenAddedToComposite { get; set; }
    }
}
