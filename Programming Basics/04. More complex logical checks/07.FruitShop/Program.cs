using System;

namespace _07._FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            var delnichenDay = day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday";
            var weekDay = day == "saturday" || day == "sunday";

            if (delnichenDay)
            {
                if (fruit == "banana")
                {
                    Console.WriteLine(Math.Round(2.5 * quantity, 2));

                }
                else if (fruit == "apple")
                {
                    Console.WriteLine(Math.Round(1.2 * quantity, 2));
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine(Math.Round(0.85 * quantity, 2));
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine(Math.Round(1.45 * quantity, 2));
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine(Math.Round(2.70 * quantity, 2));
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine(Math.Round(5.5 * quantity, 2));
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine(Math.Round(3.85 * quantity, 2));
                }
                else
                {
                    Console.WriteLine("error");
                }

            } else if (weekDay)
            {
                if (fruit == "banana")
                {
                    Console.WriteLine(Math.Round(2.7 * quantity, 2));
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine(Math.Round(1.25 * quantity, 2));
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine(Math.Round(0.9 * quantity, 2));
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine(Math.Round(1.6 * quantity, 2));
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine(Math.Round(3 * quantity, 2));
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine(Math.Round(5.6 * quantity, 2));
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine(Math.Round(4.2 * quantity, 2));
                }else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
