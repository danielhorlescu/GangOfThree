using System.Collections.Generic;

using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controls
{
    public static class KendoModelFactory
    {
        public static KendoModel CreateModel()
        {
            var model = new KendoModel
            {
                Countries = new List<string>
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
                },
                Fabrics = new List<string>
                    {
                    "Cotton",
                    "Polyester",
                    "Cotton/Polyester",
                    "Rib Knit"
                },
                Categories = new List<CategoryModel>
                    {
                    new CategoryModel {Id = 1, Name = "Condiments"},
                    new CategoryModel {Id = 2, Name = "SeaFood"},
                    new CategoryModel {Id = 3, Name = "Meat/Poultry"},
                    new CategoryModel {Id = 4, Name = "Grains/Cereals"}
                },
                Products = new List<ProductModel>
                {
                    new ProductModel
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductName = "Gula Malacca",
                            ProductCode = "GM",
                            UnitPrice = 2.33
                        },
                    new ProductModel
                        {
                            Id = 2,
                            CategoryId = 1,
                            ProductName = "Sirop d'érable",
                            ProductCode = "SDE",
                            UnitPrice = 3.45
                        },
                    new ProductModel
                        {
                            Id = 3,
                            CategoryId = 2,
                            ProductName = "Gravad lax",
                            ProductCode = "GL",
                            UnitPrice = 5.77
                        },
                    new ProductModel
                        {
                            Id = 4,
                            CategoryId = 2,
                            ProductName = "Konbu",
                            ProductCode = "KB",
                            UnitPrice = 10.27
                        },
                    new ProductModel
                        {
                            Id = 5,
                            CategoryId = 3,
                            ProductName = "Alice Mutton",
                            ProductCode = "AM",
                            UnitPrice = 9.86
                        },
                    new ProductModel
                        {
                            Id = 6,
                            CategoryId = 3,
                            ProductName = "Pâté chinois",
                            ProductCode = "PC",
                            UnitPrice = 21.43
                        },
                    new ProductModel
                        {
                            Id = 7,
                            CategoryId = 4,
                            ProductName = "Tunnbröd",
                            ProductCode = "TB",
                            UnitPrice = 1.13
                        },
                    new ProductModel
                        {
                            Id = 8,
                            CategoryId = 4,
                            ProductName = "Ravioli Angelo",
                            ProductCode = "RA",
                            UnitPrice = 4.89
                        },
                }
            };

            return model;
        }
    }
}