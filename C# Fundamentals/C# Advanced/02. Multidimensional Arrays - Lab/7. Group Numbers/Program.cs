using System;
using System.Linq;

namespace _7._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[][] jaggMatrix = new int[3][];

            jaggMatrix[0] = inputNumbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            jaggMatrix[1] = inputNumbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            jaggMatrix[2] = inputNumbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            foreach (int[] printRow in jaggMatrix)
            {
                Console.WriteLine(string.Join(' ', printRow));
            }
        }
    }
}
