using System;

namespace _03._Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mile = decimal.Parse(Console.ReadLine());

            decimal sum = 1.60934m * mile;

            Console.WriteLine($"{sum:F2}");
        }
    }
}
