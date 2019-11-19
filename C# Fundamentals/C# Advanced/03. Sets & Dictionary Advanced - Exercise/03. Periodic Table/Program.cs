using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> uniqueCompounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split(' ').ToArray();

                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    uniqueCompounds.Add(chemicalCompounds[j]);
                }
            }

            foreach (var item in uniqueCompounds)
            {
                Console.Write(item + " ");
            }
        }
    }
}
