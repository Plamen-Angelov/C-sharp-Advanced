using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(input);

            List<int> result = new List<int>();

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
