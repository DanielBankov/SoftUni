using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Dtos.Export;
using System.Text;
using System.Xml;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            //var file = File.ReadAllText(@"D:..\..\..\..\ProductShop\Datasets\categories-products.xml");
            //todo add more files path

            using (var context = new ProductShopContext())
            {
                var result = GetCategoriesByProductsCount(context);

                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// 08. Export Users and Products 
        /// </summary>
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(e => new ExportUserAndProductDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Age = e.Age,
                    SoldProductsDto = new SoldProductDto
                    {
                        Count = e.ProductsSold.Count,
                        ProductsDto = e.ProductsSold.Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var customExport = new ExportCustomUserAndProductDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                ExportUserProducts = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserAndProductDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 07. Export Categories By Products Count
        /// </summary>
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(e => new CategoriesByProductsCountDto
                {
                    Name = e.Name,
                    Count = e.CategoryProducts.Count,
                    AveragePrice = e.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = e.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesByProductsCountDto[]), new XmlRootAttribute
               ("Categories"));

            //This removes xml namespaces
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
                //or new XmlQualifiedName("","")
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 06. Export Sold Products
        /// </summary>
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(p => p.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsDto = u.ProductsSold
                        .Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .ToArray()
                })
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]), new XmlRootAttribute
               ("Users"));

            //This removes xml namespaces
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
                //or new XmlQualifiedName("","")
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 05. Export Products In Range 
        /// </summary>
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(e => e.Price >= 500 && e.Price <= 1000)
                .Select(e => new ExportProductInRangeDto
                {
                    Name = e.Name,
                    Price = e.Price,
                    UserFullName = e.Buyer.FirstName + " " + e.Buyer.LastName //don't use $"{}"
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute
                ("Products"));

            var sb = new StringBuilder();

            //This removes xml namespaces
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 04. Import Categories and Products
        /// </summary>
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categorirsProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoriesProducts = new List<CategoryProduct>();

            var categoriesIds = context.Categories.Select(e => e.Id).ToArray();
            var productsIds = context.Products.Select(e => e.Id).ToArray();

            foreach (var cp in categorirsProductsDto)
            {
                bool isValidId = categoriesIds.Contains(cp.CategoryId) &&
                                 productsIds.Contains(cp.ProductId);

                if (!isValidId)
                {
                    continue;
                }

                // var product = context.Products.Find(cp.ProductId);
                // var category = context.Categories.Find(cp.CategoryId);
                //
                // if (product == null || category == null)
                // {
                //     continue;
                // }

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                };

                categoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        /// <summary>
        /// 03. Import Categories 
        /// </summary>
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var category in categoriesDto)
            {
                if (string.IsNullOrEmpty(category.Name))
                {
                    continue;
                }

                var categoryMap = new Category
                {
                    Name = category.Name
                };

                categories.Add(categoryMap);
            }

            context.Categories.AddRange(categories);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        /// <summary>
        /// 02. Import Products 
        /// </summary>
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var product in productsDto)
            {
                //ManualMapper
                var productMap = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    SellerId = product.SellerId,
                    BuyerId = product.BuyerId
                };

                products.Add(productMap);
            }

            context.Products.AddRange(products);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        /// <summary>
        /// 01.	Import Users 
        /// </summary>
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                //AutoMapper
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            var affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
    }
}