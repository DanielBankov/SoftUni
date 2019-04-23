using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Linq;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //DI
            IServiceProvider service = ConfigureSurvices();
            IEngine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureSurvices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyAppContext>(db => db.UseSqlServer("Server=DESKTOP-SUIN9FI\\SQLEXPRESS;DataBase=MyApp;Integrated Security=True;"));

            //AddTransient everytime create new instance when ist called
            //AddSingleton create new instance only 1 time 
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<Mapper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
