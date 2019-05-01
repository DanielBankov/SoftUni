using System;

namespace _09._Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] letters = [a, z]          
            string text = Console.ReadLine();
            foreach (var letter in text)
                Console.WriteLine(string.Join(" -> ", letter, letter - 'a'));
        }
    }
}
