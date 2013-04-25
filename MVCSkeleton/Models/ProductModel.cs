using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSkeleton.Models
{
    public class ProductModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public double? UnitPrice { get; set; }
    }
}