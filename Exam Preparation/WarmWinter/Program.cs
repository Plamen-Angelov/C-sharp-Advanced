using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputHats = ReadFromConsoleToArray();
            int[] inputScarfs = ReadFromConsoleToArray();

            Stack<int> hats = new Stack<int>(inputHats);
            Queue<int> scarfs = new Queue<int>(inputScarfs);
            List<int> sets = new List<int>();

            int currentHat = hats.Peek();
            int currentScarf = scarfs.Peek();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (currentHat > currentScarf)
                {
                    int setPrice = currentHat + currentScarf;
                    sets.Add(setPrice);

                    hats.Pop();
                    scarfs.Dequeue();
                    if (hats.Count > 0 && scarfs.Count > 0)
                    {
                        currentHat = hats.Peek();
                        currentScarf = scarfs.Peek();
                    }
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    if (scarfs.Count > 0)
                    {
                        currentScarf = scarfs.Peek();
                    }
                    currentHat += 1;

                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                    if (hats.Count > 0)
                    {
                        currentHat = hats.Peek();

                    }
                }
            }

            int mostExpensiveSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine($"{string.Join(' ', sets)}");
        }

        static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
