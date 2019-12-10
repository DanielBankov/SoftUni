using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            string[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Trainer> trainers = new List<Trainer>();

            while (inputInfo[0] != "Tournament")
            {
                string trainerName = inputInfo[0];
                string pokemonNmae = inputInfo[1];
                string pokemonElement = inputInfo[2];
                int pokemonHealth = int.Parse(inputInfo[3]);

                if(!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                trainers.Where(x => x.Name == trainerName)
                        .ToList()
                        .ForEach(x => x.Pokemons.Add(new Pokemon(pokemonNmae, pokemonHealth, pokemonElement)));

                inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string elementsInfo = Console.ReadLine();

            while (elementsInfo != "End")
            {
                foreach (var trainer in trainers)
                {
                    if(trainer.Pokemons.Any(x =>x.Element == elementsInfo))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.Select(x => x.Health -= 10).ToList();
                        trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                    }
                }

                elementsInfo = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
