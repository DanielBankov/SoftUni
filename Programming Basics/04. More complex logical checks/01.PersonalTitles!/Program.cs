using System;

namespace _01._PersonalTitles_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (N < 16)
            {
                if (gender == "m") Console.WriteLine("Master");
                else if (gender == "f") Console.WriteLine("Miss");
            }
            else
            {
                if (gender == "m") Console.WriteLine("Mr.");
                else if (gender == "f") Console.WriteLine("Ms.");
            }
        }
    }
}
