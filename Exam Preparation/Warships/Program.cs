using System;
using System.Linq;

namespace Warships_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            string[] coordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            int firstPLayerShips = 0;
            int secondPlayerShips = 0;

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = input[j];

                    if (input[j] == '<')
                    {
                        firstPLayerShips++;
                    }
                    else if (input[j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }
            int totalCountOfShips = firstPLayerShips + secondPlayerShips;

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] attack = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = attack[0];
                int col = attack[1];

                if (!IsInField(n, row, col))
                {
                    continue;
                }

                if (field[row,col] == '<')
                {
                    firstPLayerShips--;
                    field[row, col] = 'X';

                }
                else if (field[row, col] == '>')
                {
                    secondPlayerShips--;
                    field[row, col] = 'X';
                }
                else if (field[row, col] == '#')
                {
                    field[row, col] = 'X';

                    if (IsInField(n, row - 1, col - 1) && (field[row - 1, col - 1] == '<' || field[row - 1, col - 1] == '>'))
                    {
                        if (field[row - 1, col - 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row - 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row - 1, col - 1] = 'X';
                    }

                    if (IsInField(n, row - 1, col) && (field[row - 1, col] == '<' || field[row - 1, col] == '>'))
                    {
                        if (field[row - 1, col] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row - 1, col] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row - 1, col] = 'X';

                    }

                    if (IsInField(n, row - 1, col + 1) && (field[row - 1, col + 1] == '<' || field[row - 1, col + 1] == '>'))
                    {
                        if (field[row - 1, col + 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row - 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row - 1, col + 1] = 'X';

                    }

                    if (IsInField(n, row, col - 1) && (field[row, col - 1] == '<' || field[row, col - 1] == '>'))
                    {
                        if (field[row, col - 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row, col - 1] = 'X';
                    }

                    if (IsInField(n, row, col + 1) && (field[row, col + 1] == '<' || field[row, col + 1] == '>'))
                    {
                        if (field[row, col + 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row, col + 1] = 'X';
                    }

                    if (IsInField(n, row + 1, col - 1) && (field[row + 1, col - 1] == '<' || field[row + 1, col - 1] == '>'))
                    {
                        if (field[row + 1, col - 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row + 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row + 1, col - 1] = 'X';
                    }

                    if (IsInField(n, row + 1, col) && (field[row + 1, col] == '<' || field[row + 1, col] == '>'))
                    {
                        if (field[row + 1, col] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row + 1, col] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row + 1, col] = 'X';
                    }

                    if (IsInField(n, row + 1, col + 1) && (field[row + 1, col + 1] == '<' || field[row + 1, col + 1] == '>'))
                    {
                        if (field[row + 1, col + 1] == '<')
                        {
                            firstPLayerShips--;
                        }
                        else if (field[row + 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }

                        field[row + 1, col + 1] = 'X';
                    }

                    if (firstPLayerShips == 0 || secondPlayerShips == 0)
                    {
                        break;
                    }
                }
            }

            if (firstPLayerShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! " +
                    $"{totalCountOfShips - (firstPLayerShips + secondPlayerShips)} ships have been sunk in the battle.");
            }
            else if (secondPlayerShips == 0)
            {
                Console.WriteLine($"Player One has won the game! " +
                    $"{totalCountOfShips - (firstPLayerShips + secondPlayerShips)} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPLayerShips} ships left. " +
                    $"Player Two has {secondPlayerShips} ships left.");
            }
        }

        public static bool IsInField(int n, int row, int col)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
