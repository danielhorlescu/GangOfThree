using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.Models
{
    public class ProductModel
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdateDate { get; set; }

        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Code")]
        public string Code { get; set; }

        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public double? UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Units In Stock")]
        public int? UnitsInStock { get; set; }
    }
}