using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            string command = Console.ReadLine();
            bool party = false;

            while (command != "END")
            {
                if (command.ToUpper() == "PARTY")
                {
                    party = true;
                    command = Console.ReadLine();
                    continue;
                }

                if (!party)
                {
                    if (char.IsDigit(command[0]))
                    {
                        vipGuests.Add(command);
                    }
                    else
                    {
                        regularGuests.Add(command);
                    }
                }
                else
                {
                    if (char.IsDigit(command[0]))
                    {
                        vipGuests.Remove(command);
                    }
                    else
                    {
                        regularGuests.Remove(command);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
