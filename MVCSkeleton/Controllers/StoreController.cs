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
    public class StoreController : Controller
    {
        private readonly IStoreService service;
        private readonly IMapper mapper;

        public StoreController(IStoreService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var storeDtos = service.GetAllStores();
            var storeModels = mapper.Map(storeDtos, new List<StoreModel>());
            return View("Store", storeModels);
        }

        public ActionResult Stores_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(service.GetAllStores().ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Create([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<StoreModel> stores)
        {
            var store = stores.First();
            service.Create(mapper.Map(store, new StoreDTO()));

            return Json(new[] { store }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Store_Update([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<StoreModel> stores)
        {
            var storeModel = stores.First();
            var target = mapper.Map(storeModel, new StoreDTO());
            service.Update(target);

            return Json(service.GetAllStores().ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Delete([Bind(Prefix = "models")] IEnumerable<StoreModel> stores)
        {
            var storeModel = stores.First();
            service.Delete(storeModel.Id);

            return ModelState.IsValid ? null : Json(ModelState.ToDataSourceResult());
        }
       
    }
}
