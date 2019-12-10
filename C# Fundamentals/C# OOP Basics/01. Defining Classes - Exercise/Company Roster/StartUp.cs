using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (int.TryParse(input[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else
                    {
                        employee.Email = input[4];
                    }
                }
                else if (input.Length == 6)
                {
                    employee.Email = input[4];
                    employee.Age = int.Parse(input[5]);
                }

                employees.Add(employee);
            }

            var topDepartment = employees.GroupBy(x => x.Department)
                .OrderByDescending(x => x.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var employee in topDepartment.OrderByDescending(s => s.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
