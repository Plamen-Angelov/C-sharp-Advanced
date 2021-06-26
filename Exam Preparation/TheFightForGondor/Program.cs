using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(platesInput);
            int firstPlate = plates.Dequeue();
            List<int> leftOrcs = new List<int>();

            bool areTherePlates = true;

            for (int i = 1; i <= numberOfWaves; i++)
            {
                List<int> orcWave = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (i % 3 == 0)
                {
                    int buildPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(buildPlate);
                }

                for (int j = orcWave.Count - 1; j >= 0; j--)
                { 
                    if (firstPlate > orcWave[orcWave.Count - 1])
                    {
                        firstPlate -= orcWave[orcWave.Count - 1];
                        orcWave.RemoveAt(orcWave.Count - 1);
                    }
                    else if (firstPlate < orcWave[orcWave.Count - 1])
                    {
                        orcWave[orcWave.Count - 1] -= firstPlate;
                        firstPlate = 0;
                        if (plates.Count > 0)
                        {
                            firstPlate = plates.Dequeue();

                        }
                    }
                    else if (firstPlate == orcWave[orcWave.Count - 1])
                    {
                        orcWave.RemoveAt(orcWave.Count - 1);
                        firstPlate = 0;
                        if (plates.Count > 0)
                        {
                            firstPlate = plates.Dequeue();

                        }
                    }

                    if (plates.Count == 0 && firstPlate == 0)
                    {
                        areTherePlates = false;
                        break;
                    }
                }

                leftOrcs = orcWave;

                if (!areTherePlates)
                {
                    break;
                }
            }

            if (areTherePlates)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                if (plates.Count > 0)
                {
                    Console.WriteLine($"Plates left: {firstPlate}, {string.Join(", ", plates)}");
                }
                else
                {
                    Console.WriteLine($"Plates left: {firstPlate}");

                }
            }
            else
            {
                leftOrcs.Reverse();
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", leftOrcs)}");
            }
        }
    }
}
