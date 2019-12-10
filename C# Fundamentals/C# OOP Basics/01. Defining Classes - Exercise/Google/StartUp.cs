using System;
using System.Linq;
using System.Collections.Generic;

namespace Google
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = splitedInput[0];

                if (!persons.Any(x => x.Name == personName))
                {
                    persons.Add(new Person(personName));
                }

                string currClass = splitedInput[1];
                Person person = persons.Where(x => x.Name == personName).FirstOrDefault();

                if(currClass == "company")
                {
                    string companyName = splitedInput[2];
                    string department = splitedInput[3];
                    decimal salary = decimal.Parse(splitedInput[4]);

                    person.Company = new Company(companyName, department, salary);   
                }
                else if (currClass == "pokemon")
                {
                    string pokemonName = splitedInput[2];
                    string pokemonType = splitedInput[3];

                    person.Pokemon.Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (currClass == "parents")
                {
                    string parentName = splitedInput[2];
                    string parentBirthday = splitedInput[3];

                    person.Parents.Add(new Parents(parentName, parentBirthday));
                }
                else if (currClass == "children")
                {
                    string childName = splitedInput[2];
                    string childBirthday = splitedInput[3];

                    person.Children.Add(new Children(childName, childBirthday));
                }
                else if (currClass == "car")
                {
                    string model = splitedInput[2];
                    string speed = splitedInput[3];

                    person.Car = new Car(model, speed);
                }

                input = Console.ReadLine();
            }

            string inputPerson = Console.ReadLine();
            Person personPrint = persons.Where(x => x.Name == inputPerson).FirstOrDefault();

            Console.Write(personPrint);
        }
    }
}
