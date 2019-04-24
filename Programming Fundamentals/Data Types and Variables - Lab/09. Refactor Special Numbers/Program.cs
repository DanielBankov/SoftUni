using System;

namespace _09._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 0;
            bool isTrue = false;

            for (int i = 1; i <= n; i++)
            {
                num = i;

                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }

                isTrue = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{num} -> {isTrue}");
                sum = 0;
                i = num;
            }
        }
    }
}
