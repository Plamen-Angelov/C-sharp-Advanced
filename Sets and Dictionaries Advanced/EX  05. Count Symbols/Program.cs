using System;
using System.Collections.Generic;

namespace EX__05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            foreach (var element in text)
            {
                if (chars.ContainsKey(element))
                {
                    chars[element]++;
                }
                else
                {
                    chars.Add(element, 1);
                }
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
