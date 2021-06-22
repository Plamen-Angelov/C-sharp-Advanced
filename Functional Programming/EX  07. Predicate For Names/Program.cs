using System;
using System.Linq;

namespace EX__07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            

            Action<string[]> writer = ns =>
            {
                Predicate<string> filter = name => name.Length <= n;

                foreach (var name in ns.Where(name => filter(name)))
                {
                    Console.WriteLine(name);
                }
            };

            writer(names);
        }
    }
}
