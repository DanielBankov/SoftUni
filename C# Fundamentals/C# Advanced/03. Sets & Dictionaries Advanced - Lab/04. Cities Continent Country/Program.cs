using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_Continent_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" ").ToArray();

                string continent = inputInfo[0];
                string countries = inputInfo[1];
                string cities = inputInfo[2];

                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                    dict[continent].Add(countries, new List<string>());
                    dict[continent][countries].Add(cities);
                }
                else if (!dict[continent].ContainsKey(countries))
                {
                    dict[continent].Add(countries, new List<string>());
                    dict[continent][countries].Add(cities);
                }
                else
                {
                    dict[continent][countries].Add(cities);
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($" {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
