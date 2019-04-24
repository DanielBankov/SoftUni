using System;

namespace _06._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (age > 63 && age <= 122 && day == "Weekday")
            {
                price = 12;
            }
            else if (age > 64 && age <= 122 && day == "Weekend")
            {
                price = 15;
            }
            else if (age > 64 && age <= 122 && day == "Holiday")
            {
                price = 10;
            }

            else if (age > 18 && age <= 64 && day == "Weekday")
            {
                price = 18;
            }
            else if (age > 18 && age <= 64 && day == "Weekend")
            {
                price = 20;
            }
            else if (age > 18 && age <= 64 && day == "Holiday")
            {
                price = 12;
            }

            else if (age >= 0 && age <= 18 && day == "Weekday")
            {
                price = 12;
            }
            else if (age >= 0 && age <= 18 && day == "Weekend")
            {
                price = 15;
            }
            else if (age >= 0 && age <= 18 && day == "Holiday")
            {
                price = 5;
            }
            else
            {
                Console.WriteLine("Error!");
                return;
            }

            Console.WriteLine($"{price}$");
        }
    }
}
