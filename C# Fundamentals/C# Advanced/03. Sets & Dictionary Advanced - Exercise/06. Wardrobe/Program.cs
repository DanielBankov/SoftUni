using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" -> ").ToArray();
                string color = inputInfo[0];
                string[] clothes = inputInfo[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 1);
                    }
                    else
                    {
                        wardrobe[color][clothes[j]]++;
                    }

                }
            }

            string[] foundClothes = Console.ReadLine().Split().ToArray();
            string theGarmentColor = foundClothes[0];
            string theGarmen = foundClothes[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothes in color.Value)
                {
                    Console.Write($"* {clothes.Key} - {clothes.Value}");
                    if (color.Key == theGarmentColor && clothes.Key == theGarmen)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
