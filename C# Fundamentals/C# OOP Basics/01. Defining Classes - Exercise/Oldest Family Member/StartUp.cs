using System;

namespace Oldest_Family_Member
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestPerson();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
