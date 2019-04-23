namespace MyApp.Core.Command.Command
{
    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    using System.Linq;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            var empInfoDto = mapper.CreateMappedObject<EmployeeInfoDto>(employee);

            var result = $"ID: {empInfoDto.Id} - {empInfoDto.FirstName} {empInfoDto.LastName} - ${empInfoDto.Salary:f2}";
            return result;
        }
    }
}
