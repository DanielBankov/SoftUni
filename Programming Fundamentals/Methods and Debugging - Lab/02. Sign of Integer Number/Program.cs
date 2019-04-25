using System;

namespace _02.LAB_Sign_of_Integer_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string variable = "";

            PrintNegativeOrPositive(variable, n);

            Console.WriteLine($"The number {n} is {PrintNegativeOrPositive(variable, n)}.");
        }

        private static string PrintNegativeOrPositive(string variable, int n)
        {
            string backValue = "";

            if (n < 0)
            {
                backValue = "negative";
                return backValue;
            }
            else if (n > 0)
            {
                backValue = "positive";
                return backValue;
            }
            else
            {
                backValue = "zero";
                return backValue;
            }
        }
    }
}
