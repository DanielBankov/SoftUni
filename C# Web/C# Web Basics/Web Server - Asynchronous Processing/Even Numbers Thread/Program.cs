using System;
using System.Threading;

namespace Even_Numbers_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() => PrintEvenNumbers(1, 10));
            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work");
        }

        static void PrintEvenNumbers(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
