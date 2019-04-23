using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //var jsonText = File.ReadAllText(@"D:..\..\..\..\ProductShop\Datasets\categories-products.json");

            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 08. Export Users and Products 
        /// </summary>
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(e => e.ProductsSold.Any(x => x.BuyerId != null))
                .OrderByDescending(e => e.ProductsSold.Count(ps => ps.BuyerId != null))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Age = e.Age,
                    SoldProducts = new
                    {
                        Count = e.ProductsSold.Count(ps => ps.BuyerId != null),
                        Products = e.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })  
                    .ToArray()
                    }

                })
                .ToArray();

            var result = new
            {
                UsersCount = usersWithProducts.Length,
                Users = usersWithProducts,
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var serialized = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver, // all objects are CamelCase
                Formatting = Formatting.Indented, // readable format
                NullValueHandling = NullValueHandling.Ignore //ignore nulls

            });

            return serialized;
        }


        /// <summary>
        /// 07. Export Categories By Products Count
        /// </summary>
        public static string GetCategoriesByProductsCount(ProductShopContext context)
            {
                var categories = context.Categories
                    .Select(e => new CategoriesDto
                    {
                        Name = e.Name,
                        ProcuctsCount = e.CategoryProducts.Count,
                        AveragePrice = Math.Round(e.CategoryProducts.Average(s => s.Product.Price), 2).ToString(),
                        Revenue = e.CategoryProducts.Sum(s => s.Product.Price).ToString()
                    })
                    .OrderByDescending(x => x.ProcuctsCount)
                    .ToArray();

                var exportCatedories = JsonConvert.SerializeObject(categories, Formatting.Indented);
                return exportCatedories;
            }

            /// <summary>
            /// 06. Export Sold Products
            /// </summary>
            public static string GetSoldProducts(ProductShopContext context)
            {
                var soldProducts = context.Users
                    .Where(e => e.ProductsSold.Any(x => x.BuyerId != null))
                    .Select(e => new SellerDto()
                    {
                        SellerFirstName = e.FirstName,
                        SellerLastName = e.LastName,

                        SoldProducts = e.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new SoldProductsDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                    })
                    .OrderBy(x => x.SellerLastName)
                    .ThenBy(x => x.SellerFirstName)
                    .ToList();

                var jsonSoldProducts = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
                return jsonSoldProducts;
            }

            /// <summary>
            /// 05. Export Products In Range 
            /// </summary>
            public static string GetProductsInRange(ProductShopContext context)
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Select(e => new ProductDto
                    {
                        Name = e.Name,
                        Price = e.Price,
                        Seller = $"{e.Seller.FirstName} {e.Seller.LastName}"
                    })
                    .OrderBy(x => x.Price)
                    .ToArray();

                var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
                return jsonProducts;
            }

            /// <summary>
            /// 04. Import Categories and Products 
            /// </summary>
            public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
            {
                var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson).ToArray();

                context.CategoryProducts.AddRange(categoryProducts);
                var affectedRows = context.SaveChanges();

                return $"Successfully imported {affectedRows}";
            }

            /// <summary>
            /// 03. Import Categories 
            /// </summary>
            public static string ImportCategories(ProductShopContext context, string inputJson)
            {
                var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                    .Where(x => x.Name != null && x.Name.Trim().Length >= 3 && x.Name.Trim().Length <= 15).ToArray();

                context.Categories.AddRange(categories);
                var affectedRows = context.SaveChanges();

                return $"Successfully imported {affectedRows}";
            }

            /// <summary>
            /// 02. Import Products 
            /// </summary>
            public static string ImportProducts(ProductShopContext context, string inputJson)
            {
                var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                    .Where(x => x.Name != null && x.Name.Trim().Length >= 3).ToArray();

                context.Products.AddRange(products);
                var affectedRows = context.SaveChanges();

                return $"Successfully imported {affectedRows}";
            }

            /// <summary>
            /// 01.	Import Users 
            /// </summary>
            public static string ImportUsers(ProductShopContext context, string inputJson)
            {
                var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                    .Where(x => x.LastName != null && x.LastName.Trim().Length >= 3).ToArray();

                context.Users.AddRange(users);
                var affectedRows = context.SaveChanges();

                return $"Successfully imported {affectedRows}"; 
            }
        }
    }