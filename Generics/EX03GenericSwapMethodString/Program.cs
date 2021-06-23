using System;
using System.Collections.Generic;
using System.Linq;

namespace EX03GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                strings.Add(element);
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Swap<string>(strings, indexes[0], indexes[1]);
            foreach (var str in strings)
            {
                Console.WriteLine($"{typeof(string)}: {str}");
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
