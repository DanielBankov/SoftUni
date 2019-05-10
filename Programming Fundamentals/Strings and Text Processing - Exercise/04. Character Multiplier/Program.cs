using System;
using System.Linq;

namespace _04._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string firstText = input[0];
            string secondText = input[1];
            int result = Multiply(firstText, secondText);

            Console.WriteLine(result);
        }

        static int Multiply(string firstText, string secondText)
        {
            int minLength = Math.Min(firstText.Length, secondText.Length);
            int maxLength = Math.Max(firstText.Length, secondText.Length);
            int result = 0;

            for (int index = 0; index < minLength; index++)
            {
                result += firstText[index] * secondText[index];
            }

            for (int index = minLength; index < maxLength; index++)
            {
                result += firstText.Length > secondText.Length ? firstText[index] : secondText[index];
            }

            return result;
        }
    }
}
