using System;
using System.Collections.Generic;

namespace EX__06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string itemColor = input[0];

                string[] items = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(itemColor))
                {
                    clothes.Add(itemColor, new Dictionary<string, int>());
                }

                foreach (var cl in items)
                {
                    if (!clothes[itemColor].ContainsKey(cl))
                    {
                        clothes[itemColor].Add(cl, 0);
                    }

                    clothes[itemColor][cl]++;
                }
            }

            string[] searchFor = Console.ReadLine()
                .Split();
            string color = searchFor[0];
            string item = searchFor[1];

            foreach (var kvp in clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp2 in kvp.Value)
                {
                    if (kvp.Key == color && kvp2.Key == item)
                    {
                        Console.WriteLine($"* { kvp2.Key} - { kvp2.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                }
            }
        }
    }
}
