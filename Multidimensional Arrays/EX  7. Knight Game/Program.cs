using System;
using System.Linq;

namespace EX__7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            AddElementsToMatrix(n, matrix);
            int removedKnights = 0;


            while (true)
            {
                int maxAttacked = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            int attacks = GetKnightAttacks(i, j, matrix);

                            if (maxAttacked < attacks)
                            {
                                maxAttacked = attacks;
                                knightRow = i;
                                knightCol = j;
                            }
                        }
                    }
                }

                if (maxAttacked == 0)
                {
                    break;
                }
                removedKnights++;
                matrix[knightRow, knightCol] = '0';
            }
            Console.WriteLine(removedKnights);
        }

        static int GetKnightAttacks(int row, int col, char[,] matrix)
        {
            int attacks = 0;

            if (IsInMatrix(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool IsInMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static void AddElementsToMatrix(int n, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                //char[] line = Console.ReadLine()
                //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                //    .Select(char.Parse)
                //    .ToArray();

                for (int j = 0; j < n; j++)
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
