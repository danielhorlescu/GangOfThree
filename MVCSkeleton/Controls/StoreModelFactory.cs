using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controls
{
    public class StoreModelFactory
    {
        private static IStoreService storeService;

        public static void CreateModel()
        {
            var model = new StoreGridModel();
            IStoreService localstoreService = storeService;
            //model.StoreModels = localstoreService.GetAllStores();
        }
    }
}