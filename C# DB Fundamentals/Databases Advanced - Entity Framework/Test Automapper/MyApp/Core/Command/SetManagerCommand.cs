using AutoMapper;
using MyApp.Core.Command.Contracts;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Command
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetManagerCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            int managerId = int.Parse(inputArgs[1]);

            //TODO: Add validation

            var employee = context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            var manager = context.Employees.Where(e => e.Id == managerId).FirstOrDefault();

            employee.Manager = manager;
            context.SaveChanges();
            
            return "Done";
        }
    }
}
