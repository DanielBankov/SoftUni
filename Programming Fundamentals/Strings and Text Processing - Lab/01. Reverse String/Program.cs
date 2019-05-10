using System;
using System.Linq;

namespace _01._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToCharArray().Reverse().ToArray();
            Console.WriteLine(word);
        }
    }
}
