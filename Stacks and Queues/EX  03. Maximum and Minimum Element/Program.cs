using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        numbers.Push(command[1]);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();

                        }
                        break;
                    case 3:
                        if (numbers.Count == 0)
                        {
                            break;
                        }

                        int max = int.MinValue;

                        foreach (var item in numbers)
                        {
                            if (item > max)
                            {
                                max = item;
                            }
                        }
                        Console.WriteLine(max);
                        break;
                    case 4:
                        if (numbers.Count == 0)
                        {
                            break;
                        }

                        int min = int.MaxValue;

                        foreach (var item in numbers)
                        {
                            if (min > item)
                            {
                                min = item;
                            }
                        }
                        Console.WriteLine(min);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
