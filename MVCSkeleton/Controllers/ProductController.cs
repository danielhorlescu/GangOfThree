using System;
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

            product.Id = service.Create(mapper.Map(product, new ProductDTO()));

            return Json(new[] { product }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Update([Bind(Prefix = "models")] List<ProductModel> products)
        {
            ProductModel product = products[0];

            service.Update(mapper.Map(product, new ProductDTO()));

            //ModelState.AddModelError("Product", "Product already exists!");
            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Product_Delete([Bind(Prefix = "models")] List<ProductModel> products)
        {
            ProductModel product = products[0];

            service.Delete(product.Id);

            //ModelState.AddModelError("Product", "Product could not be deleted!");
            return Json(ModelState.ToDataSourceResult());
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View(new ProductModel());
            }
            else
            {
                ProductDTO productDto = service.Get(id.Value);
                return View(mapper.Map(productDto, new ProductModel()));
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if (product.Id == Guid.Empty)
            {
                service.Create(mapper.Map(product, new ProductDTO()));
            }
            else
            {
                service.Update(mapper.Map(product, new ProductDTO()));    
            }
            
            return RedirectToAction("GetProducts");
        }

        //[HttpPost]
        public ActionResult DeleteAll(List<ProductModel> products)
        {
            return RedirectToAction("GetProducts");
        }
    }
}