namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    using System;
    using System.Linq;
    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var age = int.Parse(inputArgs[0]);

            var employees = context.Employees.Where(e => (DateTime.Now.Year - e.Birthday.Value.Year) > age)
                .OrderByDescending(e => e.Salary).ToArray();

            var sb = new StringBuilder();

            for (int i = 0; i < employees.Length; i++)
            {
                var olderEmployeesDto = mapper.CreateMappedObject<OlderEmployeesDto>(employees[i]);

                sb.AppendLine($"{olderEmployeesDto.FirstName} {olderEmployeesDto.LastName} - ${olderEmployeesDto.Salary:f2} - Manager: {olderEmployeesDto.Manager.LastName ?? "[no manager]"}");
                //TODO fix no manager null exception
            }

            return sb.ToString().TrimEnd();
        }
    }
}
