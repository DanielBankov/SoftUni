using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> oddNums = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!oddNums.ContainsKey(number))
                {
                    oddNums.Add(number, 0);
                }

                oddNums[number]++;
            }

            Console.WriteLine(oddNums.Where(x => x.Value % 2 == 0).FirstOrDefault().Key); Console.WriteLine("Hello World!");
        }
    }
}
