namespace MVCSkeleton.Infrastracture.Utils.Specifications
{
    public class InverseSpecification<TCandidate> : CompositeSpecification<TCandidate>
    {
        private ISpecification<TCandidate> toBeWrapped;

        public InverseSpecification(ISpecification<TCandidate> toBeWrapped)
        {
            this.toBeWrapped = toBeWrapped;
            AddChildComponents(this.toBeWrapped);
        }

        public override bool IsSatisfiedBy(TCandidate candidate)
        {
            return !(toBeWrapped.IsSatisfiedBy(candidate));
        }
    }
}