namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using Data;
    using VeiwModels;

    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var address = string.Join(' ', inputArgs.Skip(1));

            var employee = context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            employee.Address = address;
            context.SaveChanges();

            var setAddressDto = mapper.CreateMappedObject<SetAddressDto>(employee);

            var result = $"Successfully set address: {setAddressDto.Address}, to employee with ID: {setAddressDto.Id}.";
            return result;
        }
    }
}
