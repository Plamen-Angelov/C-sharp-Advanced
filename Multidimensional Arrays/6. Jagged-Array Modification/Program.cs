using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[num][];

            for (int i = 0; i < num; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= jaggedArray.Length
                || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                if (command[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[i]));
            }
        }
    }
}
