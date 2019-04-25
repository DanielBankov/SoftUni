using System;

namespace _08.LAB_Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeValue = Console.ReadLine();

            if (typeValue == "int")
            {
                GetMaxInt();
            }
            else if (typeValue == "char")
            {
                GetMaxChar();
            }
            else if (typeValue == "string")
            {
                GetMaxString();
            }
        }

        static void GetMaxString()
        {
            string firstNum = Console.ReadLine();
            string secondNum = Console.ReadLine();

            if (string.Compare(firstNum, secondNum) > 0)
            {
                Console.WriteLine(firstNum);
            }
            else
            {
                Console.WriteLine(secondNum);
            }
        }

        static void GetMaxChar()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char biggestChar = firstChar > secondChar ? firstChar : secondChar;

            Console.WriteLine(biggestChar);
        }

        static void GetMaxInt()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(firstNum, secondNum));
        }
    }
}
