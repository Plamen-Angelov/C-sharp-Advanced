using System;
using System.Linq;

namespace EX__2._Squares_in_Matrix
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
            int squarMatrixCounter = 0;

            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    if (matrix[i,j] == matrix[i,j+1] 
                    && matrix[i,j] == matrix[i+1, j]
                    && matrix[i,j] == matrix[i+1, j+1])
                    {
                        squarMatrixCounter++;
                    }
                }
            }
            Console.WriteLine(squarMatrixCounter);
        }
        static void AddElementsToMatrix(int row, int col, char[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

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
