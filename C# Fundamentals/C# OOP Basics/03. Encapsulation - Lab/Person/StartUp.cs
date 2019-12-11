using System;
using System.Linq;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string firstName = inputInfo[0];
                string lastName = inputInfo[1];
                int age = int.Parse(inputInfo[2]);

                Person person = new Person(firstName, lastName, age);
                persons.Add(person);
            }

            persons.OrderBy(x => x.FirstName).ThenBy(x => x.Age).ToList().ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
