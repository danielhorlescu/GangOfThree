using System;
using System.Collections.Generic;
using System.Linq;
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

        public ViewResult List()
        {
            List<ProductDTO> productDtos = service.GetAll();

            List<ProductModel> productModels = mapper.Map(productDtos, new List<ProductModel>());

            return View(productModels);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(service.GetAll().ToDataSourceResult(dsRequest));
        }

        [HttpPost]
        public JsonResult Delete(ProductModel product)
        {
            service.Delete(product.Id);

            ModelState.AddModelError("Product", "Product could not be deleted!");

            return ModelState.IsValid ? null : Json(ModelState.ToDataSourceResult());
        }

        public ViewResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View(new ProductModel());
            }

            ProductDTO productDto = service.Get(id.Value);
            return View(mapper.Map(productDto, new ProductModel()));
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
            
            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult DeleteSelected(IEnumerable<ProductModel> selectedProducts)
        {
            service.Delete(selectedProducts.Select((p, index) => p.Id));

            //ModelState.AddModelError("Product", "Product could not be deleted!");

            return ModelState.IsValid ? null : Json(ModelState.ToDataSourceResult());
        }
    }
}