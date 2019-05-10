using System;
using System.Text;

namespace _07._Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            string result = Multiply(num1, num2);

            Console.WriteLine(result);
        }

        static string Multiply(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();

            int remainder = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int sum = (num1[i] - 48) * (num2[0] - 48) + remainder;
                sb.Insert(0, sum % 10);
                remainder = sum / 10;

                if (i == 0)
                {
                    sb.Insert(0, remainder);
                }
            }

            string result = sb.ToString().TrimStart('0');

            if (result.Length != 0)
            {
                return result;
            }
            else
            {
                return "0";
            }
        }
    }
}
