namespace Google
{
    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.PokemonType = type;
        }

        public string Name { get; set; }
        public string PokemonType { get; set; }
    }
}
