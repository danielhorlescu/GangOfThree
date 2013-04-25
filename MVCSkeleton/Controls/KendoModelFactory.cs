using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSkeleton.Models;

namespace MVCSkeleton.Controls
{
    public static class KendoModelFactory
    {

        public static KendoModel CreateModel()
        {
            KendoModel model = new KendoModel();

            model.Categories = new List<CategoryModel>()
            {
                new CategoryModel(){Id = 1, Name = "Condiments"},
                new CategoryModel(){Id = 2, Name = "SeaFood"},
                new CategoryModel(){Id = 3, Name = "Meat/Poultry"},
                new CategoryModel(){Id = 4, Name = "Grains/Cereals"}
            };

            model.Countries = new List<string>()
            {
                "Albania",
                "Andorra",
                "Armenia",
                "Austria",
                "Azerbaijan",
                "Belarus",
                "Belgium",
                "Bosnia & Herzegovina",
                "Bulgaria",
                "Croatia",
                "Cyprus",
                "Czech Republic",
                "Denmark",
                "Estonia",
                "Finland",
                "France",
                "Georgia",
                "Germany",
                "Greece",
                "Hungary",
                "Iceland",
                "Ireland",
                "Italy",
                "Kosovo",
                "Latvia",
                "Liechtenstein",
                "Lithuania",
                "Luxembourg",
                "Macedonia",
                "Malta",
                "Moldova",
                "Monaco",
                "Montenegro",
                "Netherlands",
                "Norway",
                "Poland",
                "Portugal",
                "Romania",
                "Russia",
                "San Marino",
                "Serbia",
                "Slovakia",
                "Slovenia",
                "Spain",
                "Sweden",
                "Switzerland",
                "Turkey",
                "Ukraine",
                "United Kingdom",
                "Vatican City"
            };

            model.Fabrics = new List<string>()
            {
                "Cotton",
                "Polyester",
                "Cotton/Polyester",
                "Rib Knit"
            };

            model.Products = new List<ProductModel>()
            {
                new ProductModel(){ Id = 1, ProductName = "Product 1", ProductCode = "P1", UnitPrice = 2.33},
                new ProductModel(){ Id = 2, ProductName = "Product 2", ProductCode = "P2", UnitPrice = 3.45},
                new ProductModel(){ Id = 3, ProductName = "Product 3", ProductCode = "P3", UnitPrice = 5.77},
            };

            return model;
        }
    }
}