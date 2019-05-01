using System;
using System.Linq;

namespace _04._Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isTrue = true;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int a = arr[i];
                    int b = arr[j];
                    int sum = a + b;

                    if (arr.Contains(sum))
                    {
                        Console.WriteLine($"{a} + {b} == {sum}");
                        isTrue = false;
                    }
                }
            }

            if (isTrue)
            {
                Console.WriteLine("No");
            }
        }
    }
}
