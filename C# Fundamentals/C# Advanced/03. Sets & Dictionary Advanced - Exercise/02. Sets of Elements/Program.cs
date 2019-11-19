using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers[0]; i++)
            {
                int numberInput = int.Parse(Console.ReadLine());
                firstSet.Add(numberInput);
            }

            for (int i = 0; i < numbers[1]; i++)
            {
                int numberInput = int.Parse(Console.ReadLine());
                secondSet.Add(numberInput);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
