using System.Collections.Generic;

namespace MVCSkeleton.Presentation.Models
{
    public class KendoModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<string> Countries { get; set; }
        public List<string> Fabrics { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}