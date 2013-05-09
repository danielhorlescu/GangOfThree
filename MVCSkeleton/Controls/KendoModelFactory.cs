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
                            Name = "Gula Malacca",
                            Code = "GM",
                            UnitPrice = 2.33
                        },
                    new ProductModel
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Sirop d'érable",
                            Code = "SDE",
                            UnitPrice = 3.45
                        },
                    new ProductModel
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Gravad lax",
                            Code = "GL",
                            UnitPrice = 5.77
                        },
                    new ProductModel
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Konbu",
                            Code = "KB",
                            UnitPrice = 10.27
                        },
                    new ProductModel
                        {
                            Id = 5,
                            CategoryId = 3,
                            Name = "Alice Mutton",
                            Code = "AM",
                            UnitPrice = 9.86
                        },
                    new ProductModel
                        {
                            Id = 6,
                            CategoryId = 3,
                            Name = "Pâté chinois",
                            Code = "PC",
                            UnitPrice = 21.43
                        },
                    new ProductModel
                        {
                            Id = 7,
                            CategoryId = 4,
                            Name = "Tunnbröd",
                            Code = "TB",
                            UnitPrice = 1.13
                        },
                    new ProductModel
                        {
                            Id = 8,
                            CategoryId = 4,
                            Name = "Ravioli Angelo",
                            Code = "RA",
                            UnitPrice = 4.89
                        },
                }
            };

            return model;
        }
    }
}