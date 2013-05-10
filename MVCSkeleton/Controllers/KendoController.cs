using System;
using System.Linq;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using MVCSkeleton.Presentation.Controls;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class KendoController : Controller
    {
        private readonly KendoModel _model;

        public KendoController()
        {
            _model = KendoModelFactory.CreateModel();
        }

        public ActionResult Index()
        {
            return View("KendoDemo", _model);
        }

        public ActionResult GetCascadeProducts(Guid categoryId)
        {
            return Json(_model.Products.Where(p => p.CategoryId == categoryId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(_model.Products.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Create([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(new[] { product }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Update([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(_model.Products.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Delete([DataSourceRequest] DataSourceRequest dsRequest, ProductModel product)
        {
            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPost]
        public ActionResult Submit(string countries, string shirtFabric, DateTime dateTimePicker, string categories, double percentage)
        {
            return View("KendoDemo", _model);
        }
    }
}
