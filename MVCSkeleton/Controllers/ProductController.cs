using System.Collections.Generic;
using System.Web.Mvc;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public ViewResult GetProducts()
        {
            List<ProductDTO> productDtos = service.GetProducts();

            List<ProductModel> productModels = mapper.Map(productDtos, new List<ProductModel>());

            return View(productModels);
        }
    }
}