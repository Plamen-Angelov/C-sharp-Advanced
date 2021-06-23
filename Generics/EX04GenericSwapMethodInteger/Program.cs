using System;
using System.Collections.Generic;
using System.Linq;

namespace EX04GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                ints.Add(element);
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Swap<int>(ints, indexes[0], indexes[1]);

            foreach (var element in ints)
            {
                Console.WriteLine($"{typeof(int)}: {element}");
            }
        }
        public static void Swap<T>(List<T> list, int firsIndex, int secondIndex)
        {
            T elenent = list[firsIndex];
            list[firsIndex] = list[secondIndex];
            list[secondIndex] = elenent;
        }
    }
}
