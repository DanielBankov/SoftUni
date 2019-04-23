namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
            }
        }

        /// <summary>
        /// 15. Remove Books 
        /// </summary>
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var affectedRows = books.Count;

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return affectedRows;
        }

        /// <summary>
        /// 14. Increase Prices 
        /// </summary>
        public static void IncreasePrices(BookShopContext context)
        {
           var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.Books.UpdateRange(books);
            context.SaveChanges();
        }

        /// <summary>
        /// 13. Most Recent Books 
        /// </summary>
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    //.Take(3) DON`T take some count here because this will sent too many requests to DB
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books.Take(3)) // take count here
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 12. Profit by Category 
        /// </summary>
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Sum = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(s => s.Sum)
                .ThenBy(n => n.Name)
                .ToList();

            var result = string.Join(Environment.NewLine, categories.Select(e => $"{e.Name} ${e.Sum:f2}"));
            return result;
        }

        /// <summary>
        /// 11. Total Book Copies 
        /// </summary>
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var booksCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(s => s.Copies)
                })
                .OrderByDescending(c => c.Copies)
                .ToList();

            var result = string.Join(Environment.NewLine, booksCopies.Select(c => $"{c.FirstName} {c.LastName} - {c.Copies}"));
            return result;
        }

        /// <summary>
        /// 10. Count Books 
        /// </summary>
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        /// <summary>
        /// 09. Book Search by Author 
        /// </summary>
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookAuthor = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName, $"{input}%"))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName })
                .ToList();

            var result = string.Join(Environment.NewLine, bookAuthor.Select(b => $"{b.Title} ({b.FirstName} {b.LastName})"));
            return result;
        }

        /// <summary>
        /// 08. Book Search 
        /// </summary>
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitle = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, bookTitle);
            return result;
        }

        /// <summary>
        /// 07. Author Search 
        /// </summary>
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var fullNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + ' ' + a.LastName)
                .OrderBy(x => x);

            var result = string.Join(Environment.NewLine, fullNames);
            return result;
        }

        /// <summary>
        /// 06. Released Before Date 
        /// </summary>
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedData = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture);

            //.ReleaseDate.Value because it can be null.
            var books = context.Books
                .Where(b => b.ReleaseDate.Value < parsedData)
                .OrderByDescending(x => x.ReleaseDate.Value)
                .Select(x => new { x.Title, x.EditionType, x.Price })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
            return result;
        }

        /// <summary>
        /// 05. Book Titles by Category 
        /// </summary>
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var categoryBooks = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, categoryBooks);
            return result;
        }

        /// <summary>
        /// 04. Not Released In 
        /// </summary>
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleaseOnYear = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, notReleaseOnYear);
            return result;
        }

        /// <summary>
        /// 03. Books by Price 
        /// </summary>
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
            return result;
        }

        /// <summary>
        /// 02. Golden Books 
        /// </summary>
        public static string GetGoldenBooks(BookShopContext context)
        {
            var editionType = Enum.Parse<EditionType>("Gold");

            var goldenBooks = context.Books
                .Where(e => e.EditionType == editionType && e.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenBooks);
            return result;
        }

        /// <summary>
        /// 01. Age Restriction 
        /// </summary>
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Where(t => t.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }
    }
}
