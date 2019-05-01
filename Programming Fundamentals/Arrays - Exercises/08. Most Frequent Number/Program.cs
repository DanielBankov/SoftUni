using System;
using System.Linq;

namespace _08._Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] counts = new int[65535];
            int maxCount = 0;
            int frequentNumber = 0;

            for (int i = 0; i < sequance.Length; i++)
            {
                counts[sequance[i]]++;
                if (counts[sequance[i]] > maxCount)
                {
                    maxCount = counts[sequance[i]];
                    frequentNumber = sequance[i];
                }
            }

            Console.WriteLine(frequentNumber);
        }
    }
}
