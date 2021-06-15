using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //nt[] input = Console.ReadLine()
            //   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //   .Select(int.Parse)
            //   .ToArray();

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] data = command
                    .ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (data[0])
                {
                    case "add":
                        stack.Push(int.Parse(data[1]));
                        stack.Push(int.Parse(data[2]));
                        break;
                    case "remove":
                        int count = int.Parse(data[1]);

                        if (count <= stack.Count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
