using System;

namespace _08._TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double s = double.Parse(Console.ReadLine());
            var comission = 0.0;

            if (town == "sofia")
            {
                if (s >= 0 && s <= 500) 
                {
                    comission = 0.05;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 500 && s <= 1000)
                {
                    comission = 0.07;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 1000 && s <= 10000)
                {
                    comission = 0.08;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 10000)
                {
                    comission = 0.12;
                    Console.WriteLine(Math.Round(comission * s ,2));
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "varna")
            {
                if (s >= 0 && s <= 500)
                {
                    comission = 0.045;
                    Console.WriteLine(Math.Round(comission *s, 2));

                }
                else if (s > 500 && s <= 1000)
                {
                    comission = 0.075;
                    Console.WriteLine(Math.Round(comission *s, 2));
                }
                else if (s > 1000 && s <= 10000)
                {
                    comission = 0.10;
                    Console.WriteLine(Math.Round(comission *s, 2));
                }
                else if (s > 10000)
                {
                    comission = 0.13;
                    Console.WriteLine(Math.Round(comission *s, 2));
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "plovdiv")
            {
                if (s >= 0 && s <= 500)
                {
                    comission = 0.055;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 500 && s <= 1000)
                {
                    comission = 0.08;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 1000 && s <= 10000)
                {
                    comission = 0.12;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else if (s > 10000)
                {
                    comission = 0.145;
                    Console.WriteLine(Math.Round(comission * s, 2));
                }
                else
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
