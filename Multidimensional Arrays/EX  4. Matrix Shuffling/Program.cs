using System;
using System.Linq;

namespace EX__4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); ;
            string[,] matrix = new string[sizes[0],sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                string[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] swapData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (swapData.Length != 5 || swapData[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(swapData[1]);
                int col1 = int.Parse(swapData[2]);
                int row2 = int.Parse(swapData[3]);
                int col2 = int.Parse(swapData[4]);

                if (row1 < 0 || row1 >= matrix.GetLength(0)
                || row2 < 0 || row2 >= matrix.GetLength(0)
                || col1 < 0 || col1 >= matrix.GetLength(1)
                || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string element = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = element;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}
