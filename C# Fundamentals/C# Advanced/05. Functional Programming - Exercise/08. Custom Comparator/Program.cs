using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Action<int[]> print = p => Console.WriteLine(string.Join(" ", p));
            Func<int, int, int> sortFunc = CustomComparer;
            //(a % 2 == 0 && b % 2 != 0) ? -1 :
            //(a % 2 != 0 && b % 2 == 0) ? 1 :
            //a.CompareTo(b);

            Array.Sort(inputNumbers, (a, b) => sortFunc(a, b));
            print(inputNumbers);
        }

        static int CustomComparer(int a, int b)
        {
            if (Math.Abs(a % 2) == Math.Abs(b % 2))
            {
                if (a == b)
                {
                    return 0;
                }
                else if (a < b)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                if (Math.Abs(a % 2) == 0)
                {
                    return -1;
                }
                return 1;
            }
        }
    }
}
