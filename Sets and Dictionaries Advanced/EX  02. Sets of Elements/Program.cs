using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < nums[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < nums[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var num in first)
            {
                foreach (var num2 in second)
                {
                    if (num == num2)
                    {
                        Console.Write($"{num} ");
                    }
                }
            }
        }
    }
}
