using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int [] inputRoses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(inputLilies);
            Queue<int> roses = new Queue<int>(inputRoses);

            int wreaths = 0;
            int leftFlowers = 0;
            int currentLilies = lilies.Peek();
            int currentRoses = roses.Peek();

            while (lilies.Count > 0 && roses.Count > 0)
            {
                if (currentLilies + currentRoses == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                    if (lilies.Count > 0 && roses.Count > 0)
                    {
                        currentLilies = lilies.Peek();
                        currentRoses = roses.Peek();
                    }
                }
                else if (currentLilies + currentRoses > 15)
                {
                    currentLilies -= 2;
                    continue;
                }
                else if (currentLilies + currentRoses < 15)
                {
                    leftFlowers += currentLilies + currentRoses;
                    lilies.Pop();
                    roses.Dequeue();
                    if (lilies.Count > 0 && roses.Count > 0)
                    {
                        currentLilies = lilies.Peek();
                        currentRoses = roses.Peek();
                    }
                }
            }
            wreaths += leftFlowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
