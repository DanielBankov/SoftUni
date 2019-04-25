using System;

namespace _04.LAB_Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TopAndBotLines(number);

            for (int i = 0; i < number - 2; i++)
            {
                BodyFilledSquare(number);
            }

            TopAndBotLines(number);
        }

        private static void BodyFilledSquare(int num)
        {
            Console.Write("-");

            for (int i = 1; i < num; i++)
            {
                Console.Write("\\/");

            }

            Console.Write("-");
            Console.WriteLine();
        }

        private static void TopAndBotLines(int num)
        {
            Console.WriteLine(new string('-', num * 2));
        }
    }
}
