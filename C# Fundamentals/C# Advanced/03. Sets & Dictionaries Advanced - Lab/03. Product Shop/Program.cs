using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> dict = new SortedDictionary<string, Dictionary<string, double>>();
            string[] inputInfo = Console.ReadLine().Split(", ").ToArray();

            while (inputInfo[0] != "Revision")
            {
                string shop = inputInfo[0];
                string product = inputInfo[1];
                double price = double.Parse(inputInfo[2]);

                if (!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                    dict[shop].Add(product, price);
                }
                else if (!dict[shop].ContainsKey(product))
                {
                    dict[shop].Add(product, price);
                }

                inputInfo = Console.ReadLine().Split(", ").ToArray();
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
