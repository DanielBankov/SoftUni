using System;

namespace _02._Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];

            for (int i = 0; i < number; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int j = number - 1; j >= 0; j--)
            {
                Console.WriteLine(arr[j]);
            }
        }
    }
}
