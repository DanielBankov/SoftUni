using System;
using System.Globalization;

namespace _13._1000_Days_After_Birth
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate = Console.ReadLine();

            CultureInfo provider = CultureInfo.InvariantCulture;

            var exactDate = DateTime.ParseExact(inputDate, "dd-MM-yyyy", provider);

            var addedDays = exactDate.AddDays(999);

            var result = addedDays.ToString("dd-MM-yyyy");

            Console.WriteLine(result);
        }
    }
}
