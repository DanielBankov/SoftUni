using System;
using System.Collections.Generic;

namespace _12.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            List<int> differences = new List<int>();

            for (int i = 0; i < inputCount; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                int sum = firstNum + secondNum;
                numbers.Add(sum);
            }

            bool isValid = true;

            for (int i = 1; i < numbers.Count; i+=2)
            {
                if (numbers[i - 1] != numbers[i])
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Yes, value={numbers[0]}");
                return;
            }

            int maxValue = int.MinValue;
            int minValue = int.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                if(maxValue < numbers[i])
                {
                    maxValue = numbers[i];
                }

                if(minValue > numbers[i])
                {
                    minValue = numbers[i];
                }
            }

            Console.WriteLine($"No, maxdiff={maxValue - minValue}");
        }
    }
}
