using System;
using System.Text;

namespace _06._Sum_big_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();
            string sum = Sum(firstWord, secondWord);

            Console.WriteLine(sum);
        }

        static string Sum(string firstWord, string secondWord)
        {
            StringBuilder builder = new StringBuilder();

            int maxLenth = Math.Max(firstWord.Length, secondWord.Length);
            int remainder = 0;

            firstWord = firstWord.PadLeft(maxLenth, '0');
            secondWord = secondWord.PadLeft(maxLenth, '0');

            for (int index = maxLenth - 1; index >= 0; index--)
            {
                int sum = firstWord[index] - 48 + secondWord[index] - 48 + remainder;
                builder.Insert(0, sum % 10);
                remainder = sum / 10;

                if (index == 0)
                {
                    builder.Insert(0, remainder);
                }
            }

            string result = builder.ToString().TrimStart('0');
            return result;
        }
    }
}
