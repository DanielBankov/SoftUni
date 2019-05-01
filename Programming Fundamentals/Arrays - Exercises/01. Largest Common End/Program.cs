using System;

namespace _01._Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstRow = Console.ReadLine().Split();
            var secondRow = Console.ReadLine().Split();

            var length = Math.Min(firstRow.Length, secondRow.Length);
            int firstCount = 0;
            int secondCount = 0;

            for (int i = 0; i < length; i++)
            {
                if (firstRow[i] == secondRow[i])
                {
                    firstCount++;
                }

                if (firstRow[firstRow.Length - 1 - i] == secondRow[secondRow.Length - 1 - i])
                {
                    secondCount++;
                }
            }

            if (firstCount > secondCount)
            {
                Console.WriteLine(firstCount);
            }
            else
            {
                Console.WriteLine(secondCount);
            }
        }
    }
}
