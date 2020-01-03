using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> peopleByName = new SortedSet<Person>(new PeopleByName());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new PeopleByAge());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();    

                Person person = new Person(input[0], int.Parse(input[1]));

                var set = peopleByName.Add(person);
                var get = peopleByAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, peopleByName));
            Console.WriteLine(string.Join(Environment.NewLine, peopleByAge));
        }
    }
}
