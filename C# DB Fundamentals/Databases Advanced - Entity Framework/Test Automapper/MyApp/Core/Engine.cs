namespace MyApp.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(inputArgs.Count() == 0 || inputArgs[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();
                string result = commandInterpreter.Read(inputArgs);

                Console.WriteLine(result);

                //TODO: add try catch
            }
        }
    }
}
