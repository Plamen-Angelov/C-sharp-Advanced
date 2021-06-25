using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTasks = ReadFromConsoleToArray();
            int[] inputThreads = ReadFromConsoleToArray();
            int taskToKill = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>(inputThreads);
            Stack<int> tasks = new Stack<int>(inputTasks);

            int currentThread = threads.Peek();
            int currentTask = tasks.Peek();

            while (currentTask != taskToKill)
            {
                if (currentThread >= currentTask)
                {
                    threads.Dequeue();
                    currentThread = threads.Peek();
                    tasks.Pop();
                    currentTask = tasks.Peek();
                }
                else if (currentThread < currentTask)
                {
                    threads.Dequeue();
                    currentThread = threads.Peek();
                }
            }
            Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
            Console.WriteLine($"{string.Join(' ', threads)}");
        }

        private static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
