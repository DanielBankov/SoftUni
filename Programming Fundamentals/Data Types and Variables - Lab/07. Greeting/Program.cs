using System;

namespace _07._Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {name} {lastName}. \r\nYou are {age} years old.");
        }
    }
}
