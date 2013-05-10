using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _service;
        private readonly StoreGridModel _model;

        public StoreController(IStoreService service)
        {
            _service = service;
            _model = new StoreGridModel {StoreModels = _service.GetAllStores()};
        }

        public ActionResult Index()
        {
            return View("Store", _model);
        }

        public ActionResult Stores_Read([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            return Json(_model.StoreModels.ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Create([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new StoreDTO { Email = store.Email, Name = store.Name});
            }
            return Json(new[] { store }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Store_Update([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {
            return Json(_model.StoreModels.ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Delete([DataSourceRequest] DataSourceRequest dsRequest, StoreModel store)
        {

            if (store!=null)
            {
                _service.Delete(store.Id);
            }
            return Json(ModelState.ToDataSourceResult(dsRequest));
        }

        public ViewResult GetAllStores()
        {
            List<StoreDTO> storeList = _service.GetAllStores();            
            return View("Store", new StoreGridModel {StoreModels = storeList});
        }
    }
}
