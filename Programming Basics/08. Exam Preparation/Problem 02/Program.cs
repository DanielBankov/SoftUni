using System;

namespace Problem_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string route = Console.ReadLine().ToLower();

            decimal sum = 0.0m;

            switch (route)
            {
                case "trail": sum = (juniors * 5.5m) + (seniors * 7m);
                    break;
                case "cross-country":sum = (juniors * 8m) + (seniors * 9.5m);
                    if (juniors + seniors >= 50)
                    {
                        sum = (sum * 0.25m) - sum;
                    }
                    break;
                case "dawnhill":sum = (juniors * 12.25m) + (seniors * 13.75m);
                    break;
                case "roud": sum = (juniors * 20m) + (seniors * 21.5m);
                    break;
            }

            decimal cost = (sum * 0.05m) - sum;

            Console.WriteLine($"{Math.Abs(cost):f2}");
        }
    }
}
