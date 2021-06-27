using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];

                    if (line[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                }
            }

            int eatenFood = 0;
            matrix[snakeRow, snakeCol] = '.';

            while (eatenFood < 10)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }


                if (IsInMatrix(matrix, snakeRow, snakeCol))
                {
                    char current = matrix[snakeRow, snakeCol];
                    matrix[snakeRow, snakeCol] = '.';

                    if (current == '*')
                    {
                        eatenFood++;
                    }
                    else if (current == 'B')
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i,j] == 'B')
                                {
                                    snakeRow = i;
                                    snakeCol = j;
                                    matrix[i, j] = '.';
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                } 
            }

            if (eatenFood == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                matrix[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(matrix);
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
