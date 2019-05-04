using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int count = 0;

                for (int k = 0; k < numbers.Count; k++)
                {
                    if(currentNumber == numbers[k])
                    {
                        count++;
                    }
                }

                if(count % 2 != 0)
                {
                    numbers.RemoveAll(n => n == currentNumber);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
