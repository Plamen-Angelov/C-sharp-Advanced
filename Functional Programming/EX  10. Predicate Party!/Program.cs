using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(' ')
                .ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Func<string, string, bool> startWith = (name, str) => name.StartsWith(str);
                Func<string, string, bool> endtWith = (name, str) => name.EndsWith(str);
                Func<string, int, bool> equalLength = (name, num) => name.Length == num;
                

                if (tokens[0] == "Remove")
                {
                    if (tokens[1] == "StartsWith")
                    {
                        string str = tokens[2];

                        people = people
                            .Where(n => !startWith(n, str))
                            .ToList();
                    }
                    else if (tokens[1] == "EndsWith")
                    {
                        string str = tokens[2];

                        people = people
                            .Where(n => !endtWith(n, str))
                            .ToList();
                    }
                    else if (tokens[1] == "Length")
                    {
                        int length = int.Parse(tokens[2]);

                        people = people
                            .Where(n => !equalLength(n, length))
                            .ToList();
                    }
                }
                else if (tokens[0] == "Double")
                {
                    if (tokens[1] == "StartsWith")
                    {
                        string str = tokens[2];

                        List<string> peopleToDouble = people
                            .Where(n => startWith(n, str))
                            .ToList();

                        int index = people.IndexOf(peopleToDouble[0]);

                        people.InsertRange(0, peopleToDouble);
                    }
                    else if (tokens[1] == "EndsWith")
                    {
                        string str = tokens[2];

                        List<string> peopleToDouble = people
                            .Where(n => endtWith(n, str))
                            .ToList();

                        int index = people.IndexOf(peopleToDouble[0]);

                        people.InsertRange(0, peopleToDouble);
                    }
                    else if (tokens[1] == "Length")
                    {
                        int length = int.Parse(tokens[2]);

                        List<string> peopleToDouble = people
                            .Where(n => equalLength(n, length))
                            .ToList();

                        int index = people.IndexOf(peopleToDouble[0]);

                        people.InsertRange(0, peopleToDouble);
                    }
                }

                command = Console.ReadLine();
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
