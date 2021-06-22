using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<long> takeOdds = n => n % 2 != 0;
            Predicate<long> takeEvens = n => n % 2 == 0;

            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<long> numbers = new List<long>();

            for (long i = bounds[0]; i <= bounds[1]; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            switch (command.ToLower())
            {
                case "odd":
                    numbers = numbers
                        .Where(n => takeOdds(n))
                        .ToList();
                    break;
                case "even":
                    numbers = numbers
                        .Where(n => takeEvens(n))
                        .ToList();
                    break;
            }
            Console.WriteLine($"{string.Join(' ', numbers)}");
        }
    }
}
