using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split();

            List<Person> people = new List<Person>();

            while (inputLine[0] != "END")
            {
                Person person = new Person(inputLine[0], int.Parse(inputLine[1]), inputLine[2]);
                people.Add(person);

                inputLine = Console.ReadLine().Split();
            }

            int number = int.Parse(Console.ReadLine()) - 1;

            Person ComparePerson = people[number];

            int matches = 0;

            foreach (var person in people)
            {
                if(person.CompareTo(ComparePerson) == 0)
                {
                    matches++;
                }
            }

            if(matches > 1)
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
