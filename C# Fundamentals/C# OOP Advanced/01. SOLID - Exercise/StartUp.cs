namespace SOLID_Exercise
{
    using Contracts;
    using Core;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
