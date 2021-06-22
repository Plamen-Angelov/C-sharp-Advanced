using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> commands = new List<string>();
            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] command = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (command[0].StartsWith("Add"))
                {
                    commands.Add($"{command[1]}, {command[2]}");
                }
                else
                {
                    commands.Remove($"{command[1]}, {command[2]}");
                }

                input = Console.ReadLine();
            }

            Func<string, string, bool> StartsWithFilter = (name, parameter) => name.StartsWith(parameter);
            Func<string, string, bool> EndsWithFilter = (name, parameter) => name.EndsWith(parameter);
            Func<string, int, bool> LengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> containsFilter = (name, str) => name.Contains(str);

            foreach (var command in commands)
            {
                string[] action = command
                    .Split(", ");

                switch (action[0])
                {
                    case "Starts with":
                        names = names
                            .Where(n => !StartsWithFilter(n, action[1]))
                            .ToArray();
                        break;
                    case "Ends with":
                        names = names
                            .Where(n => !EndsWithFilter(n, action[1]))
                            .ToArray();
                        break;
                    case "Lenght":
                        names = names
                            .Where(n => !LengthFilter(n, int.Parse(action[1])))
                            .ToArray();
                        break;
                    case "Contains":
                        names = names
                            .Where(n => !containsFilter(n, action[1]))
                            .ToArray();
                        break;
                }
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(" ", names)}");
            }
        }
    }
}
