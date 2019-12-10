using System;
using System.Linq;
using System.Collections.Generic;

namespace OpinionPoll
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                persons.Add(new Person(input[0], int.Parse(input[1])));
            }

            PrintOldestMembers(persons); 
        }

        private static void PrintOldestMembers(List<Person> persons)
        {
            foreach (var person in persons.OrderBy(x => x.Name).Where(x => x.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
