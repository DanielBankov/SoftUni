using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[][] matrix = new string[int.Parse(input[0])][];
            List<string> rowList = new List<string>();

            int rowLetter = 97;
            int colLetter = 97;

            for (int row = 0; row < int.Parse(input[0]); row++)
            {
                for (int col = 0; col < int.Parse(input[1]); col++)
                {
                    string letter = "" + (char)(rowLetter) + (char)(colLetter) + (char)(rowLetter);
                    rowList.Add(letter);
                    colLetter++;
                }

                matrix[row] = rowList.ToArray();
                rowList.Clear();
                rowLetter++;
                colLetter = rowLetter;

            }

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] arr = matrix[i];
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
