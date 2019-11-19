using System;
using System.Collections.Generic;

namespace _3._Decimal_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> binary = new Stack<int>();
            int residue = 0;

            if (input == 0)
            {
                Console.WriteLine("0");
            }

            while (input != 0)
            {
                residue = input % 2;
                binary.Push(residue);
                input /= 2;
            }

            while (binary.Count != 0)
            {
                Console.Write(binary.Pop());
            }

            Console.WriteLine();
        }
    }
}
