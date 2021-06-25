using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray(); ;
            int[,] garden = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    garden[i, j] = 0;
                }
            }

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int[] coordinates = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (!IsInGarden(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[i, col]++;
                }

                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    garden[row, j]++;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsInGarden(int[,] garden, int row, int col)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1);
        }
    }
}
