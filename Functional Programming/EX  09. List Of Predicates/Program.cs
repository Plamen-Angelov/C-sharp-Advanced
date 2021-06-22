using System;
using System.Linq;

namespace EX__09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> divisible = (n, divs) =>
            {
                bool isDivisible = true;

                foreach (var divider in divs)
                {
                    if (n % divider != 0)
                    {
                        isDivisible = false;
                        continue;
                    }
                }

                return isDivisible;
            };

            int[] divisibleNumbers = Enumerable.Range(1, range)
                .Where(n => divisible(n, dividers))
                .ToArray();

            Console.WriteLine($"{string.Join(' ', divisibleNumbers)}");

            //for (int i = 1; i <= range; i++)
            //{
            //    if (divisible(i, dividers))
            //    {
            //        Console.Write($"{i} ");
            //    }
            //}
        }
    }
}
