using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];

                    if (input[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            int pollinatedFlower = 0;
            string command = Console.ReadLine();
            matrix[beeRow, beeCol] = '.';

            while (command != "End")
            {
                (beeRow, beeCol) = Move(beeRow, beeCol, command);

                if (!IsInMatrix(matrix, beeRow, beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                char current = matrix[beeRow, beeCol];

                if (current == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    (beeRow, beeCol) = Move(beeRow, beeCol, command);
                    current = matrix[beeRow, beeCol];
                }

                if (current == 'f')
                {
                    pollinatedFlower++;
                    matrix[beeRow, beeCol] = '.';
                }

                command = Console.ReadLine();
            }
            if (IsInMatrix(matrix, beeRow, beeCol))
            {
                matrix[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlower < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlower} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlower} flowers!");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static (int, int) Move(int row, int col, string command)
        {
            if (command == "up")
            {
                row--;
            }
            else if (command == "down")
            {
                row++;
            }
            else if (command == "left")
            {
                col--;
            }
            else if (command == "right")
            {
                col++;
            }

            return (row, col);
        }
    }
}
