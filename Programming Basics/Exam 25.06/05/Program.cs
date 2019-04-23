using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            

            Console.WriteLine("{0}", new string ('#', (n * 4) + 1));

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}{2}{3}{1}{0}", new string('.', i), new string('#', (n * 2) - (i * 2) + 1), new string(' ', i), new string(' ', i - 1));
            }
            for (int i = 1; i <= n; i++)
            {
                  Console.WriteLine("{0}{1}{0}" , new string ('.' , (n + i) ) , new string ('#' , (n-i)));
            }
        }
    }
}
