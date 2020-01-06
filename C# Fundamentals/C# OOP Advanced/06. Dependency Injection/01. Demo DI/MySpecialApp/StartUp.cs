using CustomDI;
using MySpecialApp.Contracts;
using MySpecialApp.Core;
using MySpecialApp.Models;

namespace MySpecialApp
{
    public class Program
    {
        public static void Main()
        {
            IServiceCollection serviceProvider = ConfigureServices();
            var engine = (Engine)serviceProvider.CreateInstance(typeof(IEngine));
            engine.Run();

            //With generic
            //var engine2 = serviceProvider.CreateInstance<IEngine>();
            //engine2.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddService<IEngine, Engine>();
            serviceCollection.AddService<IReader, ConsoleReader>();
            serviceCollection.AddService<IWriter, ConsoleWriter>();
            serviceCollection.AddService<IWriter, FileWriter>();

            return serviceCollection;
        }
    }
}
