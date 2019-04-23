namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class ManagerInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            
            var manager = context.Employees.Include(m => m.ManagedEmployees).FirstOrDefault(e => e.Id == employeeId);
            
            var managerDto = mapper.CreateMappedObject<ManagerDto>(manager);
            
            var sb = new StringBuilder();
            
            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagedEmployees.Count}");
            
            foreach (var emp in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
