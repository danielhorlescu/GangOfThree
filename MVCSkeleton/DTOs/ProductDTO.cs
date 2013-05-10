using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSkeleton.Presentation.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime CreationDate { get; set; }
    }
}