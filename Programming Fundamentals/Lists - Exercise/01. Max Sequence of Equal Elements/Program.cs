using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var longestIncreasingSubsequences = new List<int[]>
            {
                new[] 
                {
                    0, 1
                }
            };

            var currentSequence = longestIncreasingSubsequences[0];

            for (int i = 1; i < arr.Length; i++)
            {
                var current = arr[i];
                var elementToTheLeft = arr[i - 1];

                if (current == elementToTheLeft)
                {
                    currentSequence[1]++;
                }
                else
                {
                    longestIncreasingSubsequences.Add(new[] { i, 1 });
                    currentSequence = longestIncreasingSubsequences.Last();
                }
            }

            var longestSubsequenceLength = longestIncreasingSubsequences.Max(b => b[1]);
            var longestIncreasingSubsequenceIndices = longestIncreasingSubsequences.First(a => a[1] == longestSubsequenceLength);

            var firstStartIndex = longestIncreasingSubsequenceIndices[0];
            var firstBestLength = longestIncreasingSubsequenceIndices[1];

            var longestIncreasingSubsequence = arr.Skip(firstStartIndex).Take(firstBestLength).ToArray();

            Console.WriteLine(string.Join(" ", longestIncreasingSubsequence));
        }
    }
}
