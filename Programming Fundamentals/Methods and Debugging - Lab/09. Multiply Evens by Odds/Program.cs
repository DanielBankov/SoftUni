using System;

namespace _09.LAB_Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            int value = GetOddSum(num) * GetEvenSum(num);

            Console.WriteLine(value);
        }

        private static int GetOddSum(int num)
        {
            int lastDigit = 0;
            int sum = 0;

            while (num > 0)
            {
                lastDigit = num % 10;

                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                num = num / 10;
            }

            return sum;
        }

        private static int GetEvenSum(int num)
        {
            int lastDigit = 0;
            int sum = 0;

            while (num > 0)
            {
                lastDigit = num % 10;

                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                num = num / 10;
            }

            return sum;
        }
    }
}
