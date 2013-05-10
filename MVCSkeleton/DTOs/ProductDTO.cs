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
    }
}