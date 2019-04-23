using System;

namespace _02._SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine();
            var town = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            if (product == "coffee")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(0.5 * quantity);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(0.4 * quantity);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(0.45 * quantity);
                }
            }
            else if (product == "water")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(0.8 * quantity);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(0.7 * quantity);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(0.7 * quantity);
                }
            }
            else if (product == "beer")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(1.20 * quantity);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.15 * quantity);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(1.10 * quantity);
                }
            }
            else if (product == "sweets")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(1.45 * quantity);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.30 * quantity);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(1.35 * quantity);
                }
            }
            else if (product == "peanuts")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(1.60 * quantity);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.50 * quantity);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(1.55 * quantity);
                }
            }
        }
    }
}
