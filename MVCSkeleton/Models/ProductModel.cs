using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSkeleton.Presentation.Models
{
    public class ProductModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid CategoryId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public double? UnitPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Units In Stock")]
        public int? UnitsInStock { get; set; }

        protected bool Equals(ProductModel other)
        {
            return Id.Equals(other.Id) && CategoryId.Equals(other.CategoryId) && string.Equals(Name, other.Name) && string.Equals(Code, other.Code) && UnitPrice.Equals(other.UnitPrice) && UnitsInStock == other.UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ CategoryId.GetHashCode();
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode*397) ^ UnitsInStock.GetHashCode();
                return hashCode;
            }
        }
    }
}