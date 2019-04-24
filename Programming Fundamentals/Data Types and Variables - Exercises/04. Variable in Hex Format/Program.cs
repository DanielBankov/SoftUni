using System;

namespace _04._Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(str, 16)); // convert to (16x) hexadecilam format.
        }
    }
}
