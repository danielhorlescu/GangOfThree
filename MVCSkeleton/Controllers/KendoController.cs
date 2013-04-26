using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCSkeleton.Controls;
using MVCSkeleton.Models;

namespace MVCSkeleton.Controllers
{
    public class KendoController : Controller
    {
        private KendoModel model;

        public KendoController()
        {
            model = KendoModelFactory.CreateModel();
        }

        public ActionResult Index()
        {
            return View("KendoDemo", model);
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(model.Products.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Create([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(new[] { product }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Update([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(model.Products.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Delete([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPost]
        public ActionResult Submit(string Countries, string TShirtFabric, DateTime DateTimePicker, string Categories)
        {
            return View("KendoDemo", this.model);
        }
    }
}
