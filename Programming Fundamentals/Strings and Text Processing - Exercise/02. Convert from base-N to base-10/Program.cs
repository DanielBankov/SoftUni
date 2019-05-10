using System;
using System.Linq;
using System.Numerics;

namespace _02._Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            int baseN = int.Parse(input[0]);
            string number = input[1];
            string convertedNumber = ConvertToBase10(number, baseN);

            Console.WriteLine(convertedNumber);
        }

        private static string ConvertToBase10(string number, int baseN)
        {
            BigInteger result = 0;
            char[] digits = number.ToCharArray();
            digits = digits.Reverse().ToArray();

            for (int index = 0; index < number.Length; index++)
            {
                BigInteger poweredBase = 1;

                for (int i = 0; i < index; i++)
                {
                    poweredBase *= baseN;
                }

                result += BigInteger.Parse(digits[index].ToString()) * poweredBase;
            }

            return result.ToString();
        }
    }
}