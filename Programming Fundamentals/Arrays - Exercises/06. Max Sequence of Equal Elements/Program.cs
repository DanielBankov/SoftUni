using System;
using System.Linq;

namespace _06._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxStart = 0;
            int maxLen = 1;
            int currentStart = 0;
            int currentLen = 1;

            for (int i = 1; i < sequance.Length; i++)
            {
                if (sequance[i] == sequance[currentStart])
                {
                    currentLen++;
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        maxStart = currentStart;
                    }
                }
                else
                {
                    currentLen = 1;
                    currentStart = i;
                }
            }

            for (int i = maxStart; i < maxStart + maxLen; i++)
                Console.Write("{0} ", sequance[i]);
        }
    }
}
