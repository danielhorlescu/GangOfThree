using System;
using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IProductService
    {
        ProductDTO Get(Guid id);
        List<ProductDTO> GetAll();
        List<ProductDTO> GetAll(IEnumerable<Guid> ids);

        Guid Create(ProductDTO productDto);

        void Delete(Guid productId);
        void Delete(IEnumerable<Guid> productIds);
        void Update(ProductDTO productDto);
    }
}