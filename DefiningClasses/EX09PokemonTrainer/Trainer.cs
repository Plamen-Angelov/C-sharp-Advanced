using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer()
        {
            NumberOfBadges = 0;
            List<Pokemon> pokemons = new List<Pokemon>();
        }

        public Trainer(string name)
            :this()
        {
            this.Name = name;
        }

        public Trainer(string name, List<Pokemon> pokemons)
            :this()
        {

        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> PokemonCollection { get; set; }
    }
}
