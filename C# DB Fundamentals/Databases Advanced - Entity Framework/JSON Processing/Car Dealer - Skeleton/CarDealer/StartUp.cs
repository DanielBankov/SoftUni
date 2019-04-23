using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            var jsonText = File.ReadAllText(@"D:..\..\..\..\CarDealer\Datasets\sales.json");

            var result = GetTotalSalesByCustomer(context);
            Console.WriteLine(result);
        }

        /// <summary>
        /// 19. Export Sales With Applied Discount 
        /// </summary>
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesDiscount = context.Sales
               .Take(10)
               .Select(s => new
               {
                   car = new
                   {
                       Make = s.Car.Make,
                       Model = s.Car.Model,
                       TravelledDistance = s.Car.TravelledDistance
                   },

                   customerName = s.Customer.Name,
                   Discount = $"{s.Discount:f2}",
                   price = $"{s.Car.PartCars.Sum(p => p.Part.Price):f2}",
                   priceWithDiscount = $"{Math.Abs((s.Car.PartCars.Sum(p => p.Part.Price) * (s.Discount / 100)) -s.Car.PartCars.Sum(p => p.Part.Price)):f2}"
               })
               .ToList();

            var json = JsonConvert.SerializeObject(salesDiscount, Formatting.Indented);

            return json;
        }

        /// <summary>
        /// 18. Export Total Sales By Customer 
        /// </summary>
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(e => e.Sales.Any())
                .Select(e => new
                {
                    fullName = e.Name,
                    boughtCars = e.Sales.Count,
                    spentMoney = e.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(e => e.spentMoney)
                .ThenByDescending(e => e.boughtCars)
                .ToList();

            var jsonCars = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsonCars;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var allcars = context.Cars
                .Select(e => new
                {
                    car = new
                    {
                        Make = e.Make,
                        Model = e.Model,
                        TravelledDistance = e.TravelledDistance
                    },

                    parts = e.PartCars.Select(x => new
                    {
                        Name = x.Part.Name,
                        Price = $"{x.Part.Price:f2}"
                    })
                    .ToArray()

                })
                .ToArray();

            var jsonCars = JsonConvert.SerializeObject(allcars, Formatting.Indented);
            return jsonCars;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(e => !e.IsImporter)
                .Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    PartsCount = e.Parts.Count
                })
                .ToArray();

            var jsonCars = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return jsonCars;
        }

        /// <summary>
        /// 15. Export Cars From Make Toyota 
        /// </summary>
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var allCars = context.Cars
                .Where(e => e.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(e => new
                {
                    Id = e.Id,
                    Make = e.Make,
                    Model = e.Model,
                    TravelledDistance = e.TravelledDistance
                })
                .ToArray();

            var jsonCars = JsonConvert.SerializeObject(allCars, Formatting.Indented);
            return jsonCars;
        }

        /// <summary>
        /// 14. Export Ordered Customers 
        /// </summary>
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(e => e.BirthDate)
                .ThenBy(e => e.IsYoungDriver)
                .Select(e => new
                {
                    Name = e.Name,
                    BirthDate = e.BirthDate.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = e.IsYoungDriver
                })
                .ToArray();

            var jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsonCustomers;
        }


        /// <summary>
        /// 13. Import Sales 
        /// </summary>
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            //TODO: check if carId and CustomerId exists
            var jsonSales = JsonConvert.DeserializeObject<Sale[]>(inputJson).ToArray();

            context.Sales.AddRange(jsonSales);
            var affectedRows = context.SaveChanges();
            return $"Successfully imported {affectedRows}."; ;
        }

        /// <summary>
        /// 12. Import Customers 
        /// </summary>
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var jsonCustomers = JsonConvert.DeserializeObject<Customer[]>(inputJson).ToArray();

            context.Customers.AddRange(jsonCustomers);
            var affectedRows = context.SaveChanges();
            return $"Successfully imported {affectedRows}."; ;
        }

        /// <summary>
        /// 11. Import Cars 
        /// </summary>
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var jsonCars = JsonConvert.DeserializeObject<CarImportDto[]>(inputJson);
            var mappedCars = new List<Car>();

            foreach (var car in jsonCars)
            {
                var mappedCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                var partsIds = car.PartsId.Distinct().ToList();

                foreach (var partId in partsIds)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId
                    };

                    mappedCar.PartCars.Add(partCar);
                }

                mappedCars.Add(mappedCar);
            }

            context.Cars.AddRange(mappedCars);
            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count}.";
        }

        /// <summary>
        /// 10. Import Parts
        /// </summary>
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsDeserialize = JsonConvert.DeserializeObject<Part[]>(inputJson).ToArray();

            var exsistedSuppliersIds = context.Suppliers.Select(e => e.Id).ToHashSet();

            var validEntities = new List<Part>();

            foreach (var part in partsDeserialize)
            {
                bool isValid = exsistedSuppliersIds.Contains(part.SupplierId);

                if (isValid)
                {
                    validEntities.Add(part);
                }
            }

            context.Parts.AddRange(validEntities);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        /// <summary>
        /// 09. Import Suppliers 
        /// </summary>
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var inportSuppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(inportSuppliers);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }
    }
}