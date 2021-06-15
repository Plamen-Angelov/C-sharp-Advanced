using System;
using System.Linq;
using System.Collections.Generic;

namespace EX__04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orderLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(orderLine);

            Console.WriteLine(orders.Max());

            while (orders.Count > 0 && foodQuantity >= orders.Peek())
            {
                foodQuantity -= orders.Dequeue();
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
        }
    }
}
