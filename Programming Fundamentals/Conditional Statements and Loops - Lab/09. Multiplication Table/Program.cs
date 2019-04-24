using System;

namespace _09._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int allMulti = n * i;
                Console.WriteLine($"{n} X {i} = {allMulti}");
            }
        }
    }
}
