using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int nCount = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < nCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split();

            people.Where(p => condition == "older" ? p.Value >= ageFilter : p.Value < ageFilter)
                .ToList()
                .ForEach(p => Print(p, format));
        }

        static void Print(KeyValuePair<string, int> p, string[] format)
        {
            if(format.Length == 2)
            {
                Console.WriteLine(format[0] == "name" ? $"{p.Key} - {p.Value}" : $"{p.Value} - {p.Key}");
            }
            else
            {
                Console.WriteLine(format[0] == "name" ? $"{p.Key}" : $"{p.Value}");
            }
        }
    }
}
