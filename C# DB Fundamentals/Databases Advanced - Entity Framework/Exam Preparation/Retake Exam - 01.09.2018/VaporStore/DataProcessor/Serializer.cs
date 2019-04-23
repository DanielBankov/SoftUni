namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
            .Where(x => genreNames.Contains(x.Name))
            .Select(e => new
            {
                Id = e.Id,
                Genre = e.Name,
                Games = e.Games
                .Where(p => p.Purchases.Any())
                .Select(g => new
                {
                    Id = g.Id,
                    Title = g.Name,
                    Developer = g.Developer.Name,
                    Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)), //ToArray
                    Players = g.Purchases.Count
                })
                .OrderByDescending(p => p.Players)
                .ThenBy(p => p.Id)
                .ToArray(),
                TotalPlayers = e.Games.Sum(p => p.Purchases.Count)

            })
            .OrderByDescending(p => p.TotalPlayers)
            .ThenBy(p => p.Id)
            .ToArray();

            var jsonResult = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var enumType = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Select(x => new UserDto
                {
                    Username = x.Username,
                    Purchase = x.Cards
                    .SelectMany(p => p.Purchases)
                    .Where(t => t.Type == enumType)
                    .Select(e => new PurchaseDto
                    {
                        Card = e.Card.Number,
                        Cvc = e.Card.Cvc,
                        Date = e.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture),
                        Game = new GameDto
                        {
                            Genre = e.Game.Genre.Name,
                            Title = e.Game.Name,
                            Price = e.Game.Price
                        }
                    })
                       .OrderBy(d => d.Date)
                       .ToArray(),
                    TotalSpent = x.Cards.SelectMany(c => c.Purchases)
                    .Where(t => t.Type == enumType)
                    .Sum(s => s.Game.Price)
                    

                })
                .Where(p => p.Purchase.Any())
                .OrderByDescending(t => t.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}