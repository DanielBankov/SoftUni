using System;
using System.Collections.Generic;

namespace _07._Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[input];

            for (int i = 0; i < input; i++)
            {
                sales[i] = ReadSale(Console.ReadLine());
            }

            SortedDictionary<string, decimal> dict = new SortedDictionary<string, decimal>();

            foreach (Sale sale in sales)
            {
                if (dict.ContainsKey(sale.Town))
                {
                    dict[sale.Town] += sale.Price * sale.Quantity;
                }
                else
                {
                    dict[sale.Town] = sale.Price * sale.Quantity;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:F2}");
            }
        }

        static Sale ReadSale(string input)
        {
            string[] tokens = input.Split(' ');
            return new Sale
            {
                Town = tokens[0],
                Product = tokens[1],
                Price = decimal.Parse(tokens[2]),
                Quantity = decimal.Parse(tokens[3])
            };
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
