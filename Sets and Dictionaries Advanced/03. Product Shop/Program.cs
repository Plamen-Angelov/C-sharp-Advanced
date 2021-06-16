using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();
            string command;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] data = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
