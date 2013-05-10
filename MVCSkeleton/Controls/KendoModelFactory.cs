using System;
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
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("512B889C-E1A0-4730-8148-EE1ECBA1D612"),
                            Name = "Gula Malacca",
                            Code = "GM",
                            UnitPrice = 2.33
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("512B889C-E1A0-4730-8148-EE1ECBA1D612"),
                            Name = "Sirop d'érable",
                            Code = "SDE",
                            UnitPrice = 3.45
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("42E02996-DC3E-4017-BC43-051A8D310920"),
                            Name = "Gravad lax",
                            Code = "GL",
                            UnitPrice = 5.77
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("42E02996-DC3E-4017-BC43-051A8D310920"),
                            Name = "Konbu",
                            Code = "KB",
                            UnitPrice = 10.27
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("2BF62DD0-FC8C-4E35-B4F0-F9A23724DBF0"),
                            Name = "Alice Mutton",
                            Code = "AM",
                            UnitPrice = 9.86
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("2BF62DD0-FC8C-4E35-B4F0-F9A23724DBF0"),
                            Name = "Pâté chinois",
                            Code = "PC",
                            UnitPrice = 21.43
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("140526F3-DFA3-4F50-9976-7F84E4E47DA2"),
                            Name = "Tunnbröd",
                            Code = "TB",
                            UnitPrice = 1.13
                        },
                    new ProductModel
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("140526F3-DFA3-4F50-9976-7F84E4E47DA2"),
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