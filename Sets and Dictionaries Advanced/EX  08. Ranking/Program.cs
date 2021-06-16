using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> pointsByStudents =
                new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] contestData = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = contestData[0];
                string password = contestData[1];

                contestsAndPasswords.Add(contest, password);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                string[] studentsData = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = studentsData[0];
                string password = studentsData[1];
                string name = studentsData[2];
                int points = int.Parse(studentsData[3]);

                if (contestsAndPasswords.ContainsKey(contest) && contestsAndPasswords.ContainsValue(password))
                {
                    if (pointsByStudents.ContainsKey(name))
                    {
                        if (pointsByStudents[name].ContainsKey(contest)
                            && pointsByStudents[name][contest] < points)
                        {
                            pointsByStudents[name][contest] = points;
                        }

                        if (!pointsByStudents[name].ContainsKey(contest))
                        {
                            pointsByStudents[name].Add(contest, points);
                        }
                    }
                    else
                    {
                        pointsByStudents.Add(name, new Dictionary<string, int>() { { contest, points } });
                    }
                }
            }

            foreach (var kvp in pointsByStudents
                .OrderByDescending(x => x.Value.Values.Sum())
                .Take(1))
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking:");
            foreach (var kvp in pointsByStudents)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var contest in kvp.Value.OrderByDescending(x=> x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
