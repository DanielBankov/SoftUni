using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Command.Contracts;
using MyApp.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace MyApp.Core
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] inputArgs)
        {
            //take type AddEmployee + Command
            string commandName = inputArgs[0] + Suffix; 

            //take params <firstName> <lastName> <salary> 
            string[] commandParams = inputArgs.Skip(1).ToArray();

            //take ctor
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if(type == null)
            {
                throw new ArgumentNullException("Invallid Command");
            }

            //take first ctor
            var constructor = type.GetConstructors().FirstOrDefault();
            //take all ctor params
            var constructorParams = constructor.GetParameters().Select(x => x.ParameterType).ToArray();

            var services = constructorParams.Select(this.serviceProvider.GetService).ToArray();

            var command = (ICommand)Activator.CreateInstance(type, services);

            var result = command.Execute(commandParams);
            return result;
        }
    }
}
