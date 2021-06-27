using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients = new List<Ingredient>();

        public string  Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel 
        {
            get 
            {
                return ingredients.Sum(i => i.Alcohol);
            }
        }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Any(i => i.Name == ingredient.Name) 
                && MaxAlcoholLevel >= ingredient.Alcohol + CurrentAlcoholLevel 
                && Capacity > ingredients.Count)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            foreach (var item in ingredients)
            {
                if (item.Name == name)
                {
                    return ingredients.Remove(item);
                }
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients
                .OrderByDescending(i => i.Alcohol)
                .FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            sb.AppendLine($"{string.Join('\n', ingredients)}");

            return sb.ToString().TrimEnd();
        }
    }
}
