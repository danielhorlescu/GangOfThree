using System;
using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();

        Guid Create(ProductDTO productDto);
        void Delete(Guid productId);
        void Update(ProductDTO productDto);
        ProductDTO Get(Guid id);
    }
}