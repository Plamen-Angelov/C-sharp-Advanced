using System;
using System.Linq;

namespace EX__3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadFromConsoleToArray();
            int[,] matrix = new int[size[0],size[1]];
            AddIntElementsToMatrix(size[0], size[1], matrix);

            int sumOfSubmatrix = 0;
            int rowStart = -1;
            int colStart = -1;

            for (int i = 0; i < size[0] - 2; i++)
            {
                for (int j = 0; j < size[1] - 2; j++)
                {
                    int currentSum = 0;

                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                                 + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                                 + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (currentSum > sumOfSubmatrix)
                    {
                        sumOfSubmatrix = currentSum;
                        rowStart = i;
                        colStart = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {sumOfSubmatrix}");
           Console.WriteLine($"{matrix[rowStart,colStart]} {matrix[rowStart,colStart+1]} {matrix[rowStart,colStart+2]}");
           Console.WriteLine($"{matrix[rowStart+1,colStart]} {matrix[rowStart+1,colStart+1]} {matrix[rowStart+1,colStart+2]}");
           Console.WriteLine($"{matrix[rowStart+2,colStart]} {matrix[rowStart+2,colStart+1]} {matrix[rowStart+2,colStart+2]}");
        }
        static void AddIntElementsToMatrix(int row, int col, int[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                int[] line = ReadFromConsoleToArray();

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
