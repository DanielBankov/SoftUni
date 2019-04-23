using System;

namespace _08.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var odd = 0;
            var even = 0;

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    odd += input;
                }
                else
                {
                    even += input;
                }
            }

            if (odd == even)
            {
                Console.WriteLine("Yes\nSum = " + odd);
            }
            else
            {
                Console.WriteLine("No\nDiff = " + Math.Abs(odd - even));
            }
        }
    }
}
