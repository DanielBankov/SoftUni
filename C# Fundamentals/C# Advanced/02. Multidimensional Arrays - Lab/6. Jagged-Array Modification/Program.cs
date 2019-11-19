using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] col = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jagArray[i] = col;
            }

            string[] inputInfo = Console.ReadLine().Split().ToArray();

            while (inputInfo[0] != "END")
            {
                int rowIndex = int.Parse(inputInfo[1]);
                int colIndex = int.Parse(inputInfo[2]);
                int numberOperation = int.Parse(inputInfo[3]);

                if (rowIndex < 0 || rowIndex > jagArray.Length - 1 || colIndex < 0 || colIndex > jagArray[rowIndex].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");

                }
                else
                {
                    if (inputInfo[0] == "Add")
                    {
                        jagArray[rowIndex][colIndex] += numberOperation;
                    }
                    else
                    {
                        jagArray[rowIndex][colIndex] -= numberOperation;
                    }
                }

                inputInfo = Console.ReadLine().Split().ToArray();
            }

            foreach (int[] col in jagArray)
            {
                Console.WriteLine(string.Join(' ', col));
            }
        }
    }
}
