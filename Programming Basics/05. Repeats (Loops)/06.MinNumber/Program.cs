using System;

namespace _06.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < n-1 ; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if ( input < minNum)
                {
                    minNum = input;
                }

            }

            Console.WriteLine(minNum);
        }

    }
}