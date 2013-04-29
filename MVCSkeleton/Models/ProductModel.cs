using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSkeleton.Presentation.Models
{
    public class ProductModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        [DisplayName("Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Code")]
        public string ProductCode { get; set; }
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public double? UnitPrice { get; set; }
    }
}