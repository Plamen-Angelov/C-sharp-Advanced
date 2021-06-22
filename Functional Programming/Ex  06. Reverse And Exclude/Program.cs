using System;
using System.Globalization;
using System.Linq;

namespace Ex__06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int num = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverse = nums => nums.Reverse().ToArray();
            Predicate<int> isDivisible = n => n % num != 0;

            numbers = reverse(numbers)
                .Where(n => isDivisible(n))
                .ToArray();

            Console.WriteLine($"{string.Join(' ', numbers)}");
        }
    }
}
