namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using Data;

    using System.Linq;
    using System.Text;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            var empPersonalInfoDto = mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            var sb = new StringBuilder();
            var onlyDate = string.Format("{0:d/M/yyyy}", empPersonalInfoDto.Birthday);
            
            sb.AppendLine($"ID: {empPersonalInfoDto.Id} - {empPersonalInfoDto.FirstName} {empPersonalInfoDto.LastName} - ${empPersonalInfoDto.Salary:f2}");
            sb.AppendLine($"BirthDay: {onlyDate}");
            sb.AppendLine($"Address: {empPersonalInfoDto.Address}");

            return sb.ToString().TrimEnd();
        }
    }
}
