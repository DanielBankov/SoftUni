namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Models;
    using VeiwModels;

    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            decimal salary = decimal.Parse(inputArgs[2]);

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            context.Add(employee);
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            string result = $"Register successfully: {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}";
            return result;
        }
    }
}
