﻿using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string firstName = inputInfo[0];
                string lastName = inputInfo[1];
                int age = int.Parse(inputInfo[2]);
                decimal salary = decimal.Parse(inputInfo[3]);

                Person person = new Person(firstName, lastName, age, salary);
                persons.Add(person);
            }

            decimal bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(x => x.IncreaseSalary(bonus));
            persons.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
