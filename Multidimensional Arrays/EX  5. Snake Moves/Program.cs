using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char [][] snakeMove = new char[size[0]][];

            char[] input = Console.ReadLine().ToCharArray();
            Queue<char> snake = new Queue<char>(input);

            for (int i = 0; i < snakeMove.Length; i++)
            {
                char[] line = new char[size[1]];

                if (i % 2 == 0)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        line[j] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else if (i % 2 == 1)
                {
                    for (int j = line.Length - 1; j >= 0; j--)
                    {
                        line[j] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }

                snakeMove[i] = line;
            }

            foreach (var line in snakeMove)
            {
                string result = new string(line);
                Console.WriteLine(result);
            }
        }
    }
}
