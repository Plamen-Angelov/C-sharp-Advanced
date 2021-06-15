using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadFromConsoleToArray();

            int[,] matrix = new int[size[0], size[1]];
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = ReadFromConsoleToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int maxSum = 0;
            int[,] result = new int[2, 2];

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        result[0, 0] = matrix[i, j];
                        result[0, 1] = matrix[i, j + 1];
                        result[1, 0] = matrix[i + 1, j];
                        result[1, 1] = matrix[i + 1, j + 1];
                    }
                }
            }

            Console.WriteLine($"{result[0,0]} {result[0,1]}");
            Console.WriteLine($"{result[1,0]} {result[1,1]}");
            Console.WriteLine(maxSum);
        }

        static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
