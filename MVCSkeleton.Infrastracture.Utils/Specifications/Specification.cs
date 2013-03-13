namespace MVCSkeleton.Infrastracture.Utils.Specifications
{
    public abstract class Specification<TCandidate> : ISpecification<TCandidate>
    {
        private bool hasBeenAddedToComposite;

        public Specification()
        {
            this.hasBeenAddedToComposite = false;
        }

        #region ISpecification<T> Members

        public abstract bool IsSatisfiedBy(TCandidate candidate);

        public bool HasBeenAddedToComposite
        {
            get { return this.hasBeenAddedToComposite; }
            set { this.hasBeenAddedToComposite = value; }
        }

        #endregion
    }
}
