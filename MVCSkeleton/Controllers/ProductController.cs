using System.Collections.Generic;
using System.Web.Mvc;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        public ViewResult GetProducts()
        {
            List<ProductDTO> productDtos = service.GetProducts();

            return View(new ProductModel {Products = productDtos});
        }
    }
}