using MiniORM.App.Entities;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var conectionString = @"Server=DESKTOP-CP2NEHV\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(conectionString);

            context.Employees.Add(new Employee  
            {
                FirstName = "Gosho",
                LastName = "Inserted02",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified_02";

            context.SaveChanges();
        }
    }
}