using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EX__05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            double [] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double, double> add = n => n + 1;
            Func<double, double> multiply = n => n * 2;
            Func<double, double> subtract = n => n - 1;
            Action<double[]> printNums = numLine => Console.WriteLine($"{string.Join(' ', numLine)}");

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers
                        .Select(add)
                        .ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = numbers
                        .Select(multiply)
                        .ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers
                        .Select(subtract)
                        .ToArray();
                }
                else if (command == "print")
                {
                    printNums(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
