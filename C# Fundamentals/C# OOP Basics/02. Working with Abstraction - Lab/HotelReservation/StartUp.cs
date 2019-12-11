using System;

namespace HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            if(input.Length == 4)
            {
                decimal price = decimal.Parse(input[0]);
                int days = int.Parse(input[1]);
                var season = input[2];
                var discount = input[3];

                Enum.TryParse(season, out Seasons currSeason);
                Enum.TryParse(discount, out Discount currDiscount);

                var result = PriceCalcolator.Calculator(price, days, currSeason, currDiscount);
                Console.WriteLine($"{result:f2}");
            }
            else
            {
                decimal price = decimal.Parse(input[0]);
                int days = int.Parse(input[1]);
                var season = input[2];

                Enum.TryParse(season, out Seasons currSeason);

                var result = PriceCalcolator.Calculator(price, days, currSeason);
                Console.WriteLine($"{result:f2}");
            }
        }
    }
}
