using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Pokemon pokemon = new Pokemon(info[1], info[2], int.Parse(info[3]));

                bool trainerExist = false;

                foreach (var tr in trainers)
                {

                    if (tr.Name == info[0])
                    {
                        tr.PokemonCollection.Add(pokemon);
                        trainerExist = true;
                        break;
                    }
                }

                if (!trainerExist)
                {
                    List<Pokemon> pokemons = new List<Pokemon>();
                    pokemons.Add(pokemon);
                    Trainer trainer = new Trainer();
                    trainer.Name = info[0];
                    trainer.PokemonCollection = pokemons;

                    trainers.Add(trainer);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.PokemonCollection.Any(p => p.Element == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.PokemonCollection.Count; i++)
                        {
                            trainer.PokemonCollection[i].Health -= 10;

                            if (trainer.PokemonCollection[i].Health <= 0)
                            {
                                trainer.PokemonCollection.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonCollection.Count}");
            }
        }
    }
}
