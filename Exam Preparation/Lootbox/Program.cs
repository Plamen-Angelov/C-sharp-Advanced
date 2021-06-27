using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = ReadFromConsoleToArray();
            int[] second = ReadFromConsoleToArray();

            Queue<int> firstBox = new Queue<int>(first);
            Stack<int> secondBox = new Stack<int>(second);
            List<int> claimedItem = new List<int>();
            int firstItem = firstBox.Peek();
            int secondItem = secondBox.Peek();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                if ((firstItem + secondItem) % 2 == 0)
                {
                    claimedItem.Add(firstItem + secondItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                    if (firstBox.Count > 0 && secondBox.Count > 0)
                    {
                        firstItem = firstBox.Peek();
                        secondItem = secondBox.Peek();
                    }
                    
                }
                else
                {
                    int lastItem = secondBox.Pop();
                    firstBox.Enqueue(lastItem);
                    if (secondBox.Count > 0)
                    {
                        secondItem = secondBox.Peek();
                    }
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int sumOfCalimedItems = claimedItem.Sum();

            if (sumOfCalimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfCalimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfCalimedItems}");
            }
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
