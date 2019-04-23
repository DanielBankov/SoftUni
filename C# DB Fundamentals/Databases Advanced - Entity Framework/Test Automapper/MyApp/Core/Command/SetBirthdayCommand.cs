namespace MyApp.Core.Command
{
    using AutoMapper;
    using Contracts;
    using MyApp.Data;
    using VeiwModels;

    using System;
    using System.Globalization;
    using System.Linq;

    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var date = DateTime.ParseExact(inputArgs[1], "dd-MM-yyyy", CultureInfo.CurrentCulture);

            var employee = context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            employee.Birthday = date;
            this.context.SaveChanges();

            var setBirthdayDto = mapper.CreateMappedObject<SetBirthdayDto>(employee);

            var onlyDate = string.Format("{0:d/M/yyyy}", setBirthdayDto.Birthdate);

            var result = $"Successfully set birthdate: {onlyDate}, to employee with ID: {setBirthdayDto.Id}.";
            return result;
        }
    }
}
