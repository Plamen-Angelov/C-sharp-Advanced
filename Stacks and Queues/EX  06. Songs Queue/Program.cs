using System;
using System.Linq;
using System.Collections.Generic;

namespace EX__06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playList = new Queue<string>(Console.ReadLine().Split(", "));

            while (playList.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    playList.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", playList));
                }
                else
                {
                    int firstSpaceIndex = command.IndexOf(' ');
                    string songName = command.Substring(firstSpaceIndex + 1);

                    if (playList.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        playList.Enqueue(songName);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
