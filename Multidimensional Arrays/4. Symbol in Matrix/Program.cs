using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            char[,] matrix = new char[num, num];


            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < num; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char ch = char.Parse(Console.ReadLine());

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (ch == matrix[i,j])
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{ch} does not occur in the matrix ");
        }
    }
}
