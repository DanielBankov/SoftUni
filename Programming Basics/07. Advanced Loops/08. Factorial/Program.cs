using System;

namespace _08.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 1;

            do
            {
                result *= n;
                n--;
            } while (n > 0);

            Console.WriteLine(result);
        }
    }
}
