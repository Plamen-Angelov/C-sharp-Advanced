using System;
using System.Linq;

namespace EX__6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new Double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[i] = row;

                if (i >=1 && i <= n)
                {
                    if (matrix[i-1].Length == matrix[i].Length)
                    {
                        for (int j = 0; j < matrix[i-1].Length; j++)
                        {
                            matrix[i - 1][j] *= 2;
                            matrix[i][j] *= 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < matrix[i - 1].Length; j++)
                        {
                            matrix[i - 1][j] /= 2;
                        }

                        for (int k = 0; k < matrix[i].Length; k++)
                        {
                            matrix[i][k] /= 2;
                        }
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (AreIndexisValid(row, col, matrix, n))
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (AreIndexisValid(row, col, matrix, n))
                    {
                        matrix[row][col] -= value;
                    }
                }
                else if (command[0] == "End")
                {
                    foreach (var array in matrix)
                    {
                        Console.WriteLine(string.Join(' ', array));
                    }
                    return;
                }
            }
        }

        static bool AreIndexisValid(int row, int col, double[][] matrix, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < matrix[row].Length;
        }
    }
}
