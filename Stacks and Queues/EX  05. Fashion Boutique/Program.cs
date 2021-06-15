using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] box = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(box);

            int rack = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int rackCapacity = rack;

            while (clothes.Count > 0)
            {
                if (rackCapacity >= clothes.Peek())
                {
                    rackCapacity -= clothes.Pop();
                }
                else
                {
                    rackCounter++;
                    rackCapacity = rack;
                    rackCapacity -= clothes.Pop();
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
