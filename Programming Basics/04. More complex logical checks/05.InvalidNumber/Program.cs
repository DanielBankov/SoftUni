using System;

namespace _05._InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool inrange = num >= 100 && num <= 200 || num == 0;
            
            if (!inrange)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
