using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<IBirthable> identifiables = new List<IBirthable>();
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];

                    identifiables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];

                    identifiables.Add(new Pet(name, birthdate));
                }

                input = Console.ReadLine().Split();
            }

            string yearEnd = Console.ReadLine();

            foreach (var inde in identifiables)
            {
                if (inde.Birthdate.EndsWith(yearEnd))
                {
                    Console.WriteLine(inde.Birthdate);
                }
            }
        }
    }
}
