using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;

namespace EX__07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> followersByUsername = new Dictionary<string, List<string>>();
            Dictionary<string, int> FollowingsByUsername = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = command[0];
                string action = command[1];

                if (action == "joined")
                {
                    if (!followersByUsername.ContainsKey(vloggerName))
                    {
                        followersByUsername.Add(vloggerName, new List<string>());
                        FollowingsByUsername.Add(vloggerName, 0);
                    }
                }
                else if (action == "followed")
                {
                    string followedVlogger = command[2];

                    if (followersByUsername.ContainsKey(vloggerName) 
                        && followersByUsername.ContainsKey(followedVlogger)
                        && vloggerName != followedVlogger
                        && !followersByUsername[followedVlogger].Contains(vloggerName))
                    {
                        followersByUsername[followedVlogger].Add(vloggerName);
                        FollowingsByUsername[vloggerName]++;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {followersByUsername.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var kvp in followersByUsername
                .OrderByDescending(f => f.Value.Count)
                . ThenBy(x => FollowingsByUsername[x.Key]))
            {
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Count} followers," +
                                      $" {FollowingsByUsername[kvp.Key]} following");

                    if (kvp.Value.Count > 0)
                    {
                        foreach (var follower in kvp.Value.OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Count} followers, {FollowingsByUsername[kvp.Key]} following");
                }

                counter++;
            }
        }
    }
}
