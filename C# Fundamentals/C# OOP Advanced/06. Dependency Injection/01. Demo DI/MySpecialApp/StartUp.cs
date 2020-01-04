using Microsoft.Extensions.DependencyInjection;
using MySpecialApp.Contracts;
using MySpecialApp.Core;
using MySpecialApp.Models;
using System;

namespace MySpecialApp
{
    public class Program
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var engine = serviceProvider.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IEngine, Engine>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IWriter, FileWriter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
