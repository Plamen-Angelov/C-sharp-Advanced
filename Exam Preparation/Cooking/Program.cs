using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = ReadFromConsoleToArray();
            int[] ingredientsInput = ReadFromConsoleToArray();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            //Dictionary<int, string> foodByQuantity = new Dictionary<int, string>();
            //foodByQuantity.Add(25, "Bread");
            //foodByQuantity.Add(50, "Cake");
            //foodByQuantity.Add(75, "Pastry");
            //foodByQuantity.Add(100, "Fruit Pie");

            Dictionary<string, int> cookedFood = new Dictionary<string, int>();
            cookedFood.Add("Bread", 0);
            cookedFood.Add("Cake", 0);
            cookedFood.Add("Pastry", 0);
            cookedFood.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                if (liquids.Peek() + ingredients.Peek() == 25)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Bread"]++;
                }
                else if (liquids.Peek() + ingredients.Peek() == 50)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Cake"]++;
                }
                else if (liquids.Peek() + ingredients.Peek() == 75)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Pastry"]++;
                }
                else if (liquids.Peek() + ingredients.Peek() == 100)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Fruit Pie"]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            bool cookEverything = false;
            int countOfDifferentProducts = 0;

            foreach (var item in cookedFood)
            {
                if (item.Value > 0)
                {
                    countOfDifferentProducts++;
                }
            }

            if (countOfDifferentProducts == 4)
            {
                cookEverything = true;
            }

            if (cookEverything)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");

            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine($"Ingredients left: none");
            }

            foreach (var item in cookedFood.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
