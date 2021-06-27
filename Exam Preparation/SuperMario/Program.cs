using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] maze = new char[rows][];
            int marioRow = -1;
            int marioCol = -1;

            for (int i = 0; i < rows; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                maze[i] = line;

                for (int j = 0; j < line.Length; j++)
                {
                    if (maze[i][j] == 'M')
                    {
                        marioRow = i;
                        marioCol = j;
                    }
                }
            }
            maze[marioRow][marioCol] = '-';

            while (lives > 0)
            {
                string input = Console.ReadLine();

                char command = input[0];
                int row = int.Parse(input[2].ToString());
                int col = int.Parse(input[4].ToString());

                lives--;
                maze[row][col] = 'B';

                if (command == 'W' && IsInMaze(maze, marioRow - 1, marioCol))
                {
                    marioRow--;
                }
                else if (command == 'S' && IsInMaze(maze, marioRow + 1, marioCol))
                {
                    marioRow++;
                }
                else if (command == 'A' && IsInMaze(maze, marioRow, marioCol - 1))
                {
                    marioCol--;
                }
                else if (command == 'D' && IsInMaze(maze, marioRow, marioCol + 1))
                {
                    marioCol++;
                }

                if (lives <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    lives -= 2;

                    if (lives > 0)
                    {
                        maze[marioRow][marioCol] = '-';
                    }
                    else
                    {
                        maze[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                }
                else if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }
            }
            foreach (var item in maze)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
        public static bool IsInMaze(char[][] maze, int row, int col)
        {
            return row >= 0 && row < maze.Length && col >= 0 && col < maze[0].Length;
        }
    }
}
