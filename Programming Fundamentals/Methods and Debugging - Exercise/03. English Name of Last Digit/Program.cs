using System;

namespace _03.English_Name_of_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitName(num));
        }

        private static string LastDigitName(long num)
        {
            long lastLetter = Math.Abs(num % 10);
            string nameOfDigit = null;

            if (lastLetter == 0)
                nameOfDigit = "zero";
            else if (lastLetter == 1)
                nameOfDigit = "one";
            else if (lastLetter == 2)
                nameOfDigit = "two";
            else if (lastLetter == 3)
                nameOfDigit = "three";
            else if (lastLetter == 4)
                nameOfDigit = "four";
            else if (lastLetter == 5)
                nameOfDigit = "five";
            else if (lastLetter == 6)
                nameOfDigit = "six";
            else if (lastLetter == 7)
                nameOfDigit = "seven";
            else if (lastLetter == 8)
                nameOfDigit = "eight";
            else if (lastLetter == 9)
                nameOfDigit = "nine";

            return nameOfDigit;
        }
    }
}