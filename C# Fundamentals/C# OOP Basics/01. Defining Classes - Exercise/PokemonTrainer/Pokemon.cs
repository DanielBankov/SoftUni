namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private int health;
        private string element;

        public Pokemon(string name, int health, string element)
        {
            this.Name = name;
            this.Health = health;
            this.Element = element;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}
