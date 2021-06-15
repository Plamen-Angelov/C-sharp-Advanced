using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int pushN = elements[0];
            int popS = elements[1];
            int containsX = elements[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(numbers);

            for (int i = 0; i < popS; i++)
            {
                numStack.Pop();
            }

            switch (numStack.Contains(containsX))
            {
                case true:
                    Console.WriteLine("true");
                    break;
                case false:
                    if (numStack.Any())
                    {
                        Console.WriteLine("0");
                    }
                    else
                    {
                        int smallestNum = int.MaxValue;

                        foreach (var item in numStack)
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
