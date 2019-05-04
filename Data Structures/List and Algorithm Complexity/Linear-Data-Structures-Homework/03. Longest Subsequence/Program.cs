using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Longest_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            StringBuilder sb = new StringBuilder();

            var numbers = FindLongesEqualtSubsequence(inputNumbers);

            foreach (var number in numbers)
            {
                sb.Append(number + " ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static List<int> FindLongesEqualtSubsequence(List<int> inputNumbers)
        {
            List<int> equalsNumbers = new List<int>();
            int currentNumber = int.MinValue;

            for (int i = 1; i < inputNumbers.Count; i++)
            {
                if (inputNumbers[i - 1] == inputNumbers[i])
                {
                    if (currentNumber != inputNumbers[i])
                    {
                        currentNumber = inputNumbers[i];
                        equalsNumbers.Add(inputNumbers[i - 1]);
                    }

                    equalsNumbers.Add(inputNumbers[i]);
                }
            }

            return MostLengthEqualSubsequence(inputNumbers, equalsNumbers, currentNumber);
        }

        private static List<int> MostLengthEqualSubsequence(List<int> inputNumbers, List<int> equalsNumbers, int currentNumber)
        {
            List<int> outputNumbers = new List<int>();

            if (equalsNumbers.Count == 0)
            {
                outputNumbers.Add(inputNumbers[0]);
                return outputNumbers;
            }

            currentNumber = equalsNumbers[0];
            int maxCount = 0;
            int currentCount = 0;
            int mostDuplicateNumber = int.MinValue;

            for (int i = 1; i < equalsNumbers.Count; i++)
            {
                if (equalsNumbers[i - 1] == equalsNumbers[i])
                {
                    if (currentNumber != equalsNumbers[i])
                    {
                        currentCount = 0;
                    }

                    currentNumber = equalsNumbers[i];
                    currentCount++;

                    if (maxCount < currentCount)
                    {
                        maxCount++;
                        mostDuplicateNumber = equalsNumbers[i];
                    }
                }
            }

            for (int i = 0; i <= maxCount; i++)
            {
                outputNumbers.Add(mostDuplicateNumber);
            }

            return outputNumbers;
        }
    }
}
