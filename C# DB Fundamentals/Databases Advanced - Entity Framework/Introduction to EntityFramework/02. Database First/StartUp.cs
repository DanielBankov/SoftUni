using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                //Invoke any method here
                var result = GetDepartmentsWithMoreThan5Employees(context);
                Console.WriteLine(result);
            }
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(n => n.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerSecondName = x.Manager.LastName,
                    Employee = x.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(n => n.EmployeeFirstName)
                    .ThenBy(n => n.EmployeeLastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirstName} {dep.ManagerSecondName}");

                foreach (var emp in dep.Employee)
                {
                    sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 09. Employee 147 
        /// </summary>
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FullName = e.FirstName + ' ' + e.LastName,
                    e.JobTitle,
                    ProjectNames = e.EmployeesProjects.Select(n => n.Project.Name).ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FullName} - {emp.JobTitle}");

                foreach (var project in emp.ProjectNames.OrderBy(n => n))
                {
                    sb.AppendLine($"{project}");  
                }
            }

            return sb.ToString().TrimEnd();

        }

        /// <summary>
        /// 08. Addresses by Town 
        /// </summary>
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.Employees.Count,
                    a.Town.Name,
                    a.AddressText,
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(n => n.Name)
                .ThenBy(t => t.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 07. Employees and Projects 
        /// </summary>
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + ' ' + e.LastName,
                    ManagerFullName = e.Manager.FirstName + ' ' + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    }).ToList()
                })
                .Take(10)   
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFullName} - Manager: {emp.ManagerFullName}");

                foreach (var project in emp.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                        : "not finished";

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 06.	Adding a New Address and Updating Employee 
        /// </summary>
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            //context.Addresses.Add(newAddress);

            var person = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            person.Address = newAddress;

            context.SaveChanges();

            var addressesTexts = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addressesTexts)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 05. Employees from Research and Development 
        /// </summary>
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(d => d.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(s => s.Salary)
                .ThenByDescending(n => n.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 04.	Employees with Salary Over 50 000 
        /// </summary>
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                    x.EmployeeId
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// 03. Employees Full Information 
        /// </summary>
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary,
                    x.EmployeeId
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}