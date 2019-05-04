using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int count = 0;

                for (int k = 0; k < numbers.Length; k++)
                {
                    if (currentNumber == numbers[k])
                    {
                        count++;
                    }
                }

                i += count - 1;
                Console.WriteLine(currentNumber + " -> " + count + " times");
            }
        }
    }
}
