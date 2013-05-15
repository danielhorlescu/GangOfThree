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
    }
}