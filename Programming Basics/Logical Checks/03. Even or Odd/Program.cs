using System;

namespace _03.Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            double evenOrOdd = double.Parse(Console.ReadLine());

            if (evenOrOdd % 2 == 0 )
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
