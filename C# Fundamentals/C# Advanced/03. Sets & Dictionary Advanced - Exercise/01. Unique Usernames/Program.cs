using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var un in usernames)
            {
                Console.WriteLine(un);
            }
        }
    }
}
