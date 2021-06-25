using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] backery = new char[n, n];

            int myRow = -1;
            int myCol = -1;

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    backery[i, j] = input[j];

                    if (input[j] == 'S')
                    {
                        myRow = i;
                        myCol = j;
                    }
                }
            }

            int earnedMoney = 0;
            backery[myRow, myCol] = '-';

            while (earnedMoney < 50)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    myRow -= 1;
                }
                else if (command == "down")
                {
                    myRow += 1;
                }
                else if (command == "left")
                {
                    myCol -= 1;
                }
                else if (command == "right")
                {
                    myCol += 1;
                }
                if (!IsInBackary(backery, myRow, myCol))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                else
                {
                    char currentSymbol = backery[myRow, myCol];

                    if (char.IsDigit(currentSymbol))
                    {
                        earnedMoney += int.Parse(currentSymbol.ToString());
                        backery[myRow, myCol] = '-';
                    }
                    else if (currentSymbol == 'O')
                    {
                        backery[myRow, myCol] = '-';
                        bool isFound = false;

                        for (int i = 0; i < backery.GetLength(0); i++)
                        {
                            if (isFound)
                            {
                                break;
                            }

                            for (int j = 0; j < backery.GetLength(1); j++)
                            {
                                if (backery[i,j] == 'O')
                                {
                                    myRow = i;
                                    myCol = j;
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                        backery[myRow, myCol] = '-';
                    }
                }
            }

            if (IsInBackary(backery, myRow, myCol))
            {
                backery[myRow, myCol] = 'S';
            }

            if (earnedMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {earnedMoney}");

            for (int i = 0; i < backery.GetLength(0); i++)
            {
                for (int j = 0; j < backery.GetLength(1); j++)
                {
                    Console.Write(backery[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool IsInBackary(char[,] backary, int row, int col)
        {
            if (row >= 0 && row < backary.GetLength(0)
                && col >= 0 && col < backary.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
