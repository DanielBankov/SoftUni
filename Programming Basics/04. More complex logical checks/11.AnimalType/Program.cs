using System;

namespace _11._AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            switch (animal)
            {
                case "dog" : Console.WriteLine("mammal");
                    break;
                case "snake":
                case "tortoise":
                case "crocodile": Console.WriteLine("reptile");
                    break;
                default: Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
