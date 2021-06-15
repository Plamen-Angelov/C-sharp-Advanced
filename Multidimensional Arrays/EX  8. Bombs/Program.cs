using System;
using System.Linq;

namespace EX__8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string[] bombs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int rowIndex = int.Parse(bombs[i][0].ToString());
                int colIndex = int.Parse(bombs[i][2].ToString());

                int bomb = matrix[rowIndex, colIndex];

                if (bomb <= 0)
                {
                    continue;
                }

                matrix[rowIndex, colIndex] = 0;

                for (int j = rowIndex - 1; j <= rowIndex +1; j++)
                {
                    for (int k = colIndex - 1; k <= colIndex + 1; k++)
                    {
                        if (j < 0 || j >= matrix.GetLength(0)
                                  || k < 0 || k >= matrix.GetLength(1))
                        {
                            continue;
                        }
                        else if (j == rowIndex && k == colIndex)
                        {
                            continue;
                        }
                        else
                        {
                            if (matrix[j, k] > 0)
                            {
                                matrix[j, k] -= bomb;
                            }
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sumOfAliveCells = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfAliveCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
