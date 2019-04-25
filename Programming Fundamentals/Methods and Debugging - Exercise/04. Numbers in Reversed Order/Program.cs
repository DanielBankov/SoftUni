using System;

namespace _04.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            Console.WriteLine(ReturnString(n));
        }

        private static string ReturnString(string n)
        {
            string latsBack = "";

            for (int i = n.Length - 1; i >= 0; i--)
            {
                latsBack += n[i];
            }

            return latsBack;
        }
    }
}