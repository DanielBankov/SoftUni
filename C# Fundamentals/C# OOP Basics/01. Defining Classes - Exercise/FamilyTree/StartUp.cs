namespace FamilyTree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static List<Person> persons;
        static List<string> relationships;

        public static void Main()
        {
            persons = new List<Person>();
            relationships = new List<string>();

            string mainPersonInfo = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!input.Contains("-"))
                {
                    AddMember(input);
                    input = Console.ReadLine();
                    continue;
                }

                relationships.Add(input);
                input = Console.ReadLine();
            }

            foreach (var membersInfo in relationships)
            {
                string[] inputArgs = membersInfo.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                Person parent = GetPerson(inputArgs[0]);
                Person child = GetPerson(inputArgs[1]);

                if (!parent.Childern.Contains(child))
                {
                    parent.Childern.Add(child);
                }
                if (!child.Parants.Contains(parent))
                {
                    child.Parants.Add(parent);
                }
            }

            Print(mainPersonInfo);
        }

        private static void Print(string mainPersonInfo)
        {
            Person mainPerson = GetPerson(mainPersonInfo);

            Console.WriteLine($"{mainPerson.Name} {mainPerson.BirthDay}");
            Console.WriteLine("Parents:");

            foreach (var parent in mainPerson.Parants)
            {
                Console.WriteLine($"{parent.Name} {parent.BirthDay}");
            }

            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Childern)
            {
                Console.WriteLine($"{child.Name} {child.BirthDay}");
            }
        }

        private static Person GetPerson(string input)
        {
            if (input.Contains("/"))
            {
                return persons.FirstOrDefault(x => x.BirthDay == input);
            }
            return persons.FirstOrDefault(x => x.Name == input);
        }

        private static void AddMember(string input)
        {
            string[] inputInfo = input.Split();
            string name = inputInfo[0] + " " + inputInfo[1];
            string birthday = inputInfo[2];

            Person person = new Person(name, birthday);
            persons.Add(person);
        }
    }
}
