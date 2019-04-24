using System;

namespace _13._Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = Console.ReadLine();

            if (obj == "0" || obj == "1" || obj == "2" || obj == "3" || obj == "4" || obj == "5" || obj == "6" || obj == "7" || obj == "8" || obj == "9")
            {
                Console.WriteLine("digit");
            }
            else if (obj == "a" || obj == "e" || obj == "i" || obj == "o" || obj == "u")
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
