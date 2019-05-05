using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liss = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ", liss.OrderByDescending(n => n).Take(3)));
        }
    }
}
