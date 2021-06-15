using System;
using System.Linq;

namespace EX__9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[n, n];
            AddElementsToMatrix(n, matrix);

            int minerRow = -1;
            int minerCol = -1;
            int totalCoals = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    else if (matrix[i,j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            int minerMoveRaw = -1;
            int minerMoveCol = -1;
            int collectedCoals = 0;

            foreach (var command in commands)
            {
                if (command == "left")
                {
                    minerMoveRaw = minerRow;
                    minerMoveCol = minerCol - 1;

                    if (IsInTheField(minerMoveRaw, minerMoveCol, matrix))
                    {
                        if (matrix[minerMoveRaw, minerMoveCol] == 'c')
                        {
                            collectedCoals++;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            if (collectedCoals == totalCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerMoveRaw, minerMoveCol] == 'e')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command == "right")
                {
                    minerMoveRaw = minerRow;
                    minerMoveCol = minerCol + 1;

                    if (IsInTheField(minerMoveRaw, minerMoveCol, matrix))
                    {
                        if (matrix[minerMoveRaw, minerMoveCol] == 'c')
                        {
                            collectedCoals++;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            if (collectedCoals == totalCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerMoveRaw, minerMoveCol] == 'e')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "up")
                {
                    minerMoveRaw = minerRow - 1;
                    minerMoveCol = minerCol;

                    if (IsInTheField(minerMoveRaw, minerMoveCol, matrix))
                    {
                        if (matrix[minerMoveRaw, minerMoveCol] == 'c')
                        {
                            collectedCoals++;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            if (collectedCoals == totalCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerMoveRaw, minerMoveCol] == 'e')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "down")
                {
                    minerMoveRaw = minerRow + 1;
                    minerMoveCol = minerCol;

                    if (IsInTheField(minerMoveRaw, minerMoveCol, matrix))
                    {
                        if (matrix[minerMoveRaw, minerMoveCol] == 'c')
                        {
                            collectedCoals++;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            if (collectedCoals == totalCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerMoveRaw, minerMoveCol] == 'e')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;

                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerMoveRaw, minerMoveCol] = 's';
                            minerRow = minerMoveRaw;
                            minerCol = minerMoveCol;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({ minerRow}, { minerCol})");
        }
        
        private static bool IsInTheField(int minerMoveRaw, int minerMoveCol, char[,] matrix)
        {
            return minerMoveRaw >= 0 && minerMoveRaw < matrix.GetLength(0)
                                     && minerMoveCol >= 0 && minerMoveCol < matrix.GetLength(1);
        }

        static void AddElementsToMatrix(int n, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
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
