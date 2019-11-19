using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            HashSet<string> hash = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                hash.Add(name);
            }

            foreach (var item in hash)
            {
                Console.WriteLine(item);
            }
        }
    }
}
