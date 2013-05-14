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
    public class StoreController : Controller
    {
        private readonly IStoreService _service;
        private readonly StoreModel _model;
        private readonly IMapper _mapper;

        public StoreController(IStoreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var storeDtos = _service.GetAllStores();
            var storeModels = _mapper.Map(storeDtos, new List<StoreModel>());
            return View("Store", storeModels);
        }

        public ActionResult Stores_Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(_service.GetAllStores().ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Create([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] List<StoreModel> stores)
        {
            var store = stores[0];
            _service.Create(_mapper.Map(store, new StoreDTO()));

            return Json(new[] { store }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult Store_Update([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<StoreModel> stores)
        {
            foreach (var storeModel in stores)
            {
                var target = _mapper.Map(storeModel, new StoreDTO());
                _service.Update(target);
            }            

            return Json(_service.GetAllStores().ToDataSourceResult(dsRequest));
        }

        public ActionResult Store_Delete([DataSourceRequest] DataSourceRequest dsRequest, [Bind(Prefix = "models")] IEnumerable<StoreModel> stores)
        {
            foreach (var storeModel in stores)
            {
                _service.Delete(storeModel.Id);
            }
            
            return Json(ModelState.ToDataSourceResult(dsRequest));
        }

        public ViewResult GetAllStores()
        {
            List<StoreDTO> storeList = _service.GetAllStores();
            return View("Store", _mapper.Map(storeList, new List<StoreModel>()));
        }
    }
}
