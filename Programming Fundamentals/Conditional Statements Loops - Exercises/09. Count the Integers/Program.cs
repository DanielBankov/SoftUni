using System;

namespace _09._Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int digits = 0;

            for (int i = 0; i <= 100; i++)
            {
                try
                {
                    int.Parse(Console.ReadLine());
                    digits++;
                }
                catch (OverflowException) // catch error string format
                {
                    break;
                }
                catch (FormatException) // catch error string format
                {
                    break;
                }
            }

            Console.WriteLine(digits);
        }
    }
}
