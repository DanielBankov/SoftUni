using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var VIP = new HashSet<string>();
            var regular = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }

                bool isDigit = char.IsDigit(input[0]);

                if (isDigit)
                {
                    VIP.Add(input);
                    continue;
                }
                regular.Add(input);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (VIP.Contains(input))
                {
                    VIP.Remove(input);
                }

                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
            }

            Console.WriteLine(VIP.Count + regular.Count);
            foreach (var number in VIP)
            {
                Console.WriteLine(number);

            }

            foreach (var number in regular)
            {
                Console.WriteLine(number);

            }
        }
    }
}
