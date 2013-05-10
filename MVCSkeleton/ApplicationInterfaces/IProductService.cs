using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();

        void CreateProduct(ProductDTO productDto);
    }
}