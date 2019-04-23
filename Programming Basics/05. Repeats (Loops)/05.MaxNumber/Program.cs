using System;

namespace _05.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;

            for (int i = 0; i < n ; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input > maxNumber)
                {
                    maxNumber = input;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
