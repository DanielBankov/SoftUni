namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            var sb = new StringBuilder();
            var games = new List<Game>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = GetCreateDeveloper(context, gameDto.Developer);
                var genre = GetCreateGenre(context, gameDto.Genre);
                var tags = GetCreateTag(context, gameDto.Tags); /// make foreach here and del for loop in method

                game.Developer = developer;
                game.Genre = genre;

                foreach (var tag in tags)
                {
                    game.GameTags.Add(new GameTag
                    {
                        //Game = game
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static List<Tag> GetCreateTag(VaporStoreDbContext context, List<string> tagsDto)
        {
            var validTags = new List<Tag>();

            for (int i = 0; i < tagsDto.Count; i++)
            {
                var tag = context.Tags.FirstOrDefault(e => e.Name == tagsDto[i]);

                if (tag == null)
                {
                    tag = new Tag
                    {
                        Name = tagsDto[i]
                    };

                    context.Tags.Add(tag);
                    context.SaveChanges();
                }

                validTags.Add(tag);
            }

            return validTags;
        }

        private static Genre GetCreateGenre(VaporStoreDbContext context, string genreDto)
        {
            var genre = context.Genres.FirstOrDefault(e => e.Name == genreDto);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreDto
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetCreateDeveloper(VaporStoreDbContext context, string gameDto)
        {
            var developer = context.Developers.FirstOrDefault(e => e.Name == gameDto);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDto
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }


        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var sb = new StringBuilder();
            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if(!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                // for try parse enum https://youtu.be/r64cTNex5oQ?t=5763

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidEnum = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card); 

                if(game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture),
                    ProductKey = purchaseDto.Key,
                    Game = game,
                    Card = card,
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);
            return isValid;
        }
    }
}