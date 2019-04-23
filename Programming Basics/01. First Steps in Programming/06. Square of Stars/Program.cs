using System;

namespace _06._Square_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', n));

            for (int i = 0; i < n - 2; i++)
            {
                string stars = '*' + new string(' ', n - 2) + '*';
                Console.WriteLine(stars);
            }
            Console.WriteLine(new string('*', n));
        }
    }
}
