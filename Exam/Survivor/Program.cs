using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[i] = line;
            }
            int playerTokens = 0;
            int opponentTokens = 0;
            string input = Console.ReadLine();

            while (input != "Gong")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (!IsInMatrix(matrix, row, col))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (command[0] == "Find")
                {
                    if (matrix[row][col] == 'T')
                    {
                        playerTokens++;
                        matrix[row][col] = '-';
                    }
                }
                else if (command[0] == "Opponent")
                {
                    if (matrix[row][col] == 'T')
                    {
                        opponentTokens++;
                        matrix[row][col] = '-';
                    }
                        
                    string move = command[3];
                    List<int[]> coordinates = new List<int[]>();

                    if (move == "up")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            row --;
                            coordinates.Add(new int[] { row, col });
                        }
                    }
                    else if (move == "down")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            row ++;
                            coordinates.Add(new int[] { row, col });
                        }
                    }
                    else if (move == "left")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            col --;
                            coordinates.Add(new int[] { row, col });
                        }
                    }
                    else if (move == "right")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            col ++;
                            coordinates.Add(new int[] { row, col });
                        }
                    }

                    foreach (var item in coordinates)
                    {
                        int currentRow = item[0];
                        int currentCol = item[1];

                        if (!IsInMatrix(matrix, currentRow, currentCol))
                        {
                            break;
                        }
                        if (matrix[currentRow][currentCol] == 'T')
                        {
                            opponentTokens++;
                            matrix[currentRow][currentCol] = '-';
                        }
                    }
                }

                input = Console.ReadLine();
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }

            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
