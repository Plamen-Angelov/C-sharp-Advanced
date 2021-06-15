using System;
using System.Linq;

namespace EX__1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            AddIntElementsToMatrix(n, matrix);

            int sumPrimeryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                sumPrimeryDiagonal += matrix[i, i];
                sumSecondaryDiagonal += matrix[i, n - i - 1];
            }

            Console.WriteLine(Math.Abs(sumPrimeryDiagonal - sumSecondaryDiagonal));
        }

        static void AddIntElementsToMatrix(int n, int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                int[] row = ReadFromConsoleToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
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
