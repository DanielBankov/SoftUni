namespace MyCrazyApp
{
    using MyCrazyApp.Core;
    using MyCrazyApp.Modules;
    using SoftUniDi;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var injector = DependencyInjector.CreateInjector(new Module());

            var engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}
