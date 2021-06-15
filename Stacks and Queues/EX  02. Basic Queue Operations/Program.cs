using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int addN = elements[0];
            int removeS = elements[1];
            int containsX = elements[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numQueue = new Queue<int>(numbers);

            for (int i = 0; i < removeS; i++)
            {
                numQueue.Dequeue();
            }

            switch (numQueue.Contains(containsX))
            {
                case true:
                    Console.WriteLine("true");
                    break;
                case false:
                    if (numQueue.Count == 0)
                    {
                        Console.WriteLine("0");
                    }
                    else
                    {
                        int smallestNum = int.MaxValue;

                        foreach (var item in numQueue)
                        {
                            if (item < smallestNum)
                            {
                                smallestNum = item;
                            }
                        }
                        Console.WriteLine(smallestNum);
                    }
                    break;
            }
        }
    }
}
