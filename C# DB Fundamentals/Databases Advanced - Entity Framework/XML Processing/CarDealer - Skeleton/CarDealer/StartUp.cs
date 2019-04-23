using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                //TODO : Add mode tex file reades
                //var text = File.ReadAllText(@"D:..\..\..\..\CarDealer\Datasets\sales.xml");

                var result = GetLocalSuppliers(context);
                Console.WriteLine(result);
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
            .Select(x => new ExportSaleDiscountDto()
            {
                Car = new CarDto()
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance
                },
                Discount = x.Discount,
                CustomerName = x.Customer.Name,
                Price = x.Car.PartCars.Sum(y => y.Part.Price),
                PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100m))
            })
            .ToArray();


            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDiscountDto[]), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 18. Export Total Sales By Customer
        /// </summary>
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(e => new ExportCustomerstDto
                {
                    FullName = e.Name,
                    BoughtCars = e.Sales.Count,
                    SpentMoney = e.Sales.Sum(s => s.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerstDto[]), new XmlRootAttribute
            ("customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 17. Export Cars With Their List Of Parts 
        /// </summary>
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carParts = context.Cars
                .Select(e => new ExportCarAndParts
                {
                    Make = e.Make,
                    Model = e.Model,
                    DistanceTraveld = e.TravelledDistance,
                    Parts = e.PartCars.Select(x => new ExportCarPart
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price
                    })
                      .OrderByDescending(p => p.Price)
                      .ToArray()
                })
                .OrderByDescending(t => t.DistanceTraveld)
                .ThenBy(m => m.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarAndParts[]), new XmlRootAttribute
            ("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carParts, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 16. Export Local Suppliers 
        /// </summary>
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute
             ("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 15. Export Cars From Make BMW 
        /// </summary>
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(d => new ExportCarMakeDto
                {
                    Id = d.Id,
                    Model = d.Model,
                    Distance = d.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.Distance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarMakeDto[]), new XmlRootAttribute
             ("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 14. Export Cars With Distance
        /// </summary>
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(d => d.TravelledDistance > 2000000)
                .Select(e => new ExportCarDto
                {
                    Make = e.Make,
                    Model = e.Model,
                    DistanceTraveld = e.TravelledDistance
                })
                .OrderBy(e => e.Make)
                .ThenBy(e => e.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute
               ("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 13. Import Sales 
        /// </summary>
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carsId = context.Cars.Select(e => e.Id).ToArray();
            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (!carsId.Contains(saleDto.CarId))
                {
                    continue;
                }

                var sale = new Sale
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        /// <summary>
        /// 12. Import Customers
        /// </summary>
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = DateTime.ParseExact(customerDto.BirthDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.CurrentCulture),
                    IsYoungDriver = customerDto.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        /// <summary>
        /// 11. Import Cars 
        /// </summary>
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var partsIds = context.Parts.Select(e => e.Id).ToArray();

            bool isValid = true;
            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelDistance,
                    //PartCars = carDto.Parts.Select(x => new PartCar
                    //{
                    //    PartId = x.Id
                    //})
                    // .ToArray()
                };

                var partsDtoId = carDto.Parts.Select(x => x.Id).Distinct().ToList();

                foreach (var part in partsDtoId)
                {
                    if (!partsIds.Contains(part))
                    {
                        isValid = false;
                        break;
                    }

                    var partCar = new PartCar
                    {
                        Car = car,
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                if (isValid == false)
                {
                    continue;
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        /// <summary>
        /// 10. Import Parts 
        /// </summary>
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliersIds = context.Suppliers.Select(e => e.Id).ToArray();

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                if (!suppliersIds.Contains(partDto.SupplierId))
                {
                    continue;
                }

                var part = new Part
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        /// <summary>
        /// 09. Import Suppliers 
        /// </summary>
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImported
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
    }
}