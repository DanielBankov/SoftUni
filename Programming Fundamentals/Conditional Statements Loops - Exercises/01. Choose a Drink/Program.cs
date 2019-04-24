using System;

namespace _01._Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine().ToLower();

            if (profession == "athlete")
            {
                Console.WriteLine("Water");
            }
            else if (profession == "businessman" || profession == "businesswomen")
            {
                Console.WriteLine("Coffee");
            }
            else if (profession == "softuni student")
            {
                Console.WriteLine("Beer");
            }
            else
            {
                Console.WriteLine("Tea");
            }
        }
    }
}
