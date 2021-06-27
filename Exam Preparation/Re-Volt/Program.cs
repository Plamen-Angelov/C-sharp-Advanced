using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            matrix[playerRow, playerCol] = '-';
            bool finishreached = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    (matrix, playerRow, playerCol) = MoveUp(matrix, playerRow, playerCol);
                }
                else if (command == "down")
                {
                    (matrix, playerRow, playerCol) = MoveDown(matrix, playerRow, playerCol);
                }
                else if (command == "left")
                {
                    (matrix, playerRow, playerCol) = MoveLeft(matrix, playerRow, playerCol);
                }
                else if (command == "right")
                {
                    (matrix, playerRow, playerCol) = MoveRight(matrix, playerRow, playerCol);
                    
                }

                char current = matrix[playerRow, playerCol];
                
                if (current == 'B')
                {
                    current = '-';

                    if (command == "up")
                    {
                        (matrix, playerRow, playerCol) = MoveUp(matrix, playerRow, playerCol);
                    }
                    else if (command == "down")
                    {
                        (matrix, playerRow, playerCol) = MoveDown(matrix, playerRow, playerCol);
                    }
                    else if (command == "left")
                    {
                        (matrix, playerRow, playerCol) = MoveLeft(matrix, playerRow, playerCol);
                    }
                    else if (command == "right")
                    {
                        (matrix, playerRow, playerCol) = MoveRight(matrix, playerRow, playerCol);
                    }
                    current = matrix[playerRow, playerCol];
                }
                else if (current == 'T')
                {
                    current = '-';

                    if (command == "up")
                    {
                        (matrix, playerRow, playerCol) = MoveDown(matrix, playerRow, playerCol);
                    }
                    else if (command == "down")
                    {
                        (matrix, playerRow, playerCol) = MoveUp(matrix, playerRow, playerCol);
                    }
                    else if (command == "Left")
                    {
                        (matrix, playerRow, playerCol) = MoveRight(matrix, playerRow, playerCol);
                    }
                    else if (command == "right")
                    {
                        (matrix, playerRow, playerCol) = MoveLeft(matrix, playerRow, playerCol);
                    }
                    current = matrix[playerRow, playerCol];
                }
                else if (current == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[playerRow, playerCol] = 'f';
                    finishreached = true;
                    break;
                }
            }
            if (!finishreached)
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static (char[,], int, int) MoveUp(char[,] matrix, int playerRow, int playerCol)
        {
            playerRow--;

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
                playerRow = matrix.GetLength(0) - 1;
            }

            return (matrix, playerRow, playerCol);
        }

        static (char[,], int, int) MoveDown(char[,] matrix, int playerRow, int playerCol)
        {
            playerRow++;

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
                playerRow = 0;
            }
            return (matrix, playerRow, playerCol);
        }

        static (char[,], int, int) MoveLeft(char[,] matrix, int playerRow, int playerCol)
        {
            playerCol--;

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
                playerCol = matrix.GetLength(1) - 1;
            }

            return (matrix, playerRow, playerCol);
        }
        static (char[,], int, int) MoveRight(char[,] matrix, int playerRow, int playerCol)
        {
            playerCol++;

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
                playerCol = 0;
            }

            return (matrix, playerRow, playerCol);
        }
    }
}
