using System;
using System.Text.RegularExpressions;

namespace _02._Extract_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string[] input = Console.ReadLine().Split(".?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                string[] words = Regex.Split(item, @"[^A-Za-z-0-9]+");

                foreach (var word in words)
                {
                    if (word == key)
                    {
                        Console.WriteLine(item.Trim());
                        break;
                    }
                }
            }
        }
    }
}
