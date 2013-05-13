using System;

namespace MVCSkeleton.Presentation.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        protected bool Equals(ProductDTO other)
        {
            return Id.Equals(other.Id) && CategoryId.Equals(other.CategoryId) && string.Equals(Code, other.Code) && string.Equals(Name, other.Name) && UnitPrice.Equals(other.UnitPrice) && UnitsInStock == other.UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ProductDTO)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ CategoryId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ UnitsInStock;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, CategoryId: {1}, Code: {2}, Name: {3}, UnitPrice: {4}, UnitsInStock: {5}", Id, CategoryId, Code, Name, UnitPrice, UnitsInStock);
        }
    }
}