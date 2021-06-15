using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadFromConsoleToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                int[] row = ReadFromConsoleToArray();

                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sum = 0;

            foreach (var element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }

        public static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
