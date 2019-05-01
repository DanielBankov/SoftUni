using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] condensed = new int[arr.Length - 1];
            int count = arr.Length - 1;

            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }

            while (count > 0)
            {
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = arr[i] + arr[i + 1];
                    arr[i] = condensed[i];
                }
                count--;
            }

            Console.WriteLine(string.Join(" ", condensed[0]));
        }
    }
}
