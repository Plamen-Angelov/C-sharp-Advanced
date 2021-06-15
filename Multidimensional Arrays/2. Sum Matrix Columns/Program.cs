using System;
using System.Linq;
using System.Net.Sockets;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadFromConsoleToArray();

            int[,] NumMatrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                int[] input = ReadFromConsoleToArray();

                for (int j = 0; j < size[1]; j++)
                {
                    NumMatrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < NumMatrix.GetLength(1); i++)
            {
                int sum = 0;

                for (int j = 0; j < NumMatrix.GetLength(0); j++)
                {
                    sum += NumMatrix[j, i];
                }

                Console.WriteLine(sum);
            }
        }

        private static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(new string[] {", ", ",", " "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
