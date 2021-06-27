using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputIngredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputFreshness = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>(inputIngredients);
            Stack<int> freshness = new Stack<int>(inputFreshness);

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);
            

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int totalFreshness = ingredients.Peek() * freshness.Peek();

                if (totalFreshness == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }
            bool preparingAllDishes = true;

            foreach (var item in dishes)
            {
                if (item.Value == 0)
                {
                    preparingAllDishes = false;
                }
            }

            if (preparingAllDishes)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var item in dishes)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
