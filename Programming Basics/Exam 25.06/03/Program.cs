using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string coctailSize = Console.ReadLine().ToLower();
            int numberOfCoctails = int.Parse(Console.ReadLine());

            double litter = 0;
            double priceOfCoctails = 0;

            if (coctailSize == "small")
            {
                if (fruit == "watermelon")
                {
                    litter = 56;
                }
                else if (fruit == "mango")
                {
                    litter = 36.66;
                }
                else if (fruit == "pineapple")
                {
                    litter = 42.10;
                }
                else if (fruit == "raspberry")
                {
                    litter = 20;
                }
                priceOfCoctails = 2 * litter;
            }
            else if (coctailSize == "big")
            {
                if (fruit == "watermelon")
                {
                    litter = 28.70;
                }
                else if (fruit == "mango")
                {
                    litter = 19.60;
                }
                else if (fruit == "pineapple")
                {
                    litter = 24.80;
                }
                else if (fruit == "raspberry")
                {
                    litter = 15.20;
                }
                priceOfCoctails = 5 * litter;
            }


            double price = priceOfCoctails * numberOfCoctails;

            if(price >= 400 && price <= 1000)
            {
                price = price - (price * 0.15);
            }
            else if (price > 1000)
            {
                price = price / 2.0;

            }

            Console.WriteLine($"{Math.Abs(price):f2} lv.");

        }
    }
}
