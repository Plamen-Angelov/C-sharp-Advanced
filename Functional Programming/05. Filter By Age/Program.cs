using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, ageToCompare) => person.age < ageToCompare;
            Func<(string name, int age), int, bool> older = (person, ageToCompare) => person.age >= ageToCompare;

            int n = int.Parse(Console.ReadLine());
            (string name, int age)[] people = new (string nameof, int age)[n];

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = (personInfo[0], int.Parse(personInfo[1]));
            }

            string condition = Console.ReadLine();
            int ageToCompare = int.Parse(Console.ReadLine());

            switch (condition)
            {
                case "younger":
                    people = people
                        .Where(p => younger(p, ageToCompare))
                        .ToArray();
                    break;

                case "older":
                    people = people
                        .Where(p => older(p, ageToCompare))
                        .ToArray();
                    break;
            }

            string[] printFormat = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                List<string> personToPrint = new List<string>();

                if (printFormat.Contains("name"))
                {
                    personToPrint.Add(person.name);
                }

                if (printFormat.Contains("age"))
                {
                    personToPrint.Add(person.age.ToString());
                }

                Console.WriteLine($"{string.Join(" - ", personToPrint)}");
            }
        }
    }
}
