using System;

namespace _01.Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            NamePring(name);
        }

        private static void NamePring(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}