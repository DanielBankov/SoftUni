using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string(' ', n - i));

                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }

            for (int i = n - 1; i > 0; i--)
            {
                Console.Write(new string(' ', n - i));

                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }
    }
}
