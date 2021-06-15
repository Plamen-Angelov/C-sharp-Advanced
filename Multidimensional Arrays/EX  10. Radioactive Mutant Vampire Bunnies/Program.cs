using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadFromConsoleToArray();
            int row = sizes[0];
            int col = sizes[1];
            char[,] matrix = new char[row, col];
            AddElementsToMatrix(sizes[0], sizes[1], matrix);

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            string command = Console.ReadLine();

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case 'L':
                        if (IsInMatrix(playerRow, playerCol - 1, matrix) 
                            && IsBunny(playerRow, playerCol-1, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol - 1;
                            BunnySpread(matrix);

                            PrintRezultWhenDead(matrix, playerRow, playerCol);
                            return;
                        }
                        else if (IsInMatrix(playerRow, playerCol - 1, matrix) 
                                 && !IsBunny(playerRow, playerCol - 1, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol - 1;
                            matrix[playerRow, playerCol] = 'P';
                            
                            BunnySpread(matrix);

                            if (matrix[playerRow,playerCol] == 'B')
                            {
                                PrintRezultWhenDead(matrix, playerRow, playerCol);
                                return;
                            }
                        }
                       else if (!IsInMatrix(playerRow, playerCol - 1, matrix))
                       {
                           matrix[playerRow, playerCol] = '.';
                           BunnySpread(matrix);
                           PrintResultWhenWim(matrix,playerRow, playerCol);
                       }
                        break;
                    case 'R':

                        if (IsInMatrix(playerRow, playerCol + 1, matrix)
                            && IsBunny(playerRow, playerCol + 1, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol + 1;

                            BunnySpread(matrix);

                            PrintRezultWhenDead(matrix, playerRow, playerCol);
                            return;
                        }
                        else if (IsInMatrix(playerRow, playerCol + 1, matrix)
                                 && !IsBunny(playerRow, playerCol + 1, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol = playerCol + 1;
                            matrix[playerRow, playerCol] = 'P';
                            BunnySpread(matrix);

                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                PrintRezultWhenDead(matrix, playerRow, playerCol);
                                return;
                            }
                        }
                       else if (!IsInMatrix(playerRow, playerCol + 1, matrix))
                       {
                           matrix[playerRow, playerCol] = '.';
                           BunnySpread(matrix);
                           PrintResultWhenWim(matrix, playerRow, playerCol);
                        }
                        break;
                    case 'U':
                        if (IsInMatrix(playerRow - 1, playerCol, matrix)
                            && IsBunny(playerRow - 1, playerCol, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow - 1;
                            BunnySpread(matrix);

                            PrintRezultWhenDead(matrix, playerRow, playerCol);
                            return;
                        }
                        else if (IsInMatrix(playerRow - 1, playerCol, matrix)
                                 && !IsBunny(playerRow - 1, playerCol, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow - 1;
                            matrix[playerRow, playerCol] = 'P';
                            BunnySpread(matrix);

                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                PrintRezultWhenDead(matrix, playerRow, playerCol);
                                return;
                            }
                        }
                       else if (!IsInMatrix(playerRow - 1, playerCol, matrix))
                       {
                           matrix[playerRow, playerCol] = '.';
                           BunnySpread(matrix);
                           PrintResultWhenWim(matrix, playerRow, playerCol);
                        }
                        break;
                    case 'D':
                        if (IsInMatrix(playerRow + 1, playerCol, matrix)
                            && IsBunny(playerRow + 1, playerCol, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow + 1;
                            BunnySpread(matrix);

                            PrintRezultWhenDead(matrix, playerRow, playerCol);
                            return;
                        }
                        else if (IsInMatrix(playerRow + 1, playerCol, matrix)
                                 && !IsBunny(playerRow + 1, playerCol, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow = playerRow + 1;
                            matrix[playerRow, playerCol] = 'P';
                            BunnySpread(matrix);

                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                PrintRezultWhenDead(matrix, playerRow, playerCol);
                                return;
                            }
                        }
                        else if (!IsInMatrix(playerRow + 1, playerCol, matrix))
                        {
                            matrix[playerRow, playerCol] = '.';
                            BunnySpread(matrix);
                            PrintResultWhenWim(matrix, playerRow, playerCol);
                        }
                        break;
                }
            }

        }

        private static void PrintResultWhenWim(char[,] matrix, int playerRow, int playerCol)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"won: {playerRow} {playerCol}");
        }

        private static void PrintRezultWhenDead(char[,] matrix, int playerRow, int playerCol)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"dead: {playerRow} {playerCol}");
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static char[,] BunnySpread(char[,] matrix)
        {
            HashSet<int[]> bunnyCoordinates = new HashSet<int[]>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        int[] bunny = new int[] { i, j };
                        bunnyCoordinates.Add(bunny);
                    }
                }
            }

            foreach (var bunny in bunnyCoordinates)
            {
                if (IsInMatrix(bunny[0] - 1, bunny[1], matrix))
                {
                    matrix[bunny[0] - 1, bunny[1]] = 'B';
                }

                if (IsInMatrix(bunny[0], bunny[1] - 1, matrix))
                {
                    matrix[bunny[0], bunny[1] - 1] = 'B';
                }

                if (IsInMatrix(bunny[0] + 1, bunny[1], matrix))
                {
                    matrix[bunny[0] + 1, bunny[1]] = 'B';
                }

                if (IsInMatrix(bunny[0], bunny[1] + 1, matrix))
                {
                    matrix[bunny[0], bunny[1] + 1] = 'B';
                }
            }

            return matrix;
        }

        private static bool IsBunny(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == 'B';
        }

        private static bool IsInMatrix(int playerRow, int playerCol, char[,] matrix)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 &&
                   playerCol < matrix.GetLength(1);
        }

        static void AddElementsToMatrix(int row, int col, char[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = line[j];
                }
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
