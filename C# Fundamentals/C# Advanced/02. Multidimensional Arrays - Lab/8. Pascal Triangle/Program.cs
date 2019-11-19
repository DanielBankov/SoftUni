using System;

namespace _8._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int triangeRows = int.Parse(Console.ReadLine());
            long[][] jaggArray = new long[triangeRows][];

            for (int i = 0; i < triangeRows; i++)
            {
                jaggArray[i] = new long[i + 1];
                jaggArray[i][0] = 1;
                jaggArray[i][i] = 1;
            }

            for (int i = 0; i < jaggArray.Length; i++)
            {
                if (jaggArray[i].Length > 2)
                {
                    for (int j = 1; j < jaggArray[i].Length - 1; j++)
                    {
                        jaggArray[i][j] = jaggArray[i - 1][j] + jaggArray[i - 1][j - 1];
                    }
                }
            }

            foreach (var printRow in jaggArray)
            {
                Console.WriteLine(string.Join(' ', printRow));
            }
        }
    }
}
