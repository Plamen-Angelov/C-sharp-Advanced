using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputBombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputBombCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffect = new Queue<int>(inputBombEffects);
            Stack<int> bombCasing = new Stack<int>(inputBombCasing);
            int currentEffect = bombEffect.Peek();
            int currentCasing = bombCasing.Peek();
            int daturaBomb = 0;
            int cherryBomb = 0;
            int smokeDecoyBomb = 0;

            while (bombEffect.Count > 0 
                && bombCasing.Count > 0 
                && (daturaBomb < 3 || cherryBomb < 3 || smokeDecoyBomb < 3))
            {
                int bomb = currentEffect + currentCasing;

                if (bomb == 40)
                {
                    daturaBomb++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    if (bombEffect.Count > 0 && bombCasing.Count > 0)
                    {
                        currentEffect = bombEffect.Peek();
                        currentCasing = bombCasing.Peek();
                    }
                }
                else if (bomb == 60)
                {
                    cherryBomb++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    if (bombEffect.Count > 0 && bombCasing.Count > 0)
                    {
                        currentEffect = bombEffect.Peek();
                        currentCasing = bombCasing.Peek();
                    }
                }
                else if (bomb == 120)
                {
                    smokeDecoyBomb++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    if (bombEffect.Count > 0 && bombCasing.Count > 0)
                    {
                        currentEffect = bombEffect.Peek();
                        currentCasing = bombCasing.Peek();
                    }
                }
                else
                {
                    currentCasing -= 5;
                }
            }

            if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBomb}");
        }
    }
}
