using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class StoreController : Controller
    {
        private StoreGridModel _model;

        public StoreController()
        {
            _model = new StoreGridModel();
            _model.StoreModels = new List<StoreModel>();
        }

        public ActionResult Index()
        {
            return View("Store", _model);
        }

        public ActionResult Stores_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(_model.StoreModels.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Create([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            return Json(new[] { store }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Product_Update([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            return Json(_model.StoreModels.ToDataSourceResult(dsRequest));
        }

        public ActionResult Product_Delete([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            return Json(ModelState.ToDataSourceResult());
        }

        //[HttpPost]
        //public ActionResult Submit(string countries, string shirtFabric, DateTime dateTimePicker, string categories, double percentage)
        //{
        //    return View("Store", _model);
        //}
        
    }
}
