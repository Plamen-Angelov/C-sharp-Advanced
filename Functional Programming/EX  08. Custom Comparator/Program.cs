using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            foreach (var number in numbers)
            {
                if (isEven(number))
                {
                    evens.Add(number);
                }
                else if (isOdd(number))
                {
                    odds.Add(number);
                }
            }

            evens = evens.OrderBy(n => n).ToList();
            odds = odds.OrderBy(n => n).ToList();

            Console.Write($"{string.Join(' ', evens)} {string.Join(' ', odds)}");
        }
    }
}
