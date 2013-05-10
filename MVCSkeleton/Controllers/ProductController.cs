using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(service.GetProducts().ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Create([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] List<ProductModel> products)
        {
            ProductModel product = products[0];

            service.CreateProduct(mapper.Map(product, new ProductDTO()));
            return Json(new[] { product }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Update([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<ProductModel> products)
        {
            ModelState.AddModelError("Product", "Product already exists!");
            return Json(service.GetProducts().ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Delete([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<ProductModel> products)
        {
            ModelState.AddModelError("Product", "Product could not be deleted!");
            return Json(ModelState.ToDataSourceResult());
        }
    }
}