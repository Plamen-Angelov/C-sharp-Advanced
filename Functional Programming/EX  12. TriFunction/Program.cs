using System;
using System.Linq;

namespace EX__12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> equalOrLarger = (name, n) => name.ToCharArray()
                .Select(ch => (int) ch).Sum() >= n;

            Func<string[], Func<string, int, bool>, int, string> getName = (names, func, num) =>
                names.First(name => func(name, num));

            Console.WriteLine(getName(names, equalOrLarger, num));
        }
    }
}
