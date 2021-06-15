using System;
using System.Collections.Generic;
using System.Linq;

namespace EX__11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int buletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArr = ReadFromConsoleToArray();
            int[] locksArr = ReadFromConsoleToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksArr);
            Stack<int> bullets = new Stack<int>(bulletsArr);
            int shootsFromBarrel = 0;
            int totalBulletsUsed = 0;

            while (locks.Count != 0 && bullets.Count != 0)
            {
                if (locks.Peek() >= bullets.Peek())
                {
                    shootsFromBarrel++;
                    totalBulletsUsed++;
                    locks.Dequeue();
                    bullets.Pop();
                    Console.WriteLine("Bang!");
                    if (shootsFromBarrel == gunBarrel && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        shootsFromBarrel = 0;
                    }
                }
                else if (locks.Peek() < bullets.Peek())
                {
                    shootsFromBarrel++;
                    totalBulletsUsed++;
                    bullets.Pop();
                    Console.WriteLine("Ping!");
                    if (shootsFromBarrel == gunBarrel && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        shootsFromBarrel = 0;
                    }
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. " +
                                  $"Earned ${intelligence - (buletPrice * totalBulletsUsed)}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

        private static int[] ReadFromConsoleToArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
