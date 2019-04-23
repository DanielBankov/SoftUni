using System;

namespace Problem_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string route = Console.ReadLine().ToLower();

            double sum = 0;
            double costs = 0; 

            if(route == "trail")
            {
                sum = (juniors * 5.5) + (seniors * 7);
            }
            else if (route == "cross-country")
            {
                sum = (juniors * 8) + (seniors * 9.5);

                if(juniors + seniors >= 50)
                {
                    sum = (sum * 0.25) - sum;
                }
            }
            else if (route == "downhill")
            {
                sum = (juniors * 12.25) + (seniors * 13.75);
            }
            else if (route == "road")
            {
                sum = (juniors * 20) + (seniors * 21.5);
            }

            costs = (sum * 0.05) - sum;

            Console.WriteLine($"{Math.Abs(costs):f2}");
        }
    }
}
