using System;

namespace MVCSkeleton.Domain
{
    public class Product : EntityBase, IAggregateRoot
    {
        public virtual Guid CategoryId { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual double UnitPrice { get; set; }

        public virtual int UnitsInStock { get; set; }

        protected bool Equals(Product other)
        {
            return CategoryId.Equals(other.CategoryId) && string.Equals(Code, other.Code) && string.Equals(Name, other.Name) && UnitPrice.Equals(other.UnitPrice) && UnitsInStock == other.UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = CategoryId.GetHashCode();
                hashCode = (hashCode*397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode*397) ^ UnitsInStock;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("CategoryId: {0}, Code: {1}, Name: {2}, UnitPrice: {3}, UnitsInStock: {4}", CategoryId, Code, Name, UnitPrice, UnitsInStock);
        }
    }
}