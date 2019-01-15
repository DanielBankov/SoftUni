using System;

namespace _11.Equal_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = Console.ReadLine().ToLower();
            string two = Console.ReadLine().ToLower();

            if (one == two)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
