using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Pokemon = new List<Pokemon>();
            this.Parents = new List<Parents>();
            this.Children = new List<Children>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Pokemon> Pokemon { get; set; }
        public List<Parents> Parents { get; set; }
        public List<Children> Children { get; set; }
        public Car Car { get; set; }

        public override string ToString()
        {
            return $"{this.Name}\n" +
                   $"Company:\n" +
                   $"{this.Company}" +
                   $"Car:\n" +
                   $"{this.Car}" +
                   $"Pokemon:\n" +
                   $"{string.Join("", this.Pokemon.Select(x => x.Name + " " + x.PokemonType + "\n"))}" +
                   $"Parents:\n" +
                   $"{string.Join("", this.Parents.Select(x => x.Name + " " + x.Birthday + "\n"))}" +
                   $"Children:\n" +
                   $"{string.Join("", this.Children.Select(x => x.Name + " " + x.Birthday + "\n"))}";
        }
    }
}
