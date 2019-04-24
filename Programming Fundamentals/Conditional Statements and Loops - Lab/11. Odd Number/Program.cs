using System;

namespace _11._Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int oddNum = int.Parse(Console.ReadLine());

            while (oddNum % 2 == 0)
            {
                Console.WriteLine("Please write an odd number.");
                oddNum = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {Math.Abs(oddNum)}");
        }
    }
}
