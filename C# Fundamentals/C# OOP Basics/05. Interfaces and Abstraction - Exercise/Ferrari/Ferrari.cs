namespace Ferrari
{
    public class Ferrari : IFerari
    {
        private const string  model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            Model = model;
            Driver = driver;
        }
        public string Model
        {
            get;
        }

        public string Driver
        {
            get;
        }

        public string Breaks()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }
    }
}
