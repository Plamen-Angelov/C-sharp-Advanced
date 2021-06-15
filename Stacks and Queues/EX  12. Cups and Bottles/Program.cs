using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] capsCapacity = ReadFromConsoleToArray();
            int[] bottlesCapacity = ReadFromConsoleToArray();

            Queue<int> caps = new Queue<int>(capsCapacity);
            Stack<int> bottles = new Stack<int>(bottlesCapacity);
            int wasteWater = 0;

            while (caps.Count != 0 && bottles.Count != 0)
            {
                int cap = caps.Peek();

                while (cap > 0)
                {
                    cap -= bottles.Pop();
                }

                caps.Dequeue();
                wasteWater += Math.Abs(cap);
            }

            if (caps.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)} ");
            }
            else if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ',caps)} ");
            }
            Console.WriteLine($"Wasted litters of water: {wasteWater}");
        }

        static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
