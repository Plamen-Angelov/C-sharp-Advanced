using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Where(w => char.IsUpper(w[0]))
            //    .ToArray();
            //
            //foreach (var word in words)
            //{
            //    Console.WriteLine(word);
            //}

            Func<string, bool> startsWithUppercase = word => char.IsUpper(word[0]);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(startsWithUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
